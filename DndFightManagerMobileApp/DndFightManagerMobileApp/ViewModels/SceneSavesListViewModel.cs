using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class SceneSavesListViewModel : BaseViewModel, IQueryAttributable
    {
        #region Incoming params
        private string _sceneId;
        #endregion

        #region ObservableProperties
        [ObservableProperty]
        private ObservableCollection<SceneSaveModel> _sceneSaves;

        #endregion
        public SceneSavesListViewModel() 
        {
            SceneSaves = [];
        }

        #region Navigation
        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string sceneIdParam = "sceneId";

            _sceneId = null;

            if (query.ContainsKey(sceneIdParam))
                _sceneId = NPConv.ObjectFromUrl<string>(query[sceneIdParam]);

            if (!string.IsNullOrEmpty(_sceneId))
            {
                SceneSaves = [.. await dataStore.SceneSave.GetAllBySceneId(_sceneId)];
                if (SceneSaves != null && SceneSaves.Count == 0)
                {
                    SceneSaves.Add(new SceneSaveModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Scene = await dataStore.Scene.GetById(_sceneId)
                    });
                }
            }
            else
            {
                SceneSaves = [];
            }
        }
        #endregion
    }
}
