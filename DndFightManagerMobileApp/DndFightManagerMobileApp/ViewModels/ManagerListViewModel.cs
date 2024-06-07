using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class ActionResourceLocalHelper : ObservableObject
    {
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private bool _isAvailable;
    }
    public partial class ManagerListViewModel : BaseViewModel, IQueryAttributable
    {
        #region Incoming Params
        private string _sceneSaveId;
        private NavigationCondition _navigationCondition;
        #endregion

        private SceneSaveModel _currentSceneSave;
        private FightTeamModel _emptyFightTeam;

        #region Observable Props

        [ObservableProperty]
        private ObservableCollection<ManagedBeastHelper> _managedBeasts;

        [ObservableProperty]
        private ManagedBeastHelper _selectedManagedBeast;

        [ObservableProperty]
        private int _roundNumber;

        [ObservableProperty]
        private int _turnNumber;

        [ObservableProperty]
        private bool _isBurgerMenuOpened;

        [ObservableProperty]
        private bool _isAdditionalMenuOpened;

        [ObservableProperty]
        private ObservableCollection<ActionResourceLocalHelper> _actionResources;

        [ObservableProperty]
        private bool _isEditMenuOpened;

        [ObservableProperty]
        private ObservableCollection<FightTeamModel> _fightTeams;

        [ObservableProperty]
        private FightTeamModel _selectedFightTeam;

        #endregion

        public ManagerListViewModel() 
        {
            EmptyInitialize();
            _emptyFightTeam = new FightTeamModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Нет команды"
            };
            IsScreensMenuOpen = false;
        }
        private async Task FightTeamsRefresh()
        {
            FightTeams = [.. await dataStore.FightTeam.GetAllBySceneSaveId(_sceneSaveId)];
            FightTeams.Insert(0, _emptyFightTeam);
        }
        private void EmptyInitialize()
        {
            CloseAllMenus();
        }
        private void CloseAllMenus()
        {
            IsBurgerMenuOpened = false;
            IsAdditionalMenuOpened = false;
            IsEditMenuOpened = false;
        }

        #region Burger Menu

        [RelayCommand]
        private async Task OpenBurgerMenu()
        {
            CloseAllMenus();
            IsBurgerMenuOpened = true;
        }

        [RelayCommand]
        private async Task CloseBurgerMenu()
        {
            CloseAllMenus();
        }

        [RelayCommand]
        private async Task NavigateBackTo()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task NavigateBackToScenes()
        {
            await Shell.Current.GoToAsync("../..");
        }

        [RelayCommand]
        private async Task NavigateBackToMainMenu()
        {
            await Shell.Current.GoToAsync("../../..");
        }
        #endregion

        #region Bottom Menu
        [RelayCommand]
        private void NextTurn()
        {
            ManagedBeasts[TurnNumber].IsSelected = false;
            int tempTurnNumber = TurnNumber;

            do
            {
                TurnNumber++;
                if (TurnNumber == ManagedBeasts.Count)
                {
                    RoundNumber++;
                    TurnNumber = 0;
                }

                if (TurnNumber == tempTurnNumber)
                {
                    ManagedBeasts[TurnNumber].IsSuprised = false;
                    ManagedBeasts[TurnNumber].IsKilled = false;
                }

            } while (ManagedBeasts[TurnNumber].IsKilled || ManagedBeasts[TurnNumber].IsSuprised);
            
            ManagedBeasts[TurnNumber].IsSelected = true;
        }

        [RelayCommand]
        private async Task NavigateToManagerCRUD()
        {
            string sceneSaveId = NPConv.ObjectToPairKeyValue(_sceneSaveId, nameof(sceneSaveId));
            await Shell.Current.GoToAsync($"{nameof(ManagerCRUDMainPage)}?{sceneSaveId}");
        }
        #endregion

        #region Additional game menu
        [RelayCommand]
        private void OpenAdditionalMenu()
        {
            SelectedManagedBeast = ManagedBeasts.FirstOrDefault(x => x.IsSelected);
            if (SelectedManagedBeast != null)
            {
                List<string> titles = ["Осн", "Бон", "Своб", "Пас", "Реак", "Лег", "Лог"];
                List<bool> availables = [];
                if (SelectedManagedBeast.IsLair)
                    availables = [false, false, false, false, false, false, true];
                if (SelectedManagedBeast.IsPlayer)
                    availables = [true, true, true, true, true, false, false];
                if (SelectedManagedBeast.IsBeast)
                    availables = [true, true, true, true, true, true, true];

                ActionResources = [];
                for (int i = 0; i < titles.Count; i++)
                {
                    ActionResources.Add(new ActionResourceLocalHelper
                    { 
                        Title = titles[i], 
                        IsAvailable = availables[i]
                    });
                }

                IsAdditionalMenuOpened = true;
            }
        }
        [RelayCommand]
        private void CloseAdditionalMenu()
        {
            CloseAllMenus();
        }
        #endregion

        #region EditMenu

        [RelayCommand]
        private void OpenEditMenu()
        {
            CloseAllMenus();
            IsEditMenuOpened = true;
        }

        [RelayCommand]
        private void CloseEditMenu()
        {
            CloseAllMenus();
        }

        [RelayCommand]
        private void EditBeast(string id)
        {
            SelectedManagedBeast = ManagedBeasts.FirstOrDefault(x => x.Id == id);
            if (SelectedManagedBeast != null)
            {
                SelectedFightTeam = FightTeams.FirstOrDefault(x => x.Id == SelectedManagedBeast.FightTeam.Id);
                OpenEditMenu();
            }
        }
        
        [RelayCommand]
        private void ConfirmEditing()
        {
            //bool success = false;
            //var beast = ManagedBeasts.FirstOrDefault(x => x.Id == _currentId);
            //if (beast != null && PopupSelectedSetting != null)
            //{
            //    beast.Title = PopupCampaignTitle;
            //    beast.Setting = PopupSelectedSetting;
            //    success = await dataStore.Campaign.Update(beast);
            //}
            

            //if (success)
            //{
            //    Campaigns = [.. await dataStore.Campaign.GetAll()];
            //    ClosePopup();
            //}
        }
        
        #endregion

        #region Navigation
        private async Task ArrivalInitialize()
        {
            if (string.IsNullOrEmpty(_sceneSaveId))
            {
                _navigationCondition = NavigationCondition.Nothing;
            }

            CloseAllMenus();

            switch (_navigationCondition)
            {
                case NavigationCondition.Edit:
                    await ArrivalFromSceneSaveList();
                    break;
                case NavigationCondition.Returning:
                    await ArrivalFromBeastPage();
                    break;
                case NavigationCondition.Refreshing:
                    await ArrivalFromSceneSaveList();
                    break;
                case NavigationCondition.Nothing:
                    break;
                default:
                    break;
            }
        }
        private async Task ArrivalFromSceneSaveList()
        {
            _currentSceneSave = await dataStore.SceneSave.GetById(_sceneSaveId);
            RoundNumber = _currentSceneSave.RoundNumber;
            ManagedBeasts = [];
            ActionResources = [];
            FightTeamsRefresh();
            List<BeastModel> beasts = [.. await dataStore.Beast.GetAll()];

            foreach (var beast in beasts)
            {
                ManagedBeastHelperType type = ManagedBeastHelperType.Beast;
                if (beast.IsPlayer)
                    type = ManagedBeastHelperType.Player;

                ManagedBeastHelper beastHelper = new ManagedBeastHelper(beast, type);
                if (beastHelper.FightTeam == null)
                    beastHelper.FightTeam = _emptyFightTeam;
                ManagedBeasts.Add(beastHelper);

                if (beast.HaveLair)
                {
                    var someLair = new ManagedBeastHelper(beast, ManagedBeastHelperType.Lair);
                    if (someLair.FightTeam == null)
                        someLair.FightTeam = _emptyFightTeam;
                    ManagedBeasts.Add(someLair);
                }
            }

            if (ManagedBeasts.Count > 0)
            {
                ManagedBeasts[0].IsSelected = true;
            }

            for (int i = 0; i < ManagedBeasts.Count; i++) 
            {
                if (ManagedBeasts[i].IsSelected)
                {
                    TurnNumber = i;
                    break;
                }
            }
        }
        private async Task ArrivalFromBeastPage()
        {

        }
        private async Task ArrivalFromManagerCRUD()
        {

        }
        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string sceneSaveIdParam = "sceneSaveId";
            string navigationConditionParam = "navigationCondition";

            _sceneSaveId = null;
            _navigationCondition = NavigationCondition.Nothing;

            if (query.ContainsKey(sceneSaveIdParam))
                _sceneSaveId = NPConv.ObjectFromUrl<string>(query[sceneSaveIdParam]);
            if (query.ContainsKey(navigationConditionParam))
                _navigationCondition = NPConv.ObjectFromUrl<NavigationCondition>(query[navigationConditionParam]);

            await ArrivalInitialize();
        }

        #endregion

        #region ScreensMenu

        [ObservableProperty]
        private bool _isScreensMenuOpen;

        [RelayCommand]
        private async Task NavigateToScreen(string screenName)
        {
            await Shell.Current.GoToAsync($"{screenName}");
        }

        [RelayCommand]
        private async Task OpenScreensMenu()
        {
            IsScreensMenuOpen = true;
        }
        [RelayCommand]
        private async Task CloseScreensMenu()
        {
            IsScreensMenuOpen = false;
        }

        #endregion
    }
}
