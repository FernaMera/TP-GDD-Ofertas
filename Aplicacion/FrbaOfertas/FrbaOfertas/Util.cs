using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class Util
    {

        public static bool cuitValido(string cuit)
        {
            if (cuit.Length != 13)
                return false;

            for (int i = 3; i < 11; i++) // dígitos intermedios
            {
                if (!Char.IsDigit(cuit[i]))
                    return false;
            }

            return cuit[2] == '-' && cuit[11] == '-' && Char.IsDigit(cuit[0]) && Char.IsDigit(cuit[1]) && Char.IsDigit(cuit[12]);
        }

        public static bool telefonoValido(string tel)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(tel, "^[0-9]*$");
        }

        public static bool codigoPostalValido(string cp)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cp, "^[0-9]*$");
        }



    }
}
