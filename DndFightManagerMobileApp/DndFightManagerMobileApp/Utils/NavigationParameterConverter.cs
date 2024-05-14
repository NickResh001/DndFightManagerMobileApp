using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            {
                string escapedJson = Uri.EscapeDataString(JsonConvert.SerializeObject(obj));
                return $"{objectName}={escapedJson}";
            }
            return null;
        }

        public static T ObjectFromUriValue<T>(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentNullException("Пустой параметр");

            return JsonConvert.DeserializeObject<T>(Uri.UnescapeDataString(parameter));
        }

        public static T ObjectFromUrl<T>(string url)
        {
            return ObjectFromUriValue<T>(HttpUtility.UrlDecode(url));
        }

    }
}
