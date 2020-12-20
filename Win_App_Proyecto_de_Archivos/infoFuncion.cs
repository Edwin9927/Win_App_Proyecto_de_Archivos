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
    public partial class infoFuncion : Form
    {
        DialogResult oDlgRes;
        public infoFuncion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDlgRes = MessageBox.Show("¿Está seguro que desea modificar los datos de la funcion ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (oDlgRes == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oDlgRes = MessageBox.Show("¿Está seguro que desea eliminar la funcion ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (oDlgRes == DialogResult.Yes)
            {
                MessageBox.Show("Cliente borrado exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
