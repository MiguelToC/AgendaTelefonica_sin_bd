using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgendaTelefonica
{
    
    public partial class Buscar : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Buscar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm   = new Form1();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mostrar frm = new Mostrar();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nTelefono = txtBuscar.Text;
            bool encontrado;
            encontrado = false;

            Contacto contacto = Agenda.BuscarContacto(nTelefono);
            encontrado = contacto != null;

            if (!(txtBuscar.Text == string.Empty))
            {

                if (encontrado ==false)
                {
                    MessageBox.Show("La persona que busca no esta registrada en tus contactos");
                    txtInfo.Text = "";
                    return;
                }
                txtInfo.Text += string.Format("Telefono:   {0}\r\n", contacto.Telefono);
                txtInfo.Text += string.Format("Nombres:    {0}\r\n", contacto.Nombre);
                txtInfo.Text += string.Format("Apellido:   {0}\r\n", contacto.Apellido);
                txtInfo.Text += string.Format("Correo:     {0}\r\n", contacto.Correo);
                txtInfo.Text += string.Format("Fecha Nac:  {0}\r\n", contacto.Fecha);

            }
            else MessageBox.Show("Ingrese un numero de Teléfono");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtInfo.Text = "";
            txtBuscar.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Buscar_Load(object sender, EventArgs e)
        {

        }
    }
}
