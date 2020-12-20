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
    public partial class newCliente : Form
    {
        public newCliente()
        {
            InitializeComponent();
        }

        private void newCliente_Load(object sender, EventArgs e)
        {
            dataCine.EnforceConstraints = false;
            dataCine.ReadXml(Application.StartupPath + "\\Cliente.xml");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addCliente add = new addCliente();
            add.ShowDialog();
        }
    }
}
