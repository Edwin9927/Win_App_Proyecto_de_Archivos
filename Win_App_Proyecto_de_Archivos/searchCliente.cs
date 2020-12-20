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
    public partial class searchCliente : Form
    {
        string dato;
        public searchCliente()
        {
            InitializeComponent();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] datos;
                if (cbOpcion.SelectedItem == null)
                    throw new Exception();

                if (cbOpcion.SelectedItem.Equals("Id") && cbOpcion.SelectedItem != null)
                    datos = dataCine1.clientes.Select("id='" + txtNombre.Text + "'");
                else
                    datos = dataCine1.clientes.Select("apellido='" + txtNombre.Text + "'");

                if (datos.Length > 0)
                {
                    infoCliente infoCliente = new infoCliente();
                    infoCliente.lblNombre.Text = datos[0]["nombre"].ToString();
                    infoCliente.lblId.Text = datos[0]["id"].ToString();
                    infoCliente.lblApellido.Text = datos[0]["apellido"].ToString();
                    infoCliente.lblEmail.Text = datos[0]["email"].ToString();
                    infoCliente.ShowDialog();
                    if (infoCliente.DialogResult == DialogResult.Yes)
                    {
                        datos[0].Delete();
                        dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
                    }
                    if (infoCliente.DialogResult == DialogResult.No)
                    {
                        changeCliente cliente = new changeCliente();
                        cliente.lblId.Text = datos[0]["id"].ToString();
                        cliente.txtNombre.Text = datos[0]["nombre"].ToString();
                        cliente.txtApellido.Text = datos[0]["apellido"].ToString();
                        cliente.txtEmail.Text = datos[0]["email"].ToString();
                        cliente.ShowDialog();
                        if (cliente.DialogResult == DialogResult.Yes)
                        {
                            datos[0]["id"] = cliente.lblId.Text;
                            datos[0]["nombre"] = cliente.txtNombre.Text;
                            datos[0]["apellido"] = cliente.txtApellido.Text;
                            datos[0]["email"] = cliente.txtEmail.Text;
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

        private void searchCliente_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }
    }
}
