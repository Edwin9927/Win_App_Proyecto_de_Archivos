using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_App_Proyecto_de_Archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region Funcion para abrir paneles
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            btninicio_Click(null, e);
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            try
            {
                dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
            }
            catch
            {
                dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
            }
            
            AbrirFormEnPanel(new inicio());
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new newSala());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new newCliente());
        }
    }
}
