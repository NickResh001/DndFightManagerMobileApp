using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SceneModel : BaseEntityModel
    {
        public string Title { get; set; }
        public CampaignModel Campaign { get; set; }

        public List<SceneSaveModel> SceneSaves { get; set; } = [];

        //=====================================================================

        private bool _isMoreMenuOpened = false;
        public bool IsMoreMenuOpened
        {
            get { return _isMoreMenuOpened; }
            set
            {
                _isMoreMenuOpened = value;
                OnPropertyChanged(nameof(IsMoreMenuOpened));
                OnPropertyChanged(nameof(IsMoreMenuClosed));
            }
        }
        public bool IsMoreMenuClosed
        {
            get
            {
                return !IsMoreMenuOpened;
            }
        }
    }
}
