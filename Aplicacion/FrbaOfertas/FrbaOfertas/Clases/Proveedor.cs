using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Clases
{
    public class Proveedor
    {
        public string razon_social { get; set; }
        public string mail { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string cuit { get; set; }
        public int rubro { get; set; }
        public string nombre_contacto { get; set; }
        public int habilitado { get; set; }
        public int id_usuario { get; set; }


        public Proveedor(string _razon_social, string _mail, int _telefono, string _direccion, int _codigoPostal, string _ciudad, string _cuit, int _rubro, string _nombre_contacto, int _habilitado, int _id_usuario)
        {
            this.razon_social = _razon_social;
            this.mail = _mail;
            this.telefono = _telefono;
            this.direccion = _direccion;
            this.codigoPostal = _codigoPostal;
            this.ciudad = _ciudad;
            this.cuit = _cuit;
            this.rubro = _rubro;
            this.nombre_contacto = _nombre_contacto;
            this.habilitado = _habilitado;
            this.id_usuario = _id_usuario;
        }

        // Para Alta, sin habilitado ni id_usuario
        public Proveedor(string _razon_social, string _mail, int _telefono, string _direccion, int _codigoPostal, string _ciudad, string _cuit, int _rubro, string _nombre_contacto)
        {
            this.razon_social = _razon_social;
            this.mail = _mail;
            this.telefono = _telefono;
            this.direccion = _direccion;
            this.codigoPostal = _codigoPostal;
            this.ciudad = _ciudad;
            this.cuit = _cuit;
            this.rubro = _rubro;
            this.nombre_contacto = _nombre_contacto;
        }

    }

}
