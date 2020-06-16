using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kakarecos.Util
{
    public class Texto
    {
        public string RetornaSomenteNumeros(string texto)
        {
            return new Regex(@"[^0-9]").Replace(texto, "");
        }
    }
}
