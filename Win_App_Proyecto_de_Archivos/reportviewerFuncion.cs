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
    public partial class reportviewerFuncion : Form
    {
        public reportviewerFuncion()
        {
            InitializeComponent();
        }

        private void reportviewerFuncion_Load(object sender, EventArgs e)
        {
            DataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
            this.reportViewer1.RefreshReport();
        }
    }
}
