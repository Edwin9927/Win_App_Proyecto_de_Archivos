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
    public partial class addPelicula : Form
    {
        control control = new control();
        int tiempo=-1;
        public addPelicula()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.TextLength != 0)
                {
                    txtNumero.Focus();
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyNum(e);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNumero.TextLength != 0)
                {
                    tiempo = int.Parse(txtNumero.Text);
                    btnAceptar.Focus();
                }
            }
        }

        private void addPelicula_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNumero.TextLength != 0 && txtNombre.TextLength != 0)
            {
                object[] datos = new object[3];
                datos[1] = txtNombre.Text;
                datos[2] = tiempo;

                dataCine1.peliculas.Rows.Add(datos);

                dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");

                MessageBox.Show("Pelicula agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
