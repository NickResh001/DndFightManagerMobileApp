using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteResultViewModel : BaseViewModelHandNavigation
    {
        #region ObservableProperties

        [ObservableProperty]
        private BeastNoteModel _bastNote;

        #endregion

        public CreateEditBeastNoteResultViewModel()
        {

        }

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            base.OnNavigateTo(parameter);
        }

        public override object OnNavigateFrom()
        {
            return base.OnNavigateFrom();
        }

        #endregion
    }
}
