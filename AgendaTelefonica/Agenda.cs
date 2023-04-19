using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    public class Agenda
    {
        private static List<Contacto> contactos;

        public static string AgregarContacto(Contacto contacto)
        {
            if (contactos == null)
                contactos = new List<Contacto>();
            if (BuscarContacto(contacto.Telefono) != null)
            {
                return "El numero telefonico ya pertenece a un contacto";
            }
            if (string.IsNullOrEmpty(contacto.Nombre))
            {
                return "Por favor ingrese el nombre del contacto";
            }
            if (string.IsNullOrEmpty(contacto.Apellido))
            {
                return "Por favor ingrese el apellido del contacto";
            }
            if (string.IsNullOrEmpty(contacto.Correo))
            {
                return "Por favor ingrese el correo del contacto";
            }
            if (string.IsNullOrEmpty(contacto.Fecha))
            {
                return "Por favor ingrese la fecha de nacimiento del contacto";
            }
            contactos.Add(contacto);
            return "Contacto agregado correctamente!";
        }
        public static List<Contacto> ObtenerContacto()
        {
            //if (contactos == null)
             //   contactos = new List<Contacto>();
            return contactos;
        }
        public static Contacto BuscarContacto (string telefono)
        {
            Contacto contacto = new Contacto();
            if (contactos == null)
                contactos = new List<Contacto>();
            foreach (var item in contactos)
            {
                if (item.Telefono == telefono)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
