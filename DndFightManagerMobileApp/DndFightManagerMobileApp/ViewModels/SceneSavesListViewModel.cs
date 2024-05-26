using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class SceneSavesListViewModel : BaseViewModel, IQueryAttributable
    {
        #region Incoming params
        private string _sceneId;
        #endregion

        private string _currentId;

        #region ObservableProperties

        [ObservableProperty]
        private SceneModel _currentScene;

        [ObservableProperty]
        private ObservableCollection<SceneSaveModel> _sceneSaves;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private string _popupSceneSaveTitle;

        [ObservableProperty]
        private bool _deleteAlertIsOpen;

        #endregion
        public SceneSavesListViewModel() 
        {
            SceneSaves = [];
        }

        #region MoreMenu
        private void MoreMenusClosing()
        {
            foreach (var sceneSave in SceneSaves)
            {
                sceneSave.IsMoreMenuOpened = false;
            }
        }

        [RelayCommand]
        private void MoreMenuOpenClose(string id)
        {
            foreach (var sceneSave in SceneSaves)
            {
                if (sceneSave.Id == id)
                    sceneSave.IsMoreMenuOpened = !sceneSave.IsMoreMenuOpened;
                else
                    sceneSave.IsMoreMenuOpened = false;
            }
        }

        [RelayCommand]
        private void EditSceneSave(string id)
        {
            _currentId = id;
            OpenPopup();
        }

        [RelayCommand]
        private async Task NavigateToSceneManager(string id)
        {

        }


        #endregion

        #region Create/Edit Popup

        [RelayCommand]
        private void OpenPopup()
        {
            MoreMenusClosing();
            if (_currentId != null)
            {
                var scene = SceneSaves.FirstOrDefault(x => x.Id == _currentId);
                if (scene != null)
                {
                    PopupSceneSaveTitle = scene.Title;
                }
            }
            PopupIsOpen = true;
        }

        [RelayCommand]
        private void ClosePopup()
        {
            PopupIsOpen = false;
        }

        [RelayCommand]
        private async Task ConfirmActionPopup()
        {
            bool success = false;
            var sceneSave = SceneSaves.FirstOrDefault(x => x.Id == _currentId);
            sceneSave.Title = PopupSceneSaveTitle;
            success = await dataStore.SceneSave.Update(sceneSave);
            
            if (success)
            {
                SceneSaves = [.. dataStore.SceneSave.GetAllBySceneId(CurrentScene.Id).Result];
                ClosePopup();
            }
        }
        #endregion

        #region DeleteAlert

        [RelayCommand]
        private async Task DeleteSceneSave(string id)
        {
            MoreMenusClosing();
            _currentId = id;
            OpenDeleteAlert();
        }

        private void OpenDeleteAlert()
        {
            DeleteAlertIsOpen = true;
        }

        [RelayCommand]
        private void CloseDeleteAlert()
        {
            DeleteAlertIsOpen = false;
        }

        [RelayCommand]
        private async Task ConfirmDeleting()
        {
            await dataStore.SceneSave.Delete(_currentId);
            SceneSaves = [.. dataStore.SceneSave.GetAllBySceneId(CurrentScene.Id).Result];
            CloseDeleteAlert();
        }
        #endregion

        #region Navigation
        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            MoreMenusClosing();

            string sceneIdParam = "sceneId";

            _sceneId = null;

            if (query.ContainsKey(sceneIdParam))
                _sceneId = NPConv.ObjectFromUrl<string>(query[sceneIdParam]);

            if (!string.IsNullOrEmpty(_sceneId))
            {
                CurrentScene = await dataStore.Scene.GetById(_sceneId);
                SceneSaves = [.. await dataStore.SceneSave.GetAllBySceneId(_sceneId)];
                if (SceneSaves != null && SceneSaves.Count == 0)
                {
                    await dataStore.SceneSave.Create(new SceneSaveModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Scene = CurrentScene
                    });
                    SceneSaves = [.. await dataStore.SceneSave.GetAllBySceneId(_sceneId)];
                }
            }
            else
            {
                SceneSaves = [];
            }
        }

        [RelayCommand]
        private void NavigateBackTo()
        {
            Shell.Current.GoToAsync("..");
        }
        #endregion
    }
}
