using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Utils;
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
        private ObservableCollection<SceneModel> _filteredScenes;

        private bool _isFilterActive;
        public bool IsFilterActive
        {
            get { return _isFilterActive; }
            set
            {
                _isFilterActive = value;
                OnPropertyChanged(nameof(IsFilterActive));
                RefreshCollection();
            }
        }

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
        private CampaignModel _filterSelectedCampaign;

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
            _isFilterActive = false;
            RefreshCollection();
            CloseCreateAlert();
            ClosePopup();
        }

        private void RefreshCollection()
        {
            if (IsFilterActive && FilterSelectedCampaign != null)
            {
                FilteredScenes = [.. Scenes
                    .Where(x => x.Campaign.Id == FilterSelectedCampaign.Id)
                    .ToObservableCollection()
                    .Sort((x, y) => string.Compare(x.Title, y.Title))];
            }
            else
            {
                FilteredScenes = Scenes.Sort((x, y) => string.Compare(x.Title, y.Title));
            }
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
                Scenes = [.. dataStore.Scene.GetAll().Result];
                RefreshCollection();
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
                Scenes = [.. dataStore.Scene.GetAll().Result];
                RefreshCollection();
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
            Scenes = [.. dataStore.Scene.GetAll().Result];
            RefreshCollection();
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
            _currentId = null;
            IsFilterActive = false;
            Scenes = [.. dataStore.Scene.GetAll().Result];
            RefreshCollection();
            Campaigns = [.. await dataStore.Campaign.GetAll()];
            if (Campaigns != null && Campaigns.Count > 0)
            {
                FilterSelectedCampaign = Campaigns[0];
                PopupSelectedCampaign = Campaigns[0];
            }
            else
            {
                FilterSelectedCampaign = null;
                PopupSelectedCampaign = null;
            }

            MoreMenusClosing();
            ClosePopup(); 
            CloseCreateAlert();
        }

        #endregion
    }
}
