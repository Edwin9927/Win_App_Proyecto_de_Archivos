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
    public partial class newSala : Form
    {
        public newSala()
        {
            InitializeComponent();
        }

        private void newSala_Load(object sender, EventArgs e)
        {
            try
            {
                dataCine.ReadXml(Application.StartupPath + "\\Sala.xml");
            }catch
            {

            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addSala add = new addSala();
            add.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchSala sala = new searchSala();
            sala.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            reportviewerSala sala = new reportviewerSala();
            sala.ShowDialog();
        }
    }
}
