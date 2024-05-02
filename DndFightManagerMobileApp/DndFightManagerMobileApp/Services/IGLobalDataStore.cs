using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
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
        IAbilityDataStore Ability { get; }
        IBaseHardoceDirectoryDataStore<AlignmentModel> Alignment { get; }
        IDataStore<BeastNoteModel> BeastNote { get; }
        IBaseHardoceDirectoryDataStore<BeastTypeModel> BeastType { get; }
        IBaseHardoceDirectoryDataStore<ConditionModel> Condition { get; }
        IBaseHardoceDirectoryDataStore<DamageTendencyTypeModel> DamageTendencyType { get; }
        IBaseHardoceDirectoryDataStore<DamageTypeModel> DamageType { get; }
        IBaseHardoceDirectoryDataStore<HabitatModel> Habitat { get; }
        IBaseHardoceDirectoryDataStore<LanguageModel> Language { get; }
        IBaseHardoceDirectoryDataStore<SenseModel> Sense { get; }
        IBaseHardoceDirectoryDataStore<SizeModel> Size { get; }
        ISkillDataStore Skill { get; }
        IBaseHardoceDirectoryDataStore<SpeedModel> Speed { get; }

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
