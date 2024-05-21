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
            await Language.Create(new LanguageModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Телепатия"
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

                // Волк
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
                            Value = 3
                        },
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Скрытность"),
                            Value = 4
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
                // Вегепигмей
                await BeastNote.Create(new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "2d6+2",
                    ArmorClass = 13,
                    SpecialBonus = 2,
                    //Image = [],
                    Title = "Вегепигмей",
                    Alignment = await AlignmentStore.GetByTitle("Нейтрально-Нейтральный"),
                    Size = await SizeStore.GetByTitle("Маленький"),
                    BeastType = await BestTypeStore.GetByTitle("Растение"),
                    ChallengeRating = 0.25,
                    Description = "Вегепигмеи, также называемые плесневый народец или плесневики, населяют тёмные области, в которых тепло и влажно, так что чаще всего их можно встретить под землёй или в плотных лесах, которые не пропускают солнечный свет. Хоть они и предпочитают есть свежее мясо, кости и кровь, вегепигмеи также могут поглощать питательные вещества из почвы и многих видов органической материи, что означает, что они редко бывают голодны. Друг с другом вегепигмеи общаются свистом, жестами и ритмичными постукиваниями по телу.\r\n\r\nВегепигмеи мало что изготавливают и строят; все снаряжение они берут у других существ или строят копии простых зданий, которые видели.\r\n\r\nПока вегепигмей стареет, он становится мощнее и развивает области спор на своём теле. Вегепигмеи переносящие споры уважаемы другими вегепигмеями, так что чужаки часто обращаются к таким вегепигмеям как к вождям. Вождь может испустить свои споры облаком, и заразить ближайших существ.",
                    CreationDate = DateTime.Today,
                    LastEditingDate = DateTime.Now,
                    SpeedList =
                    [
                        new SpeedListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle("Обычная"),
                            DistanceInFeet = 30
                        }
                    ],
                    SkillList =
                    [
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Внимательность"),
                            Value = 2
                        },
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Скрытность"),
                            Value = 4
                        },
                    ],
                    AbilityList =
                    [
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Сила"),
                            Value = 7
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Ловкость"),
                            Value = 14
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Телосложение"),
                            Value = 13
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Интеллект"),
                            Value = 6
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Мудрость"),
                            Value = 11
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Харизма"),
                            Value = 7
                        },
                    ],
                    SenseList = 
                    [
                        new SenseListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Sense = await SenseStore.GetByTitle("Темное зрение"),
                            DistanceInFeet = 60
                        }
                    ],
                    DamageTendencyList = 
                    [
                        new DamageTendencyModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            DamageTendencyType = await DamageTendencyType.GetByTitle("Сопротивление"),
                            DamageType = await DamageType.GetByTitle("Электричеством"),
                        },
                        new DamageTendencyModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            DamageTendencyType = await DamageTendencyType.GetByTitle("Сопротивление"),
                            DamageType = await DamageType.GetByTitle("Колющий"),
                        }
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
                            Habitat = await HabitatTypeStore.GetByTitle("Болото"),
                        }
                    ],
                    Actions = [

                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Растительный камуфляж",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Пассивное"),
                            Description = "Вегепигмей имеет преимущество на проверки Ловкости (Скрытность), которые он делает в любой местности, достаточно укрытой растительностью.",
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Регенерация",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Пассивное"),
                            Description = "Вегепигмей восстанавливает 3 хита в начале своего хода. Если он получает урон холодом, огнем или некротический урон, то эта черта не работает в начале следующего хода вегепигмея. Он умирает только если начинает ход с 0 хитов и не может регенерировать.",
                        },

                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Когти",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            Description = "Рукопашная атака оружием: к20+4 к попаданию, досягаемость 5 фт., одна цель. Попадание: 5 (1к6+2) рубящего урона.",
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
                                    Title = "Рубящий урон",
                                    Throw = "1к6+2"
                                },
                            ]
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Праща",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            Description = "Дальнобойная атака оружием: к20+4 к попаданию, дистанция 30/120 фт., одна цель. Попадание: 4 (1к4+2) дробящего урона",
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
                                    Title = "Дробящий урон",
                                    Throw = "1к4+2"
                                },
                            ]
                        },
                    ]
                });
                // Балханот
                var actionTentacle = new ActionModel
                {
                    Cooldown1_SpellSlotLevel = 1,
                    Cooldown2_LowerRangeLimit = 5,
                    Cooldown2_UpperRangeLimit = 6,
                    Cooldown2_DiceSize = 6,
                    Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                    Cooldown3_MeasureMultiply = 1,
                    Cooldown3_HowManyTimes = 1,
                    Reaction_Condition = "",
                    Lair_InitiativeBonus = 20,

                    Id = Guid.NewGuid().ToString(),
                    Title = "Щупальце",
                    CooldownType = await CooldownType.GetByTitle("Нет"),
                    ActionResource = await ActionResource.GetByTitle("Основное"),
                    Description = "Рукопашная атака оружием: к20+7 к попаданию, досягаемость 10 фт., одна цель. Попадание: 10 (2к6+3) дробящего урона, и цель становится схваченной (Сл высвобождения 15) и притягивается на 5 футов ближе к балханноту. Пока цель схвачена, она опутана; у балханнота 4 щупальца и каждое может держать в захвате только одну цель.",
                    ActionThrows = 
                    [
                        new ActionThrowModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Бросок на попадание",
                            Throw = "к20+7"
                        },
                        new ActionThrowModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Дробящий урон",
                            Throw = "2к6+3"
                        },
                    ]
                };
                var actionBait = new ActionModel
                {
                    Cooldown1_SpellSlotLevel = 1,
                    Cooldown2_LowerRangeLimit = 5,
                    Cooldown2_UpperRangeLimit = 6,
                    Cooldown2_DiceSize = 6,
                    Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                    Cooldown3_MeasureMultiply = 1,
                    Cooldown3_HowManyTimes = 1,
                    Reaction_Condition = "",
                    Lair_InitiativeBonus = 20,

                    Id = Guid.NewGuid().ToString(),
                    Title = "Укус",
                    CooldownType = await CooldownType.GetByTitle("Нет"),
                    ActionResource = await ActionResource.GetByTitle("Основное"),
                    Description = "Рукопашная атака оружием: к20+7 к попаданию, досягаемость 5 фт., одна цель. Попадание: 25 (4к10+3) колющего урона.",
                    ActionThrows = [
                        new ActionThrowModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Бросок на попадание",
                            Throw = "к20+7"
                        },
                        new ActionThrowModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Колющий урон",
                            Throw = "4к10+3"
                        },
                    ]
                };
                await BeastNote.Create(new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "12к10+48",
                    ArmorClass = 17,
                    SpecialBonus = 4,
                    //Image = [],
                    Title = "Балханот",
                    Alignment = await AlignmentStore.GetByTitle("Хаотично-Злой"),
                    Size = await SizeStore.GetByTitle("Большой"),
                    BeastType = await BestTypeStore.GetByTitle("Абберация"),
                    ChallengeRating = 11,
                    Description = "Родом из Царства Теней злобные, хищные балханноты меняют облик своего гнезда на место, привлекающее внимание путников. Как только они входят на них набрасывается балханнот.\r\n\r\nЛожная надежда. Благодаря ограниченным возможностям телепатии, балханнот может учуять желания других существ и воображать места, которые те хотели бы встретить на своём пути. Затем балханнот искажает реальность, преобразовывая своё логово в то место, которое жертва желает найти. Балханноты не могут справляться с детализацией объектов, и поэтому многие несоответствия могут разоблачить иллюзию, но подделка достаточно хороша, чтобы обмануть отчаявшихся существ забрести в объятия чудища.\r\n\r\nЗлобные существа. Балханноты получают удовольствие, наживаясь на страхе и отчаянии страдающей жертвы. Оно запугивает свою добычу, пользуясь способностями, искажающими реальность, скрывая самого себя, пока не сцапает свою жертву. После чего, оно перемещается в другое место и пожирает свою добычу.\r\n\r\nПолезные рабы. Охотничьи группы дроу и иные посетители Подземья, порой осмеливаются войти в Царство Теней чтобы изловить балханнота. Этих существ оставляют в качестве стражей, защищая проходы от вторжения врагов и отрезая им пути к отступлению, а также в качестве надсмотрщиков над рабами.",
                    CreationDate = DateTime.Today,
                    LastEditingDate = DateTime.Now,
                    LairInitiative = 20,
                    SpellSlots = 
                    [
                        new SpellSlotModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Level = 1,
                            Count = 3
                        },
                        new SpellSlotModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Level = 2,
                            Count = 1
                        }
                    ],
                    SpeedList =
                    [
                        new SpeedListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle("Обычная"),
                            DistanceInFeet = 25
                        },
                        new SpeedListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Speed = await SpeedStore.GetByTitle("Лазая"),
                            DistanceInFeet = 25
                        }
                    ],
                    SkillList =
                    [
                        new SkillListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Skill = await SkillStore.GetByTitle("Внимательность"),
                            Value = 6
                        }
                    ],
                    AbilityList =
                    [
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Сила"),
                            Value = 17
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Ловкость"),
                            Value = 8
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Телосложение"),
                            Value = 18
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Интеллект"),
                            Value = 6
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Мудрость"),
                            Value = 15
                        },
                        new AbilityListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Ability = await AbilityStore.GetByTitle("Харизма"),
                            Value = 8
                        },
                    ],
                    SenseList =
                    [
                        new SenseListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Sense = await SenseStore.GetByTitle("Слепое зрение"),
                            DistanceInFeet = 500
                        }
                    ],
                    LanguageList =
                    [
                        new LanguageListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Language = await Language.GetByTitle("Глубинная Речь")
                        },
                        new LanguageListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Language = await Language.GetByTitle("Телепатия")
                        }
                    ],
                    ConditionImmunitiesList = 
                    [
                        new ConditionImmunitiesListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Condition = await Condition.GetByTitle("Ослепленный")
                        }
                    ],
                    HabitatList =
                    [
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Горы"),
                        },
                        new HabitatListModel
                        {
                            Id = Guid.NewGuid().ToString(),
                            Habitat = await HabitatTypeStore.GetByTitle("Подземье"),
                        }
                    ],
                    Actions = [

                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Легендарное сопротивление",
                            CooldownType = await CooldownType.GetByTitle("Время"),
                            Cooldown3_HowManyTimes = 2,
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Сутки"),
                            ActionResource = await ActionResource.GetByTitle("Пассивное"),
                            Description = "Если балханнот проваливает спасбросок, он может вместо этого сделать спасбросок успешным."
                        },
                        actionBait,
                        actionTentacle,
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Мультиатака",
                            IsMultiaction = true,
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            ChildActions = 
                            [
                                new MultiActionList
                                {
                                    ChildAction = actionBait,
                                    SequenceNumber = 1,
                                    RepititionNumber = 1
                                },
                                new MultiActionList
                                {
                                    ChildAction = actionTentacle,
                                    SequenceNumber = 2,
                                    RepititionNumber = 2
                                }
                            ],
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Мультиатака",
                            IsMultiaction = true,
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Основное"),
                            ChildActions =
                            [
                                new MultiActionList
                                {
                                    ChildAction = actionTentacle,
                                    SequenceNumber = 1,
                                    RepititionNumber = 4
                                }
                            ],
                        },

                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Атака укусом",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Легендарное"),
                            Description = "Балханнот совершает одну атаку Укусом по существу, cхваченным его Щупальцем.",
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Телепортация",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Легендарное"),
                            Description = "Балханнот магическим образом телепортируется вместе с cхваченным существом, со всем своим несомым и носимым снаряжением, на расстояние до 60 футов в свободное пространство, которое он видит.",
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",
                            Lair_InitiativeBonus = 20,

                            Id = Guid.NewGuid().ToString(),
                            Title = "Исчезновение",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Легендарное"),
                            Description = "Балханнот магическим образом становится невидимым до 10 минут, либо пока не совершит бросок атаки.",
                        },

                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",

                            Id = Guid.NewGuid().ToString(),
                            Title = "Искажение",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Логова"),
                            Lair_InitiativeBonus = 20,
                            Description = "Балханнот искажает реальность вокруг себя на расстоянии 500 футов. Через 10 минут часть местной территории преобразуется в ту местность, о котором подумал разумный гуманоид, чьи мысли были прочитаны балханнотом (смотрите описанный раздел «Эффекты Местности» ниже. Преобразования касаются только неживых объектов окружения, и не могут воссоздать движущиеся элементы и магические свойства. Любой объект, воссозданный на этой местности, при близком осмотре оказывается подделкой. К примеру, в книгах пустые страницы, а золотые предметы фальшивые и так далее. Преобразование длится до тех пор, пока балханнот не будет убит, либо ещё раз не воспользуется этим же действием логова.",
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",

                            Id = Guid.NewGuid().ToString(),
                            Title = "Перенос",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Логова"),
                            Lair_InitiativeBonus = 20,
                            Description = "Балханнот наводится на любое существо в пределах 500 футов от него. Существо должно успешно пройти спасбросок Мудрости со Сл 16, в противном случае, существо вместе с тем, во что он одет и носит, перемещается в любое свободное пространство по выбору балханнота в пределах 60 футов его видимости.",
                        },
                        new ActionModel
                        {
                            Cooldown1_SpellSlotLevel = 1,
                            Cooldown2_LowerRangeLimit = 5,
                            Cooldown2_UpperRangeLimit = 6,
                            Cooldown2_DiceSize = 6,
                            Cooldown3_TimeMeasure = await TimeMeasure.GetByTitle("Раунд"),
                            Cooldown3_MeasureMultiply = 1,
                            Cooldown3_HowManyTimes = 1,
                            Reaction_Condition = "",

                            Id = Guid.NewGuid().ToString(),
                            Title = "Слепое пятно",
                            CooldownType = await CooldownType.GetByTitle("Нет"),
                            ActionResource = await ActionResource.GetByTitle("Логова"),
                            Lair_InitiativeBonus = 20,
                            Description = "Балханнот выбирает целью любое существо в пределах 500 футов от него. Цель должна преуспеть в спасброске Мудрости Сл 16, иначе балханнот становится невидимым для неё на 1 минуту. Эффект оканчивается, если балханнот проводит по цели атаку.",
                        },
                    ]
                });
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
