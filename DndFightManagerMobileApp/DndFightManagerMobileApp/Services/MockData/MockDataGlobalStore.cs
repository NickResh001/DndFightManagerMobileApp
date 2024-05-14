using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class MockDataGlobalStore : IGLobalDataStore
    {
        public IAbilityDataStore Ability { get; private set; }
        public IBaseHardoceDirectoryDataStore<AlignmentModel> Alignment { get; private set; }
        public IDataStore<BeastNoteModel> BeastNote { get; private set; }
        public IBaseHardoceDirectoryDataStore<BeastTypeModel> BeastType { get; private set; }
        public IBaseHardoceDirectoryDataStore<ConditionModel> Condition { get; private set; }
        public IBaseHardoceDirectoryDataStore<DamageTendencyTypeModel> DamageTendencyType { get; private set; }
        public IBaseHardoceDirectoryDataStore<DamageTypeModel> DamageType { get; private set; }
        public IBaseHardoceDirectoryDataStore<HabitatModel> Habitat { get; private set; }
        public IBaseHardoceDirectoryDataStore<LanguageModel> Language { get; private set; }
        public IBaseHardoceDirectoryDataStore<SenseModel> Sense { get; private set; }
        public IBaseHardoceDirectoryDataStore<SizeModel> Size { get; private set; }
        public ISkillDataStore Skill { get; private set; }
        public IBaseHardoceDirectoryDataStore<SpeedModel> Speed { get; private set; }

        public IDataStore<ActionModel> Action { get; private set; }
        public IDataStore<ActionThrowModel> ActionThrow { get; private set; }
        public IBaseHardoceDirectoryDataStore<TimeMeasureModel> TimeMeasure { get; private set; }
        public IBaseHardoceDirectoryDataStore<ActionResourceModel> ActionResource { get; private set; }
        public IBaseHardoceDirectoryDataStore<CooldownTypeModel> CooldownType { get; private set; }

        public MockDataGlobalStore()
        {
            Ability = new AbilityDataStore();
            Alignment = new AlignmentDataStore();
            BeastNote = new BaseMockDataStore<BeastNoteModel>();
            BeastType = new BeastTypeDataStore();
            Condition = new ConditionDataStore();
            DamageTendencyType = new DamageTendencyTypeDataStore();
            DamageType = new DamageTypeDataStore();
            Habitat = new HabitatDataStore();
            Language = new LanguageDataStore();
            Sense = new SenseDataStore();
            Size = new SizeDataStore();
            Skill = new SkillDataStore();
            Speed = new SpeedDataStore();

            Action = new BaseMockDataStore<ActionModel>();
            ActionThrow = new BaseMockDataStore<ActionThrowModel>();
            TimeMeasure = new BaseHardDirMockDataStore<TimeMeasureModel>();
            ActionResource = new BaseHardDirMockDataStore<ActionResourceModel>();
            CooldownType = new BaseHardDirMockDataStore<CooldownTypeModel>();

            InitializeData();
        }

        private async void InitializeData()
        {
            #region Alignment

            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = -1,
                Law = -1,
                Title = $"{AlignmentModel.GetLaw(-1)}-{AlignmentModel.GetGoodness(-1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 0,
                Law = -1,
                Title = $"{AlignmentModel.GetLaw(-1)}-{AlignmentModel.GetGoodness(0)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 1,
                Law = -1,
                Title = $"{AlignmentModel.GetLaw(-1)}-{AlignmentModel.GetGoodness(1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = -1,
                Law = 0,
                Title = $"{AlignmentModel.GetLaw(0)}-{AlignmentModel.GetGoodness(-1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 0,
                Law = 0,
                Title = $"{AlignmentModel.GetLaw(0)}-{AlignmentModel.GetGoodness(0)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 1,
                Law = 0,
                Title = $"{AlignmentModel.GetLaw(0)}-{AlignmentModel.GetGoodness(1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = -1,
                Law = 1,
                Title = $"{AlignmentModel.GetLaw(1)}-{AlignmentModel.GetGoodness(-1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 0,
                Law = 1,
                Title = $"{AlignmentModel.GetLaw(1)}-{AlignmentModel.GetGoodness(0)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 1,
                Law = 1,
                Title = $"{AlignmentModel.GetLaw(1)}-{AlignmentModel.GetGoodness(1)}"
            });
            await Alignment.Create(new AlignmentModel
            {
                Id = Guid.NewGuid().ToString(),
                Goodness = 0,
                Law = 0,
                Title = AlignmentModel.GetDefaultTitle()
            });

            #endregion
            #region BeastType

            await BeastType.Create(new BeastTypeModel 
            { 
                Id = Guid.NewGuid().ToString(), 
                Title = "Абберация"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Зверь"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Небожитель"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Конструкт"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Дракон"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Элементаль"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Фея"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Исчадие"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Великан"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Гуманоид"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Монстр"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Растение"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Нежить"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Слизь"
            });
            await BeastType.Create(new BeastTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Стая крошечных зверей"
            });

            #endregion
            #region Condition

            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Бессознательный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Испуганный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Истощенный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Невидимый"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Оглохший"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Окаменевший"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Опутанный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Ослепленный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Отравленный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Очарованный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Ошеломленный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Парализованный"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Сбитый с ног"
            });
            await Condition.Create(new ConditionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Схваченный"
            });

            #endregion
            #region DamageTendencyType

            await DamageTendencyType.Create(new DamageTendencyTypeModel 
            { 
                Id = Guid.NewGuid().ToString(),
                Title = "Сопротивление"
            });
            await DamageTendencyType.Create(new DamageTendencyTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Уязвимость"
            });
            await DamageTendencyType.Create(new DamageTendencyTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Иммунитет"
            });

            #endregion
            #region DamageType

            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Колющий"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Рубящий"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Дробящий"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Кислотный"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Холодом"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Огнем"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Силовым полем"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Электричеством"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Некротической энергией"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Ядом"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Психический"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Излучением"
            });
            await DamageType.Create(new DamageTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Звуком"
            });

            #endregion
            #region Habitat

            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Полярная тундра"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Побережье"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Под водой"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Равнина/луг"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Подземье"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Город"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Деревня"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Руины"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Подземелья"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Лес"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Холмы"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Горы"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Болото"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Пустыня"
            });
            await Habitat.Create(new HabitatModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Тропики"
            });

            #endregion
            #region Language
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Великаний"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Гномий"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Гоблинский"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Дварфийский"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Общий"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Орочий"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Полуросликов"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Эльфийский"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Бездны"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Глубинная Речь"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Драконий"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Инфернальный"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Небесный"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Первичный"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Подземный"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Сильван"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Воровской жаргон"
            });
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Друидический язык"
            });
            #endregion
            #region Sense

            await Sense.Create(new SenseModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Истинное зрение"
            });
            await Sense.Create(new SenseModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Слепое зрение"
            });
            await Sense.Create(new SenseModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Темное зрение"
            });
            await Sense.Create(new SenseModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Чувство вибрации"
            });

            #endregion
            #region Size

            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Крошечный"
            });
            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Маленький"
            });
            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Средний"
            });
            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Большой"
            });
            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Огромный"
            });
            await Size.Create(new SizeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Громадный"
            });

            #endregion
            #region Ability and Skill
            {
                AbilityModel strenght = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Сила"
                };
                AbilityModel dexterity = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Ловкость"
                };
                AbilityModel сonstitution = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Телосложение"
                };
                AbilityModel intelligence = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Интеллект"
                };
                AbilityModel wisdom = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Мудрость"
                };
                AbilityModel charisma = new AbilityModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Харизма"
                };

                await Ability.Create(strenght);
                await Ability.Create(dexterity);
                await Ability.Create(сonstitution);
                await Ability.Create(intelligence);
                await Ability.Create(wisdom);
                await Ability.Create(charisma);


                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = strenght,
                    Title = "Атлетика"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = dexterity,
                    Title = "Акробатика"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = dexterity,
                    Title = "Ловкость рук"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = dexterity,
                    Title = "Скрытность"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = intelligence,
                    Title = "Анализ"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = intelligence,
                    Title = "История"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = intelligence,
                    Title = "Магия"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = intelligence,
                    Title = "Природа"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = intelligence,
                    Title = "Религия"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = wisdom,
                    Title = "Внимательность"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = wisdom,
                    Title = "Выживание"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = wisdom,
                    Title = "Медицина"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = wisdom,
                    Title = "Проницательность"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = wisdom,
                    Title = "Уход за животными"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = charisma,
                    Title = "Выступление"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = charisma,
                    Title = "Запугивание"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = charisma,
                    Title = "Обман"
                });
                await Skill.Create(new SkillModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = charisma,
                    Title = "Убеждение"
                });
            }



            #endregion
            #region Speed

            await Speed.Create(new SpeedModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Обычная"
            });
            await Speed.Create(new SpeedModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Летая"
            });
            await Speed.Create(new SpeedModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Плавая"
            });
            await Speed.Create(new SpeedModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Копая"
            });
            await Speed.Create(new SpeedModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Лазая"
            });

            #endregion
            #region TimeMeasure

            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Минута"
            });
            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Час"
            });
            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Сутки"
            });
            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Неделя"
            });
            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Раунд"
            });
            await TimeMeasure.Create(new TimeMeasureModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Ход"
            });

            #endregion
            #region ActionResource

            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Основное"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Бонусное"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Свободное"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Пассивное"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Реакцией"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Легендарное"
            });
            await ActionResource.Create(new ActionResourceModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Логова"
            });

            #endregion
            #region CooldownType

            await CooldownType.Create(new CooldownTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Нет"
            });
            await CooldownType.Create(new CooldownTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Ячейки заклинаний"
            });
            await CooldownType.Create(new CooldownTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Перезарядка"
            });
            await CooldownType.Create(new CooldownTypeModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Время"
            });

            #endregion
            
            #region BeastNote
            {
                var AbilityStore = Ability as AbilityDataStore;
                var AlignmentStore = Alignment as AlignmentDataStore;
                var BestTypeStore = BeastType as BeastTypeDataStore;
                var ConditionStore = Condition as ConditionDataStore;
                var DamageTendencyTypeStore = DamageTendencyType as DamageTendencyTypeDataStore;
                var DamageTypeStore = DamageType as DamageTypeDataStore;
                var HabitatTypeStore = Habitat as HabitatDataStore;
                var SenseStore = Sense as SenseDataStore;
                var SizeStore = Size as SizeDataStore;
                var SkillStore = Skill as SkillDataStore;
                var SpeedStore = Speed as SpeedDataStore;


                await BeastNote.Create(new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "2d8+2",
                    ArmorClass = 13,
                    SpecialBonus = 2,
                    //Image = [],
                    Title = "Волк",
                    Alignment = await AlignmentStore.GetByTitle("Без мировоззрения"),
                    Size = await SizeStore.GetByTitle("Средний"),
                    BeastType = await BestTypeStore.GetByTitle("Зверь"),
                    ChallengeRating = 0.25,
                    Description = "Волки встречаются в субарктических и умеренных регионах мира, где они часто передвигаются стаями через холмы и леса.",
                    CreationDate = DateTime.Today,
                    LastEditingDate = DateTime.Now,
                    SpeedList = 
                    [  
                        new SpeedListModel { Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle("Обычная"),
                            DistanceInFeet = 40
                        }
                    ],
                    SkillList =
                    [
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Внимательность"),
                        },
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Скрытность"),
                        },
                    ],
                    AbilityList = 
                    [
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Сила"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Ловкость"),
                            Value = 15
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Телосложение"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Интеллект"),
                            Value = 3
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Мудрость"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Харизма"),
                            Value = 6
                        },
                    ],
                    HabitatList = 
                    [
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Лес"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Равнина/луг"),
                        },
                        new HabitatListModel 
                        { 
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Холмы"),
                        }
                    ],
                    Actions = [
                        new ActionModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = @"Острый слух и тонкий нюх",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Пассивное"),
                            Description = @"Волк совершает с преимуществом проверки Мудрости (Внимательность), полагающиеся на слух и обоняние.",

                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,
                        },
                        new ActionModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = @"Тактика стаи",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Пассивное"),
                            Description = @"Волк совершает с преимуществом броски атаки по существу, если в пределах 5 футов от этого существа находится как минимум один дееспособный союзник волка.",

                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,
                        },
                        new ActionModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = @"Укус",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            Description = @"Рукопашная атака оружием: d20+4 к попаданию, досягаемость 5 фт., одна цель. Попадание: 7 (2к4+2) колющего урона. Если цель — существо, она должна преуспеть в спасброске Силы со Сл 11, иначе будет сбита с ног.",
                            ActionThrows = [
                                new ActionThrowModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Title = "Бросок на попадание",
                                    Throw = "d20+4"
                                },
                                new ActionThrowModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Title = "Колющий урон",
                                    Throw = "2к4+2"
                                },
                            ],
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,
                        }
                    ]
                });

                await BeastNote.Create(new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "2d8+2",
                    ArmorClass = 13,
                    SpecialBonus = 2,
                    //Image = [],
                    Title = "Волчара",
                    Alignment = await AlignmentStore.GetByTitle("Без мировоззрения"),
                    Size = await SizeStore.GetByTitle("Средний"),
                    BeastType = await BestTypeStore.GetByTitle("Зверь"),
                    ChallengeRating = 0.25,
                    Description = "Волки встречаются в субарктических и умеренных регионах мира, где они часто передвигаются стаями через холмы и леса.",
                    CreationDate = DateTime.Today,
                    LastEditingDate = DateTime.Now,
                    SpeedList =
                    [
                        new SpeedListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle("Обычная"),
                            DistanceInFeet = 40
                        }
                    ],
                    SkillList =
                    [
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Внимательность"),
                        },
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Скрытность"),
                        },
                    ],
                    AbilityList =
                    [
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Сила"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Ловкость"),
                            Value = 15
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Телосложение"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Интеллект"),
                            Value = 3
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Мудрость"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Харизма"),
                            Value = 6
                        },
                    ],
                    HabitatList =
                    [
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Лес"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Равнина/луг"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Холмы"),
                        }
                    ],
                    Actions = [

                        new ActionModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Укус",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            Description = "Рукопашная атака оружием: d20+4 к попаданию, досягаемость 5 фт., одна цель. Попадание: 7 (2к4 + 2) колющего урона. Если цель — существо, она должна преуспеть в спасброске Силы со Сл 11, иначе будет сбита с ног.",
                            ActionThrows = [
                                new ActionThrowModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Title = "Бросок на попадание",
                                    Throw = "к20+4"
                                },
                                new ActionThrowModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Title = "Колющий урон",
                                    Throw = "2к8+2"
                                },
                            ]
                        }
                    ]
                });

                /*await BeastNote.Create(new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "2d8+2",
                    //InitiativeBonus = 2,
                    ArmorClass = 13,
                    SpecialBonus = 2,
                    //Image = [],
                    Title = "Волк",
                    Alignment = await AlignmentStore.GetByTitle("Без мировоззрения"),
                    Size = await SizeStore.GetByTitle("Средний"),
                    BeastType = await BestTypeStore.GetByTitle("Зверь"),
                    ChallengeRating = 0.25,
                    Description = "Волки встречаются в субарктических и умеренных регионах мира, где они часто передвигаются стаями через холмы и леса.",
                    //SpellAbility = null,
                    //SpellAttackBonus = 0,
                    //SpellSaveThrowDifficulty = 0,
                    //ModeratorComment = string.Empty,
                    CreationDate = DateTime.Today,
                    LastEditingDate = DateTime.Now,
                    //AllUses = 0,
                    //UniqueUses = 0,
                    //UserRating = 0,
                    //IsBeingModerated = false,
                    //IsPublished = false,

                    SpeedList =
                    [
                        new SpeedListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle(),
                            DistanceInFeet = 40
                        }
                    ],
                    //DamageTendencyList = [],
                    SkillList =
                    [
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Внимательность"),
                        },
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Скрытность"),
                        },
                    ],
                    AbilityList =
                    [
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Сила"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Ловкость"),
                            Value = 15
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Телосложение"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Интеллект"),
                            Value = 3
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Мудрость"),
                            Value = 12
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Харизма"),
                            Value = 6
                        },
                    ],
                    //SpellSlots = [],
                    //Things = [],
                    HabitatList =
                    [
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Лес"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Равнина/луг"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Холмы"),
                        }
                    ],
                    //SenseList = [],
                    //ConditionImmunitiesList = []
                });*/
            }




            #endregion

            InitializeBeastNoteWithJsonInput();
        }
    
        private async void InitializeBeastNoteWithJsonInput()
        {
            List<string> jsons = [];
            {
                //jsons.Add("");
            }

            foreach (string json in jsons)
            {
                var beastNote = NPConv.ObjectFromUriValue<BeastNoteModel>(json);
                await BeastNote.Create(beastNote);
            }
        }
    }
}
