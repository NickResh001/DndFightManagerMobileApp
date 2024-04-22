using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Services
{
    /// <summary>
    /// An interface that combines DataStores of one data context and encapsulates their functionality (similar to the UnitOfWork pattern)
    /// </summary>
    public interface IGLobalDataStore
    {
        IDataStore<AbilityModel> Ability { get; }
        IDataStore<AlignmentModel> Alignment { get; }
        IDataStore<BeastNoteModel> BeastNote { get; }
        IDataStore<BeastTypeModel> BeastType { get; }
        IDataStore<ConditionModel> Condition { get; }
        IDataStore<DamageTendencyTypeModel> DamageTendencyType { get; }
        IDataStore<DamageTypeModel> DamageType { get; }
        IDataStore<HabitatModel> HabitatType { get; }
        IDataStore<SenseModel> Sense { get; }
        IDataStore<SizeModel> Size { get; }
        IDataStore<SkillModel> Skill { get; }
        IDataStore<SpeedModel> Speed { get; }

        //IDataStore<BeastModel> Beast { get; }
        //IDataStore<SceneModel> Scene { get; }
        //IDataStore<SceneSaveModel> SceneSave { get; }
        //IDataStore<CampaignModel> Campaign { get; }
        //IDataStore<SettingModel> Setting { get; }
        //IDataStore<UserModel> User { get; }
        //IDataStore<FightTeamModel> FightTeam { get; }

        //IDataStore<TimeMeasureModel> TimeMeasure { get; }
        //IDataStore<CooldownTypeModel> CooldownType { get; }
        //IDataStore<ActionResourceModel> CooldownType { get; }
    }
}
