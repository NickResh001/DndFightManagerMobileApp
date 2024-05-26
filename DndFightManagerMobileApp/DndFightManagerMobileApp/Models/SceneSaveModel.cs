using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SceneSaveModel : BaseEntityModel
    {
        public string Title { get; set; } = "Пустое сохранение";
        public DateTime LastEditingDate { get; set; } = DateTime.Now;
        public string CurrentBeastInitiative { get; set; }
        public int RoundNumber { get; set; } = 1;
        public SceneModel Scene { get; set; }

        //=======================


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
