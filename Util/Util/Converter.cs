using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    class Converter
    {
        public static T JsonPara<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static T ObjetoPara<T>(object objeto)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string ObjetoParaString(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
