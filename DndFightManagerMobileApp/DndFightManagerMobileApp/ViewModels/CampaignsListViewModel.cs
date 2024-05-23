using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CampaignsListViewModel : BaseViewModelHandNavigation
    {
        #region ObservableProperties

        [ObservableProperty]
        private ObservableCollection<CampaignModel> _campaigns;

        [ObservableProperty]
        private string _popupTitle;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private string _popupCampaignTitle;

        [ObservableProperty]
        private ObservableCollection<SettingModel> _settings;

        [ObservableProperty]
        private SettingModel _popupSelectedSetting;

        [ObservableProperty]
        private bool _deleteAlertIsOpen;

        [ObservableProperty]
        private ObservableCollection<SceneModel> _scenes;

        #endregion

        private string _currentId;

        public CampaignsListViewModel()
        {
            Campaigns = [.. dataStore.Campaign.GetAll().Result];
            _currentId = null;
            ClosePopup();
        }
        private void OpenPopup()
        {
            PopupCampaignTitle = "";
            if (_currentId != null)
            {
                var campaign = Campaigns.FirstOrDefault(x => x.Id == _currentId);
                if (campaign != null)
                {
                    PopupCampaignTitle = campaign.Title;
                    PopupSelectedSetting = Settings.FirstOrDefault(x => x.Id == campaign.Setting.Id);
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
            if (_currentId == null && PopupSelectedSetting != null)
            {
                var campaign = new CampaignModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = PopupCampaignTitle,
                    Setting = PopupSelectedSetting,
                };

                success = await dataStore.Campaign.Create(campaign);
            }
            else
            {
                var campaign = Campaigns.FirstOrDefault(x => x.Id == _currentId);
                if (campaign != null && PopupSelectedSetting != null)
                {
                    campaign.Title = PopupCampaignTitle;
                    campaign.Setting = PopupSelectedSetting;
                    success = await dataStore.Campaign.Update(campaign);
                }
            }

            if (success)
            {
                Campaigns = [.. await dataStore.Campaign.GetAll()];
                ClosePopup();
            }
        }

        [RelayCommand]
        private void CreateCampaign()
        {
            _currentId = null;
            PopupTitle = "Добавление";
            OpenPopup();
        }

        [RelayCommand]
        private void EditCampaign(string id)
        {
            _currentId = id;
            PopupTitle = "Редактирование";
            OpenPopup();
        }


        #region DeleteAlert

        [RelayCommand]
        private async Task DeleteCampaign(string id)
        {
            _currentId = id;
            Scenes = [.. await dataStore.Scene.GetAllByCampaignId(id)];
            if (Scenes != null && Scenes.Count > 0)
            {
                OpenDeleteAlert();
            }
            else
            {
                await dataStore.Campaign.Delete(_currentId);
                Campaigns = [.. await dataStore.Campaign.GetAll()];
            }
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
            await dataStore.Campaign.Delete(_currentId);
            Campaigns = [.. await dataStore.Campaign.GetAll()];
            CloseDeleteAlert();
        }
        #endregion



        #region Navigation

        public override async void OnNavigateTo(object parameter)
        {
            Campaigns = [.. dataStore.Campaign.GetAll().Result];
            _currentId = null;
            Settings = [.. await dataStore.Setting.GetAll()];
            if (Settings != null && Settings.Count > 0)
                PopupSelectedSetting = Settings[0];
            else
                PopupSelectedSetting = null;
            ClosePopup();
        }

        #endregion
    }
}
