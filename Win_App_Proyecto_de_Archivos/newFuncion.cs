using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_App_Proyecto_de_Archivos
{
    public partial class newFuncion : Form
    {
        public newFuncion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addFuncion funcion = new addFuncion();
            funcion.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchFuncion funcion = new searchFuncion();
            funcion.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            reportviewerFuncion funcion = new reportviewerFuncion();
            funcion.ShowDialog();
        }
    }
}
