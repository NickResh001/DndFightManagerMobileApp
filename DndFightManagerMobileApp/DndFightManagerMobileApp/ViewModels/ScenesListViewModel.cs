using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class ScenesListViewModel : BaseViewModelHandNavigation
    {
        #region ObservableProperties

        [ObservableProperty]
        private ObservableCollection<SceneModel> _scenes;

        [ObservableProperty]
        private string _popupTitle;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private string _popupSceneTitle;

        [ObservableProperty]
        private ObservableCollection<CampaignModel> _campaigns;

        [ObservableProperty]
        private CampaignModel _popupSelectedCampaign;

        [ObservableProperty]
        private bool _deleteAlertIsOpen;

        [ObservableProperty]
        private string _deleteMessange;

        [ObservableProperty]
        private bool _createAlertIsOpen;
        #endregion

        private string _currentId;

        public ScenesListViewModel()
        {
            Scenes = [.. dataStore.Scene.GetAll().Result];
            DeleteMessange = "";
            _currentId = null;
            CloseCreateAlert();
            ClosePopup();
        }

        #region MoreMenu
        private void MoreMenusClosing()
        {
            foreach (var scene in Scenes)
            {
                scene.IsMoreMenuOpened = false;
            }
        }

        [RelayCommand]
        private void MoreMenuOpenClose(string id)
        {
            foreach (var scene in Scenes)
            {
                if (scene.Id == id)
                    scene.IsMoreMenuOpened = !scene.IsMoreMenuOpened;
                else
                    scene.IsMoreMenuOpened = false;
            }
        }
        [RelayCommand]
        private async Task NavigateToSceneSaves(string sceneId)
        {
            await Shell.Current.GoToAsync($"");
        }
        
        #endregion

        #region Create/Edit Popup
        [RelayCommand]
        private async void CreateScene()
        {
            _currentId = null;
            PopupTitle = "Добавление";
            if (await dataStore.Campaign.GetAny())
            {
                OpenPopup();
            }
            else
            {
                OpenCreateAlert();
            }
        }

        [RelayCommand]
        private void EditScene(string id)
        {
            _currentId = id;
            PopupTitle = "Редактирование";
            OpenPopup();
        }

        private void OpenPopup()
        {
            MoreMenusClosing();
            PopupSceneTitle = "";
            if (_currentId != null)
            {
                var scene = Scenes.FirstOrDefault(x => x.Id == _currentId);
                if (scene != null)
                {
                    PopupSceneTitle = scene.Title;
                    PopupSelectedCampaign = Campaigns.FirstOrDefault(x => x.Id == scene.Campaign.Id);
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
            if (_currentId == null && PopupSelectedCampaign != null)
            {
                var scene = new SceneModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = PopupSceneTitle,
                    Campaign = PopupSelectedCampaign,
                };

                success = await dataStore.Scene.Create(scene);
            }
            else
            {
                var scene = Scenes.FirstOrDefault(x => x.Id == _currentId);
                if (scene != null && PopupSelectedCampaign != null)
                {
                    scene.Title = PopupSceneTitle;
                    scene.Campaign = PopupSelectedCampaign;
                    success = await dataStore.Scene.Update(scene);
                }
            }

            if (success)
            {
                Scenes = [.. await dataStore.Scene.GetAll()];
                ClosePopup();
            }
        }
        #endregion

        #region DeleteAlert

        [RelayCommand]
        private async Task DeleteScene(string id)
        {
            MoreMenusClosing();
            _currentId = id;
            List<SceneSaveModel> sceneSaves = [.. await dataStore.SceneSave.GetAllBySceneId(id)];
            if (sceneSaves != null && sceneSaves.Count > 0)
            {
                OpenDeleteAlert(sceneSaves.Count);
            }
            else
            {
                await dataStore.Scene.Delete(_currentId);
                Scenes = [.. await dataStore.Scene.GetAll()];
            }
        }

        private void OpenDeleteAlert(int sceneSaveCount)
        {
            DeleteMessange = $"Сцена содержит сохранения: {sceneSaveCount} шт.";
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
            await dataStore.Scene.Delete(_currentId);
            Scenes = [.. await dataStore.Scene.GetAll()];
            CloseDeleteAlert();
        }
        #endregion

        #region CreateAlert

        private void OpenCreateAlert() => CreateAlertIsOpen = true;

        [RelayCommand]
        private void CloseCreateAlert() => CreateAlertIsOpen = false;
        #endregion

        #region Navigation

        public override async void OnNavigateTo(object parameter)
        {
            Scenes = [.. dataStore.Scene.GetAll().Result];
            _currentId = null;
            Campaigns = [.. await dataStore.Campaign.GetAll()];
            if (Campaigns != null && Campaigns.Count > 0)
                PopupSelectedCampaign = Campaigns[0];
            else
                PopupSelectedCampaign = null;

            MoreMenusClosing();
            ClosePopup(); 
            CloseCreateAlert();
        }

        #endregion
    }
}
