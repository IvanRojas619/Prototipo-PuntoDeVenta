using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  // con esta libreria puedes usar la conexiones a la  base de datos
using MiLibreria;


namespace FactuxD
{
    public partial class VentanaLogin : VentanaBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        public static string Codigo = "";
        private void button1_Click(object sender, EventArgs e)
        {
           








            //Utilidades.Ejecutar("SELECT * FROM Clientes Where id=1");


            //try
            //{ 
            //SqlConnection con = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=Administracion;Integrated Security=True");
            //con.Open(); //  metodo para abrir la conexion a la abse de datos
            //    MessageBox.Show("Se ha conectado correctamente");
            //}

            //catch(Exception error)
            //{
            //    MessageBox.Show("Ha ocurrido un error: " + error.Message);


            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                string CMD = string.Format("Select * FROM usuarios WHERE account='{0}' AND password='{1}'", txtNomAcc.Text.Trim(), txtPass.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);


                Codigo = ds.Tables[0].Rows[0]["id_Usuario"].ToString().Trim();  // Sacael valor de la persona que se quiere conectar y es publico

                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string contraseña = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == txtNomAcc.Text.Trim() && contraseña == txtPass.Text.Trim())
                {
                    //MessageBox.Show("Se ha iniciado Sesion correctamente");  //Version anterior



                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status_Admin"])==true) // Se convierte el data set a bolleano para validar que sea admin o no lo sea
                            {

                        VentanaAdmin ventanaAdmin = new VentanaAdmin();  // Instancio clase de la VentanaAdmin en ventanaadmin

                        this.Hide();  // oculta ventana login

                        ventanaAdmin.Show();// muestra en pantalla la ventana admin gracias a la validicacion

                    }
                    else                                                 //Si no es administrador entonces muestra la pantalla de usuario
                    {
                        VentanaUser ventanaUser = new VentanaUser();

                        this.Hide(); // oculta la ventana login 
                        ventanaUser.Show(); //muestra la ventana usuario


                    }


                }



            }
            catch (Exception)
            {

                MessageBox.Show("Usuario o Contraseña Incorrectos");

            }

        }

        private void VentanaLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}