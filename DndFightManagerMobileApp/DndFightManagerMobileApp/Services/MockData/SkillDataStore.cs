using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class SkillDataStore : BaseHardDirMockDataStore<SkillModel>, ISkillDataStore
    {

        public async Task<ObservableCollection<SkillListModel>> GetDefaultList()
        {
            ObservableCollection<SkillListModel> skillList =
            [
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Атлетика"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Акробатика"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Ловкость рук"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Скрытность"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Анализ"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("История"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Магия"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Природа"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Религия"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Внимательность"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Выживание"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Медицина"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Проницательность"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Уход за животными"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Выступление"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Запугивание"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Обман"),
                    Value = 0,
                    Proficiency = false
                },
                new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = await GetByTitle("Убеждение"),
                    Value = 0,
                    Proficiency = false
                },
            ];

            return skillList;
        }
    }
}
