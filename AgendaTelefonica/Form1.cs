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
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        //VARIABLES QUE CREAMOS PARA TODO EL CODIGO
        int posY = 0;
        int posX = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();

            IngresarDatos frm = new IngresarDatos();

            frm.Show();
        }

         private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            IngresarDatos frm = new IngresarDatos();
            
            frm.Show();

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.Hide();

            Mostrar frm = new Mostrar();
            frm.Show();
        }
        
        private void TituloBarra_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left= Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Hide();

            Buscar frm = new Buscar();  

            frm.Show();
        }

        private void Hora_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
