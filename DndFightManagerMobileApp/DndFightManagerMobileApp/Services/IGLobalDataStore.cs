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

        IDataStore<ActionModel> Action { get; }
        IDataStore <ActionThrowModel> ActionThrow { get; }
        IBaseHardoceDirectoryDataStore<TimeMeasureModel> TimeMeasure { get; }
        IBaseHardoceDirectoryDataStore<ActionResourceModel> ActionResource { get; }
        IBaseHardoceDirectoryDataStore<CooldownTypeModel> CooldownType { get; }


        ISettingDataStore Setting { get; }
        ICampaignDataStore Campaign { get; }
        ISceneDataStore Scene { get; }
        ISceneSaveDataStore SceneSave { get; }
        IDataStore<BeastModel> Beast { get; }
        IBaseHardoceDirectoryDataStore<FightTeamModel> FightTeam { get; }

        //IDataStore<UserModel> User { get; }

    }
}
