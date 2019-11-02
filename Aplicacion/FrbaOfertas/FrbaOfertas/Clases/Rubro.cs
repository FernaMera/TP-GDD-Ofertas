using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Clases
{
    class Rubro
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Rubro(int _id, string _descripcion)
        {
            this.id = _id;
            this.descripcion = _descripcion;
        }
    }
}
