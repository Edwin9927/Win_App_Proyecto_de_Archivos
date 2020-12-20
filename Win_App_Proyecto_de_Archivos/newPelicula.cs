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
    public partial class newPelicula : Form
    {
        public newPelicula()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addPelicula pelicula = new addPelicula();
            pelicula.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchPelicula pelicula = new searchPelicula();
            pelicula.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            reportviewerPelicula pelicula = new reportviewerPelicula();
            pelicula.ShowDialog();
        }
    }
}
