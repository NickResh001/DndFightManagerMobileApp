﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Services
{
    public class NavigationParameterConverter
    {
        //Work with Newtonsoft's json

        public static string ObjectToPairKeyValue(object obj, string objectName)
        {
            if (obj != null)
                return $"{objectName}={JsonConvert.SerializeObject(obj)}";
            return null;
        }

        public static T ObjectFromPairKeyValue<T>(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentNullException("Пустой параметр");
            return JsonConvert.DeserializeObject<T>(parameter);
        }
    }
}
