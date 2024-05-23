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
    public partial class SettingsListViewModel : BaseViewModelHandNavigation
    {
        #region ObservableProperties

        [ObservableProperty]
        private ObservableCollection<SettingModel> _settings;

        [ObservableProperty]
        private string _popupTitle;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private string _popupSettingTitle;

        [ObservableProperty]
        private bool _deleteAlertIsOpen;

        [ObservableProperty]
        private ObservableCollection<CampaignModel> _campaigns;
        #endregion

        private string _currentId;

        public SettingsListViewModel()
        {
            Settings = [.. dataStore.Setting.GetAll(false).Result];
            _currentId = null;
            ClosePopup();
        }

        #region DeleteAlert

        [RelayCommand]
        private async Task DeleteSetting(string id)
        {
            _currentId = id;
            Campaigns = [.. await dataStore.Campaign.GetAllBySettingId(id)];
            if (Campaigns != null && Campaigns.Count > 0)
            {
                OpenDeleteAlert();
            }
            else
            {
                await dataStore.Setting.Delete(_currentId);
                Settings = [.. await dataStore.Setting.GetAll(false)];
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
        private async Task ConfirmDeleting(string isCasсading)
        {
            if (isCasсading.ToLower() == "false")
            {
                CampaignModel[] campaigns = [ .. await dataStore.Campaign.GetAllBySettingId(_currentId)];
                SettingModel authorSetting = await dataStore.Setting.GetByTitle("Авторский");
                for (int i = 0; i < campaigns.Length; i++)
                {
                    campaigns[i].Setting = authorSetting; 
                    await dataStore.Campaign.Update(campaigns[i]);
                }
            }

            await dataStore.Setting.Delete(_currentId);
            Settings = [.. await dataStore.Setting.GetAll(false)];

            CloseDeleteAlert();
        }
        #endregion

        #region Create/Edit Popup
        [RelayCommand]
        private void CreateSetting()
        {
            _currentId = null;
            PopupTitle = "Добавление";
            OpenPopup();
        }

        [RelayCommand]
        private void EditSetting(string id)
        {
            _currentId = id;
            PopupTitle = "Редактирование";
            OpenPopup();
        }
        private void OpenPopup()
        {
            PopupSettingTitle = "";
            if (_currentId != null)
            {
                var setting = Settings.FirstOrDefault(x => x.Id == _currentId);
                if (setting != null)
                    PopupSettingTitle = setting.Title;
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
            if (_currentId == null)
            {
                var setting = new SettingModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = PopupSettingTitle,
                };

                await dataStore.Setting.Create(setting);
            }
            else
            {
                var setting = Settings.FirstOrDefault(x => x.Id == _currentId);
                if (setting != null)
                {
                    setting.Title = PopupSettingTitle;
                    await dataStore.Setting.Update(setting);
                }
            }

            Settings = [.. await dataStore.Setting.GetAll(false)];
            ClosePopup();
        }
        #endregion
        
        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            CloseDeleteAlert();
            ClosePopup();
        }

        #endregion
    }
}
