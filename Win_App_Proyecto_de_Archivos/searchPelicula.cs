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
    public partial class searchPelicula : Form
    {
        public searchPelicula()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.TextLength != 0)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] datos;
                if (cbOpcion.SelectedItem == null)
                    throw new Exception();
                if (cbOpcion.SelectedItem.Equals("Id") && cbOpcion.SelectedItem != null)
                    datos = dataCine1.peliculas.Select("id='" + txtNombre.Text + "'");
                else
                    datos = dataCine1.peliculas.Select("nombre='" + txtNombre.Text + "'");

                if (datos.Length > 0)
                {
                    infoPelicula infoPelicula = new infoPelicula();
                    infoPelicula.lblNombre.Text = datos[0]["nombre"].ToString();
                    infoPelicula.lblId.Text = datos[0]["id"].ToString();
                    infoPelicula.lblNum.Text = datos[0]["length_min"].ToString();
                    infoPelicula.ShowDialog();
                    if (infoPelicula.DialogResult == DialogResult.Yes)
                    {
                        datos[0].Delete();
                        dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
                    }
                    if (infoPelicula.DialogResult == DialogResult.No)
                    {
                        changePelicula pelicula = new changePelicula();
                        pelicula.lblId.Text = datos[0]["id"].ToString();
                        pelicula.txtNombre.Text = datos[0]["nombre"].ToString();
                        pelicula.txtNum.Text = datos[0]["length_min"].ToString();
                        pelicula.ShowDialog();
                        if (pelicula.DialogResult == DialogResult.Yes)
                        {
                            datos[0]["id"] = pelicula.lblId.Text;
                            datos[0]["nombre"] = pelicula.txtNombre.Text;
                            datos[0]["length_min"] = pelicula.txtNum.Text;
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

        private void searchPelicula_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }
    }
}
