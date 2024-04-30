using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Controls.ViewModels;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteDamageViewModel : BaseViewModelHandNavigation
    {
        private BeastNoteModel _beastNote;

        #region ObservableProperties

        [ObservableProperty]
        private CrudMultiSelectVM _damageVulnerabilityMS;

        [ObservableProperty]
        private CrudMultiSelectVM _damageResistanceMS;

        [ObservableProperty]
        private CrudMultiSelectVM _damageImmunityMS;

        [ObservableProperty]
        private CrudMultiSelectVM _conditionImmunityMS;

        #endregion

        private ObservableCollection<DamageTypeModel> _allDamageTypes;
        private ObservableCollection<ConditionModel> _allConditions;

        public CreateEditBeastNoteDamageViewModel()
        {
            _allConditions = new(dataStore.Condition.GetAll().Result);
            _allDamageTypes = new(dataStore.DamageType.GetAll().Result);
        }
        private void RefreshCollectionsOnView(string damageTypeId)
        {
            if (string.IsNullOrEmpty(damageTypeId))
            {
                List<MultiSelectCRUDHelper> invalidItemsList = [];
                invalidItemsList.AddRange(DamageImmunityMS.SelectedItems);
                invalidItemsList.AddRange(DamageResistanceMS.SelectedItems);
                invalidItemsList.AddRange(DamageVulnerabilityMS.SelectedItems);
                foreach (var item in invalidItemsList)
                {
                    DamageImmunityMS.ItemsForPicker.Remove(item);
                    DamageResistanceMS.ItemsForPicker.Remove(item);
                    DamageVulnerabilityMS.ItemsForPicker.Remove(item);
                }
            }
            else
            {
                DamageTypeModel damageType = _allDamageTypes.FirstOrDefault(x => x.Id == damageTypeId);
                if (damageType != null)
                {
                    var item = new MultiSelectCRUDHelper(damageType);
                    DamageImmunityMS.ItemsForPicker.Add(item);
                    DamageResistanceMS.ItemsForPicker.Add(item);
                    DamageVulnerabilityMS.ItemsForPicker.Add(item);

                    DamageImmunityMS.SortItemsForPicker();
                    DamageResistanceMS.SortItemsForPicker();
                    DamageVulnerabilityMS.SortItemsForPicker();
                }
            }

        }

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;

                ObservableCollection<MultiSelectCRUDHelper> conditionImmunityItems = [];
                foreach (var condition in _allConditions)
                {
                    bool selected = false;
                    foreach (var conditionList in _beastNote.ConditionImmunitiesList)
                    {
                        if (condition.Id == conditionList.Condition.Id)
                        {
                            selected = true; 
                            break;
                        }
                    }
                    conditionImmunityItems.Add(new MultiSelectCRUDHelper(condition, "", selected));
                }
                ConditionImmunityMS = new CrudMultiSelectVM
                (
                    header: "Иммунитет к состояниям",
                    infoCommandParameter: "",
                    allItems: conditionImmunityItems
                );

                List<MultiSelectCRUDHelper> allowedDamageTypes =
                    _allDamageTypes.Select((x) => new MultiSelectCRUDHelper(x)).ToList();

                ObservableCollection<MultiSelectCRUDHelper> damageResistItems = [];
                ObservableCollection<MultiSelectCRUDHelper> damageVulnItems = [];
                ObservableCollection<MultiSelectCRUDHelper> damageImmunItems = [];
                foreach (var damageType in _allDamageTypes)
                {
                    foreach (var damageTypeList in _beastNote.DamageTendencyList)
                    {
                        // если в списке указан такой тип урона
                        if (damageType.Id == damageTypeList.DamageType.Id)
                        {
                            // удалим тип из доступных
                            foreach(var typeToDelete in allowedDamageTypes)
                            {
                                if (typeToDelete.Title == damageType.Title)
                                {
                                    allowedDamageTypes.Remove(typeToDelete);
                                    break;
                                }
                            }

                            // добавим тип в нужную коллекцию как выбранный
                            switch (damageTypeList.DamageTendencyType.Title)
                            {
                                case "Сопротивление":
                                    damageResistItems.Add(new MultiSelectCRUDHelper(damageType, "", true));
                                    break;
                                case "Уязвимость":
                                    damageVulnItems.Add(new MultiSelectCRUDHelper(damageType, "", true));
                                    break;
                                case "Иммунитет":
                                    damageImmunItems.Add(new MultiSelectCRUDHelper(damageType, "", true));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                
                DamageResistanceMS = new CrudMultiSelectVM
                (
                    header: "Сопротивление урону",
                    infoCommandParameter: "",
                    allItems: [.. allowedDamageTypes, .. damageResistItems],
                    refreshCommand: new Command<string>(RefreshCollectionsOnView)
                );
                DamageVulnerabilityMS = new CrudMultiSelectVM
                (
                    header: "Уязвимость к урону",
                    infoCommandParameter: "",
                    allItems: [.. allowedDamageTypes, .. damageVulnItems],
                    refreshCommand: new Command<string>(RefreshCollectionsOnView)
                );
                DamageImmunityMS = new CrudMultiSelectVM
                (
                    header: "Иммунитет к урону",
                    infoCommandParameter: "",
                    allItems: [.. allowedDamageTypes, .. damageImmunItems],
                    refreshCommand: new Command<string>(RefreshCollectionsOnView)
                );
            }
        }

        public override object OnNavigateFrom()
        {
            // Pack Changes
            //      ConditionImmunitites
            //      DamageResistance
            //      DamageVulnerability
            //      DamageImmunities

            List<ConditionImmunitiesListModel> conditionImmunitiesList = [];
            foreach (var helper in ConditionImmunityMS.SelectedItems)
            {
                conditionImmunitiesList.Add(new ConditionImmunitiesListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Condition = helper.DirectoryModel as ConditionModel
                });
            }
            _beastNote.ConditionImmunitiesList = conditionImmunitiesList;

            List<DamageTendencyModel> damageTendency = [];
            var resistance = dataStore.DamageTendencyType.GetByTitle("Сопротивление").Result;
            var vulnerable = dataStore.DamageTendencyType.GetByTitle("Уязвимость").Result;
            var immunity = dataStore.DamageTendencyType.GetByTitle("Иммунитет").Result;
            foreach (var helper in DamageResistanceMS.SelectedItems)
            {
                damageTendency.Add(new DamageTendencyModel
                {
                    Id = Guid.NewGuid().ToString(),
                    DamageTendencyType = resistance,
                    DamageType = helper.DirectoryModel as DamageTypeModel
                });
            }
            foreach (var helper in DamageVulnerabilityMS.SelectedItems)
            {
                damageTendency.Add(new DamageTendencyModel
                {
                    Id = Guid.NewGuid().ToString(),
                    DamageTendencyType = vulnerable,
                    DamageType = helper.DirectoryModel as DamageTypeModel
                });
            }
            foreach (var helper in DamageImmunityMS.SelectedItems)
            {
                damageTendency.Add(new DamageTendencyModel
                {
                    Id = Guid.NewGuid().ToString(),
                    DamageTendencyType = immunity,
                    DamageType = helper.DirectoryModel as DamageTypeModel
                });
            }
            _beastNote.DamageTendencyList = damageTendency;

            return _beastNote;
        }

        #endregion
    }
}
