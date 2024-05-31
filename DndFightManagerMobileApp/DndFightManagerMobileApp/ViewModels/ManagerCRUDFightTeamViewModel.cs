using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class ManagerCRUDFightTeamViewModel : BaseViewModelHandNavigation
    {
        private string _sceneSaveId;

        #region ObservableProperties

        [ObservableProperty]
        private ObservableCollection<FightTeamModel> _fightTeams;

        [ObservableProperty]
        private string _popupTitle;

        [ObservableProperty]
        private bool _popupIsOpen;

        [ObservableProperty]
        private string _popupFightTeamTitle;
        #endregion

        private string _currentId;

        public ManagerCRUDFightTeamViewModel()
        {
            FightTeams = [.. dataStore.FightTeam.GetAllBySceneSaveId(_sceneSaveId).Result];
            _currentId = null;
            ClosePopup();
        }

        #region Create/Edit Popup
        [RelayCommand]
        private void CreateFightTeam()
        {
            _currentId = null;
            PopupTitle = "Добавление";
            OpenPopup();
        }

        [RelayCommand]
        private void EditFightTeam(string id)
        {
            _currentId = id;
            PopupTitle = "Редактирование";
            OpenPopup();
        }
        private void OpenPopup()
        {
            PopupFightTeamTitle = "";
            if (_currentId != null)
            {
                var setting = FightTeams.FirstOrDefault(x => x.Id == _currentId);
                if (setting != null)
                    PopupFightTeamTitle = setting.Title;
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
                var fightTeam = new FightTeamModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = PopupFightTeamTitle,
                    SceneSaveId = _sceneSaveId,
                };

                await dataStore.FightTeam.Create(fightTeam);
            }
            else
            {
                var fightTeam = FightTeams.FirstOrDefault(x => x.Id == _currentId);
                if (fightTeam != null)
                {
                    fightTeam.Title = PopupFightTeamTitle;
                    await dataStore.FightTeam.Update(fightTeam);
                }
            }

            FightTeams = [.. await dataStore.FightTeam.GetAllBySceneSaveId(_sceneSaveId)];
            ClosePopup();
        }
        #endregion

        #region Delete

        [RelayCommand]
        private async Task DeleteFightTeam(string id)
        {
            _currentId = id;
            await dataStore.FightTeam.Delete(_currentId);
            FightTeams = [.. await dataStore.FightTeam.GetAllBySceneSaveId(_sceneSaveId)];
        }
        #endregion

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            if (parameter is string sceneSaveId)
            {
                _sceneSaveId = sceneSaveId;
            }
            ClosePopup();
        }

        #endregion
    }
}
