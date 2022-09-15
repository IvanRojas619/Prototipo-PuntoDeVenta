using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiLibreria
{
    public partial class ErrortxtBox : TextBox
    {
        public ErrortxtBox()
        {
            InitializeComponent();
        }

        public Boolean Validar
        {
            get;
            set;
           

           
        }

        public Boolean SoloNumeros
        {
            get;
            set;
        }
    }
}
