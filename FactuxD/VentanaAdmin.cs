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
    public partial class VentanaAdmin : VentanaBase
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaAdmin_Load(object sender, EventArgs e)   
        {   
            //Todo esto es para que alc argar la pantalla cargue los datos que estan en la 
            string cmd = "SELECT * FROM Usuarios WHERE id_usuario=" + VentanaLogin.Codigo;  // la variable codigo se creo en la ventana login para obtener el valor 
            DataSet Ds = Utilidades.Ejecutar(cmd); 

            lblNomUs.Text = Ds.Tables[0].Rows[0]["Nom_us"].ToString();
            lblUsAdmin.Text = Ds.Tables[0].Rows[0]["account"].ToString();
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
