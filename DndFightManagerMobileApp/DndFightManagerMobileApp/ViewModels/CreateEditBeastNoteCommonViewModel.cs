using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Controls.ViewModels;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteCommonViewModel : BaseViewModelHandNavigation
    {
        private BeastNoteModel _beastNote;
        #region ObservableProperties

        // Название моба
        [ObservableProperty]
        private string _beastTitle;

        // Мировоззрение
        [ObservableProperty]
        private ObservableCollection<AlignmentModel> _allAlignments;

        [ObservableProperty]
        private AlignmentModel _selectedAlignment;

        // Размер
        [ObservableProperty]
        private ObservableCollection<SizeModel> _allSizes;

        [ObservableProperty]
        private SizeModel _selectedSize;

        // Тип
        [ObservableProperty]
        private ObservableCollection<BeastTypeModel> _allBeastTypes;

        [ObservableProperty]
        private BeastTypeModel _selectedBeastType;

        // Языки
        [ObservableProperty]
        private CrudMultiSelectVM _languagesMS;

        // Места обитания
        [ObservableProperty]
        private CrudMultiSelectVM _habitatsMS;

        // Описание моба
        [ObservableProperty]
        private string _beastDescription;

        #endregion

        private ObservableCollection<LanguageModel> _allLanguages;
        private ObservableCollection<HabitatModel> _allHabitats;


        public CreateEditBeastNoteCommonViewModel() 
        {
            AllAlignments = dataStore.Alignment.GetAll().Result.ToObservableCollection().Sort((x, y) => string.Compare(x.Title, y.Title));
            AllSizes = new(dataStore.Size.GetAll().Result);
            AllBeastTypes = dataStore.BeastType.GetAll().Result.ToObservableCollection().Sort((x, y) => string.Compare(x.Title, y.Title));

            _allLanguages = new(dataStore.Language.GetAll().Result);
            _allHabitats = new(dataStore.Habitat.GetAll().Result);
            
        }

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;

                BeastTitle = _beastNote.Title;
                BeastDescription = _beastNote.Description;
                SelectedAlignment = AllAlignments.FirstOrDefault(x => x.Id == _beastNote.Alignment.Id);
                SelectedSize = AllSizes.FirstOrDefault(x => x.Id == _beastNote.Size.Id);
                SelectedBeastType = AllBeastTypes.FirstOrDefault(x => x.Id == _beastNote.BeastType.Id);

                ObservableCollection<MultiSelectCRUDHelper> languageItems = [];
                foreach (var language in _allLanguages)
                {
                    bool selected = false;
                    foreach (var languageList in _beastNote.LanguageList)
                    {
                        if (languageList.Language.Id == language.Id)
                        {
                            selected = true;
                            break;
                        }
                    }
                    languageItems.Add(new MultiSelectCRUDHelper(language, "", selected));
                }
                LanguagesMS = new CrudMultiSelectVM
                (
                    header: "Владение языками",
                    infoCommandParameter: "",
                    allItems: languageItems
                );

                ObservableCollection<MultiSelectCRUDHelper> habitatItems = [];
                foreach (var habitat in _allHabitats)
                {
                    bool selected = false;
                    foreach (var habitatList in _beastNote.HabitatList)
                    {
                        if (habitatList.Habitat.Id == habitat.Id)
                        {
                            selected = true;
                            break;
                        }
                    }
                    habitatItems.Add(new MultiSelectCRUDHelper(habitat, "", selected));
                }
                HabitatsMS = new CrudMultiSelectVM
                (
                    header: "Места обитания",
                    infoCommandParameter: "",
                    allItems: habitatItems
                );

            }
        }

        public override object OnNavigateFrom()
        {
            // Pack Changes
            //      BeastTitle
            //      Alignment
            //
            //      Size
            //      BeastType
            //      Languages
            //      Habitats
            //
            //

            _beastNote.Title = BeastTitle;
            _beastNote.Description = BeastDescription;
            _beastNote.Alignment = SelectedAlignment;
            _beastNote.Size = SelectedSize;
            _beastNote.BeastType = SelectedBeastType;

            List<LanguageListModel> languageList = [];
            foreach (var helper in LanguagesMS.SelectedItems) 
            {
                languageList.Add(new LanguageListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Language = helper.DirectoryModel as LanguageModel
                });
            }
            _beastNote.LanguageList = languageList;

            List<HabitatListModel> habitatList = [];
            foreach (var helper in HabitatsMS.SelectedItems)
            {
                habitatList.Add(new HabitatListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Habitat = helper.DirectoryModel as HabitatModel
                });
            }
            _beastNote.HabitatList = habitatList;

            return _beastNote;
        }

        #endregion


    }
}
