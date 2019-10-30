using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Usuario
    {
        private int id;
        private Rol rol;
        public static readonly Usuario usuario = new Usuario();

        private Usuario()
        {

        }

        public void crear_usuario(int id_input)
        {
            id = id_input;
            rol = new Rol(id_input);
        }

        public bool TieneFuncion(string unaFunc)
        {
            return rol.TieneFuncion(unaFunc);
        }
    }
}
