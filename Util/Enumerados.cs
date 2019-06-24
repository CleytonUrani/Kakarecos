using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kakarecos.Util
{
    public class Enumerados
    {
        public static string ObtemDescricao(Enum value)
        {
            var tipoEnum = value.GetType();
            var campos = tipoEnum.GetField(value.ToString());
            var atributos = campos.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length == 0 ? value.ToString() : ((DescriptionAttribute)atributos[0]).Description;
        }
    }
}
