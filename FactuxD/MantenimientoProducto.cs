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
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }

        private void MantenimientoProducto_Load(object sender, EventArgs e)
        {

        }

        public override Boolean Guardar()
        {
            if(Utilidades.ValidarFormulario(this,errorProvider1)==false)

            {
                try
                {
                    string cmd = string.Format("EXEC ActualizaArticulos '{0}','{1}','{2}'", txtIdProd.Text.Trim(), txtNomPro.Text.Trim(), txtPrecio.Text.Trim());

                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Se ha guardado Correctamente!...");

                    txtIdProd.Clear();
                    txtNomPro.Clear();
                    txtPrecio.Clear();

                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error.." + error.Message);
                    return false;
                }

            }else
            {
                return false;
            }


            
        }

        public override void Eliminar()
        {
            try
            {


                string cmd = string.Format("EXEC EliminarArticulos '{0}'", txtIdProd.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha eliminado Correctamente!...");
                txtIdProd.Clear();

            }

            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error!.. " + error);
                
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void txtIdProd_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();  //Cuando empieza a escribir de nuevo en los campos se quita el error provider
        }
    }
}
