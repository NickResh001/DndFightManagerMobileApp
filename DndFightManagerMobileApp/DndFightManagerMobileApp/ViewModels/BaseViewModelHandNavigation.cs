using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public abstract class BaseViewModelHandNavigation : BaseViewModel
    {
        public abstract void OnNavigate(object parameter);
    }
}
