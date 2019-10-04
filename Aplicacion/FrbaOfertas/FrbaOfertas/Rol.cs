using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    class Rol
    {
        private int id;
        private string nombre;
        private HashSet<Funcionalidad> funcionalidades;
        private HashSet<string> funciones;

        //se llama cuando se carga la base de datos
        public Rol(int id_input)
        {
            id = id_input;
            //cargar nombre desde base de datos

            funcionalidades = new HashSet<Funcionalidad>();
            //cargar desde la base de datos las funcionalidades
        }

        public Rol (int id_input, string nom, HashSet<string> func)
        {
            id = id_input;
            nombre = nom;
            funciones = func;
        }

        //Llamar este metodo cuando se crea un nuevo rol
        public void NuevoRol(string nom_input, HashSet<Funcionalidad> fun_input)
        {
            //generar nuevo id
            id = 0;
            nombre = nom_input;
            funcionalidades = fun_input;
        }

        public void ModRol(string nom_input, HashSet<Funcionalidad> fun_input)
        {
            nombre = nom_input;
            funcionalidades = fun_input;
        }

        public bool TieneFuncion(string funcion)
        {
            return funciones.Contains(funcion);
        }
    }
}
