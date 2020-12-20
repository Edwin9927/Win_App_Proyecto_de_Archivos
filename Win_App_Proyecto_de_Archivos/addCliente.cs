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
    public partial class addCliente : Form
    {
        control control = new control();
        public addCliente()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyLet(e);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.TextLength!=0)
                {
                    txtApellido.Focus();
                }
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyLet(e);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtApellido.TextLength != 0)
                {
                    txtEmail.Focus();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtApellido.TextLength != 0 && txtNombre.TextLength != 0)
            {
                object[] datos = new object[4];
                datos[1] = txtNombre.Text;
                datos[2] = txtApellido.Text;
                datos[3] = txtEmail.Text;

                dataCine1.clientes.Rows.Add(datos);

                dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");

                MessageBox.Show("Cliente agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(Char)Keys.Enter)
            {
                if (txtEmail.TextLength != 0)
                {
                    btnAceptar.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCliente_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }
    }
}
