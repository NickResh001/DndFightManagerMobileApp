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
    }
}
