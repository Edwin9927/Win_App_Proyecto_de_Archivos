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
    public partial class newReservacion : Form
    {
        public newReservacion()
        {
            InitializeComponent();
        }

        private void newReservacion_Load(object sender, EventArgs e)
        {
            dataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addReservacion reservacion = new addReservacion();
            reservacion.ShowDialog();
        }
    }
}
