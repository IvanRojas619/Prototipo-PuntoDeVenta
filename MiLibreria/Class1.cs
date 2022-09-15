using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MiLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F6H1TLU1\\SQLEXPRESS;Initial Catalog=Administracion;Integrated Security=True");
            con.Open(); //  metodo para abrir la conexion a la abse de datos

            DataSet Ds = new DataSet();  // Instancio la clase Dataset en el objeto Ds

            SqlDataAdapter Dp = new SqlDataAdapter(cmd,con);   // Instancio la clase SqlDataAdapter en el objeto dp 

            Dp.Fill(Ds); // Rellena el dataset que le pasamos por parametro osea el Ds

            con.Close(); // Cerramos la conexion de la base de datos

            return (Ds);


        }

        public static Boolean ValidarFormulario(Control Objeto,ErrorProvider ErrorProvider)
        {

            Boolean Hayerrores = false;

            foreach(Control Item in Objeto.Controls)
            {

                if(Item is ErrortxtBox)
                {
                    ErrortxtBox Obj = (ErrortxtBox)Item;

                    if(Obj.Validar==true)
                    {
                        if(string.IsNullOrEmpty(Obj.Text.Trim()))
                        {
                            ErrorProvider.SetError(Obj, "No puede estar vacio");
                            Hayerrores = true;
                        }
                    }

                    if(Obj.SoloNumeros==true)
                    {
                        int cont = 0, LetrasEncontradas = 0;

                        foreach(char letra in Obj.Text.Trim())
                        {
                            if( char.IsLetter(Obj.Text.Trim(),cont))
                            {
                                LetrasEncontradas++;
                            }
                            cont++;
                        }
                        if(LetrasEncontradas!=0)
                        {
                            Hayerrores = true;
                            ErrorProvider.SetError(Obj, "Solo numeros");
                        }

                    }



                }

            }
            return Hayerrores;
        }
    }
}
