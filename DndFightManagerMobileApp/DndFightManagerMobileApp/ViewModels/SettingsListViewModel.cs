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

        #endregion

        private string _currentId;

        public SettingsListViewModel()
        {
            Settings = [.. dataStore.Setting.GetAll().Result];
            _currentId = null;
            ClosePopup();
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

            Settings = [.. await dataStore.Setting.GetAll()]; 
            ClosePopup();
        }

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

        [RelayCommand]
        private async Task DeleteSetting(string id)
        {
            await dataStore.Setting.Delete(id);
            Settings = [.. await dataStore.Setting.GetAll()];
        }

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            ClosePopup();
        }

        #endregion
    }
}
