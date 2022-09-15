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
    public partial class MantenimientoCliente : Mantenimiento 
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }


        public override Boolean Guardar()
        {
            try
            {
                string cmd = string.Format("EXEC ActualizaClientes '{0}','{1}','{2}'",txtIdCli.Text.Trim(), txtNom.Text.Trim(), txtAp.Text.Trim());

                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha guardado Correctamente!...");

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error.." + error.Message);
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {


                string cmd = string.Format("EXEC EliminarClientes '{0}'", txtIdCli.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha eliminado Correctamente!...");

            }

            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error!.. " + error);

            }


        }



        private void MantenimientoCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
