using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public abstract class BaseViewModelHandNavigation : BaseViewModel
    {
        public virtual void OnNavigateTo(object parameter) { }
        public virtual object OnNavigateFrom() { return null; }
    }
}
