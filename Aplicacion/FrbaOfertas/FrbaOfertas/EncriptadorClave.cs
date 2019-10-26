using System;
using System.Text;
using System.Security.Cryptography;

namespace FrbaOfertas
{
    class EncriptadorClave
    {
        public String Encriptar(String clave)
        {
            SHA256 encriptador = SHA256.Create();

            byte[] bytes = encriptador.ComputeHash(Encoding.UTF8.GetBytes(clave));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
