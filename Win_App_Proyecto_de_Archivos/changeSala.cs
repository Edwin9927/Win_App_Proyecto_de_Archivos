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
    public partial class changeSala : Form
    {
        control control = new control();
        public changeSala()
        {
            InitializeComponent();
        }

        private void changeSala_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.TextLength != 0)
                {
                    txtNum.Focus();
                }
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyNum(e);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNum.TextLength != 0 && txtNum.TextLength < 3)
                {
                    btnAceptar.Focus();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos actualizados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
