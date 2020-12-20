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
    public partial class reportviewerPelicula : Form
    {
        public reportviewerPelicula()
        {
            InitializeComponent();
            DataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void reportviewerPelicula_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
