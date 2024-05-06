using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DndFightManagerMobileApp.Utils
{
    public static class NavigationParameterConverter
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

        public static T ObjectFromUrl<T>(string url)
        {
            return ObjectFromPairKeyValue<T>(HttpUtility.UrlDecode(url));
        }

    }
}
