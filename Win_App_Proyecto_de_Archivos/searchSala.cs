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
    public partial class searchSala : Form
    {
        string dato;
        public searchSala()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] datos;
                if (cbOpcion.SelectedItem == null)
                    throw new Exception();
                if (cbOpcion.SelectedItem.Equals("Id") && cbOpcion.SelectedItem !=null)
                    datos = dataCine1.salas.Select("id='" + txtNombre.Text + "'");
                else
                    datos = dataCine1.salas.Select("nombre='" + txtNombre.Text + "'");

                if (datos.Length > 0)
                {
                    infosala infosala = new infosala();
                    infosala.lblNombre.Text = datos[0]["nombre"].ToString();
                    infosala.lblId.Text = datos[0]["id"].ToString();
                    infosala.lblNum.Text = datos[0]["n_asientos"].ToString();
                    infosala.ShowDialog();
                    if (infosala.DialogResult == DialogResult.Yes)
                    {
                        datos[0].Delete();
                        dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
                    }
                    if (infosala.DialogResult == DialogResult.No)
                    {
                        changeSala sala = new changeSala();
                        sala.lblId.Text = datos[0]["id"].ToString();
                        sala.txtNombre.Text = datos[0]["nombre"].ToString();
                        sala.txtNum.Text = datos[0]["n_asientos"].ToString();
                        sala.ShowDialog();
                        if (sala.DialogResult == DialogResult.Yes)
                        {
                            datos[0]["id"] = sala.lblId.Text ;
                            datos[0]["nombre"] = sala.txtNombre.Text;
                            datos[0]["n_asientos"] = sala.txtNum.Text;
                            datos[0].AcceptChanges();
                            dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
                        }
                    }
                    this.Close();
                }
                else
                {
                    txtNombre.Clear();
                    txtNombre.Focus();
                    MessageBox.Show("No existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Seleccione e ingrese el criterio de busqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.TextLength != 0)
                {
                    dato = txtNombre.Text;
                    btnBuscar.Focus();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchSala_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void cbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
