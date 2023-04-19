using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    public class Contacto
    {
        private string telefono;
        private string nombre;
        private string apellido;
        private string correo;
        private string fecha;

        public string Telefono { get => telefono; set => telefono = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
