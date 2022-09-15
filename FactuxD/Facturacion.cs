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
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM USUARIOS WHERE id_usuario=" + VentanaLogin.Codigo;  //Muestra la persona que lo esta atendiendo "jala el nombre de la base de de datos y lo muestra en el label"
            DataSet ds;
            ds = Utilidades.Ejecutar(cmd);

            lblAtiende.Text = ds.Tables[0].Rows[0]["Nom_us"].ToString().Trim();
        }

        private void errortxtBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAtiende_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e) // Al momento de buscar el id del cliente carga los datos del nombre del cliente
        {
            if(string.IsNullOrEmpty(txtCodigoCli.Text.Trim())==false)
            {
                try
                {


                    string cmd = string.Format("SELECT Nom_clie FROM Cliente  WHERE id_clientes='{0}'", txtCodigoCli.Text.Trim());

                    DataSet ds = Utilidades.Ejecutar(cmd);
                    txtCli.Text = ds.Tables[0].Rows[0]["Nom_clie"].ToString().Trim();
                    txtCodigo.Focus();

                }catch(Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error:" + error.Message);

                }

            }

        }

        public static int cont_fila = 0;
        public static double total;
        private void btnColocar_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this,errorProvider1)==false)
            {
                bool existe = false;
                int num_fila = 0;

                if(cont_fila==0) //Esto significa que no hay nada en el datagridview hay 0 renglones
                {
                    dataGridView1.Rows.Add(txtCodigo.Text, txtDescripcion.Text, txtPrecio.Text,txtCantidad.Text); //Entonces agrega los campos metidos al datagridview con el add
                   
                    double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value); // multiplica la cantidad por el precio

                    //por lo tanto 
                    dataGridView1.Rows[cont_fila].Cells[4].Value = importe; //pone el resultado en la variable importe

                    cont_fila++; 

                }else
                {
                    foreach(DataGridViewRow Fila in dataGridView1.Rows) //Busca si esta repetido un registro  y si ya existe obtiene el numero de fila con el index y solo agrega cantidad a esa fila
                    {

                        if(Fila.Cells[0].Value.ToString()==txtCodigo.Text)
                        {

                            existe = true;
                            num_fila = Fila.Index;

                        }

                    }

                    if (existe == true)
                    {
                        dataGridView1.Rows[num_fila].Cells[3].Value =( Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();

                        double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value); // multiplica la cantidad por el precio
                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;

                    }else
                    {

                        dataGridView1.Rows.Add(txtCodigo.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text); //Entonces agrega los campos metidos al datagridview con el add

                        double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value); // multiplica la cantidad por el precio

                        //por lo tanto 
                        dataGridView1.Rows[cont_fila].Cells[4].Value = importe; //pone el resultado en la variable importe

                        cont_fila++;


                    }

                }

                total = 0;

                foreach (DataGridViewRow Fila in dataGridView1.Rows) //Busca si esta repetido un registro  y si ya existe obtiene el numero de fila con el index y solo agrega cantidad a esa fila
                {

                    total += Convert.ToDouble(Fila.Cells[4].Value);

                    lblTotal.Text = "$" + total.ToString();

                }

            }
            txtCodigo.Clear(); txtDescripcion.Clear(); txtPrecio.Clear(); txtCantidad.Clear();
            txtCodigo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            total = total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
            lblTotal.Text = "$" + total;
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            cont_fila--;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConsultarClientes consultarClientes = new ConsultarClientes();
            consultarClientes.ShowDialog();
            if(consultarClientes.DialogResult==DialogResult.OK)
            {
                txtCodigoCli.Text = consultarClientes.dataGridView1.Rows[consultarClientes.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtCli.Text= consultarClientes.dataGridView1.Rows[consultarClientes.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

                txtCodigo.Focus();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ConsultarProductos consultarProductos = new ConsultarProductos();
            consultarProductos.ShowDialog();
            if(consultarProductos.DialogResult==DialogResult.OK)
            {
                txtCodigo.Text = consultarProductos.dataGridView1.Rows[consultarProductos.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtDescripcion.Text = consultarProductos.dataGridView1.Rows[consultarProductos.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtPrecio.Text = consultarProductos.dataGridView1.Rows[consultarProductos.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtCantidad.Focus();


            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        public override void Nuevo()
        {
            txtCodigoCli.Text = "";   //Eliminamos la informacion de los campos y reseteamos nuetras variables cont_fila y total
            txtCli.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            lblTotal.Text = "";
            dataGridView1.Rows.Clear();
            cont_fila = 0;
            total = 0;
            txtCodigoCli.Focus();



        }
    }

}
