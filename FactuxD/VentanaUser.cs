using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;

namespace FactuxD
{
    public partial class VentanaUser : VentanaBase
    {
        public VentanaUser()
        {
            InitializeComponent();
        }

        private void VentanaUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VentanaUser_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE id_usuario=" + VentanaLogin.Codigo;  // la variable codigo se creo en la ventana login para obtener el valor 
            DataSet Ds = Utilidades.Ejecutar(cmd);

            lblNomUs.Text = Ds.Tables[0].Rows[0]["Nom_Us"].ToString();
            lblUs.Text = Ds.Tables[0].Rows[0]["account"].ToString();
            lblCodigo.Text = Ds.Tables[0].Rows[0]["id_Usuario"].ToString();

            string url = Ds.Tables[0].Rows[0]["Foto"].ToString();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contenedorPrincipal = new ContenedorPrincipal();
            this.Hide();  // Oculta la ventana Amdin y muestra el contenedor principal
            contenedorPrincipal.Show();

        }
    }
}
