using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Controls.Views;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.Controls.ViewModels
{
    public partial class CrudMultiSelectVM: ObservableObject
    {
        #region DependentBindings

        [ObservableProperty]
        private string _header;

        [ObservableProperty]
        private string _infoCommandParameter;

        [ObservableProperty]
        private bool _haveValue;

        [ObservableProperty]
        private bool _isEmptyMessangeVisible;
        #endregion

        #region IndependentBindings

        [ObservableProperty]
        private ObservableCollection<MultiSelectCRUDHelper> _itemsForPicker;

        [ObservableProperty]
        private ObservableCollection<MultiSelectCRUDHelper> _selectedItems;

        
        private MultiSelectCRUDHelper _selectedItem;
        public MultiSelectCRUDHelper SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null || value != _selectedItem) 
                    _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private bool _isCollectionExpanded;
        public bool IsCollectionExpanded
        {
            get { return _isCollectionExpanded; }
            set
            {
                _isCollectionExpanded = value;
                OnPropertyChanged(nameof(IsCollectionExpanded));
            }
        }

        #endregion

        [ObservableProperty]
        private ObservableCollection<MultiSelectCRUDHelper> _allItems;

        private Command RefreshCommand { get; set; }

        public CrudMultiSelectVM(
            string header, 
            string infoCommandParameter, 
            ObservableCollection<MultiSelectCRUDHelper> allItems,
            Command refreshCommand = null,
            bool haveValue = false)
        {
            Header = header;
            InfoCommandParameter = infoCommandParameter;
            _allItems = allItems ?? [];
            _haveValue = haveValue;
            this.RefreshCommand = refreshCommand;

            SelectedItems = new(_allItems.Where(x => x.Selected)); 
            ItemsForPicker = new(_allItems.Where(x => !x.Selected));

            SortItemsForPicker();
            ChangeEmtyMessangeVisibility();
        }
        public void SortItemsForPicker()
        {
            ItemsForPicker = ItemsForPicker.Sort((x, y) => string.Compare(x.Title, y.Title));
        }
        public void ChangeEmtyMessangeVisibility()
        {
            if ((SelectedItems == null || SelectedItems.Count == 0) && !IsEmptyMessangeVisible)
                IsEmptyMessangeVisible = true;
            else if (IsEmptyMessangeVisible)
                IsEmptyMessangeVisible = false;
        }
        
        [RelayCommand]
        private void Info(string key) => InfoProvider.Info(key);

        [RelayCommand]
        private void AddNote()
        {
            var note = SelectedItem;
            if (note != null)
            {
                ItemsForPicker.Remove(note);
                note.Selected = true;
                SelectedItems.Add(note);
                if (RefreshCommand != null)
                    RefreshCommand.Execute(null);
                ChangeEmtyMessangeVisibility();
            }
        }

        [RelayCommand]
        private void DeleteNote(string id)
        {
            var note = SelectedItems.FirstOrDefault(x => x.DirectoryModel.Id == id);
            if (note != null)
            {
                SelectedItems.Remove(note);
                note.Selected = false;
                if (RefreshCommand != null)
                    RefreshCommand.Execute(id);
                else
                    ItemsForPicker.Add(note);
                SortItemsForPicker();
                ChangeEmtyMessangeVisibility();
            }
        }

    }
}
