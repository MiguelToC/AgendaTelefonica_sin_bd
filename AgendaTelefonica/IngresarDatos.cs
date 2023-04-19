using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AgendaTelefonica
{
    public partial class IngresarDatos : Form
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

        public IngresarDatos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int posX = 0;
        int posY = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IngresarDatos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(txtTelefono.Text == string.Empty ||
                  txtNombre.Text == string.Empty ||
                  txtApellido.Text == string.Empty ||
                  txtCorreo.Text == string.Empty ||
                  txtFecha.Text == string.Empty))
            {
                Contacto contacto = new Contacto();
                contacto.Telefono = txtTelefono.Text;
                contacto.Nombre = txtNombre.Text;
                contacto.Apellido = txtApellido.Text;
                contacto.Correo = txtCorreo.Text;
                contacto.Fecha = txtFecha.Text;

                string mensaje = Agenda.AgregarContacto(contacto);

                if (mensaje == "Contacto agregado correctamente!")
                    NuevoContacto();
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Faltan rellenar campos");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoContacto();
        }
        public void NuevoContacto()
        {
            txtTelefono.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
