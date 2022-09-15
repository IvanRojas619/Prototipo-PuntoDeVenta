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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string CMD = string.Format("Select * FROM usuarios WHERE account='{0}' AND password='{1}'", txtNomAcc.Text.Trim(), txtPass.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);

                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string contraseña = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == txtNomAcc.Text.Trim() && contraseña == txtPass.Text.Trim())
                {
                    MessageBox.Show("Se ha iniciado Sesion correctamente");

                }
                


            }
            catch(Exception )
            {

                MessageBox.Show("Usuario o Contraseña Incorrectos");

            }
         
            
            
            
            
            
            
            
            
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
    }
}
