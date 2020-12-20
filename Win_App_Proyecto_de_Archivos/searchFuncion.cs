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
    public partial class searchFuncion : Form
    {
        control control = new control();
        public searchFuncion()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyNum(e);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.TextLength != 0)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void searchFuncion_Load(object sender, EventArgs e)
        {
            dataCine1.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] datos;
                if (txtNombre.TextLength == 0)
                    throw new Exception();
                datos = dataCine1.funciones.Select("id='" + txtNombre.Text + "'");

                if (datos.Length > 0)
                {
                    DataRow[] datosPeli;
                    DataRow[] datosSala;
                    datosPeli = dataCine1.peliculas.Select("id='" + datos[0]["id_pelicula"] + "'");
                    datosSala = dataCine1.salas.Select("id='" + datos[0]["id_sala"] + "'");
                    
                    infoFuncion funcion = new infoFuncion();
                    funcion.lblId.Text = datos[0]["id"].ToString();
                    funcion.lblId_pelicula.Text = datosPeli[0]["nombre"].ToString();
                    funcion.lblId_sala.Text = datosSala[0]["nombre"].ToString();
                    funcion.lblHora.Text = datos[0]["hora_inicio"].ToString();
                    funcion.ShowDialog();
                    if (funcion.DialogResult == DialogResult.Yes)
                    {
                        datos[0].Delete();
                        dataCine1.WriteXml(Application.StartupPath + "\\Cine.xml");
                    }
                    if (funcion.DialogResult == DialogResult.No)
                    {
                        changeFuncion funcion1 = new changeFuncion();
                        funcion1.lblId.Text = datos[0]["id"].ToString();
                        funcion1.ShowDialog();
                        if (funcion1.DialogResult == DialogResult.Yes)
                        {
                            datosPeli = dataCine1.peliculas.Select("nombre='" + funcion1.cbPelicula.Text + "'");
                            datosSala = dataCine1.salas.Select("nombre='" + funcion1.cbSala.Text + "'");
                            datos[0]["id"] = funcion1.lblId.Text;
                            datos[0]["id_pelicula"] = datosPeli[0]["id"];
                            datos[0]["id_sala"] = datosSala[0]["id"];
                            #region Hora
                            string b;
                            string a = funcion1.dateTimeFecha.Value.ToString();
                            char[] espacio = { ' ' };
                            string[] trozos = a.Split(espacio);
                            if (funcion1.numMinuto.Value < 10)
                                b = trozos[0] + " " + funcion1.numHora.Value.ToString() + ":0" + funcion1.numMinuto.Value.ToString() + ":00";
                            else
                                b = trozos[0] + " " + funcion1.numHora.Value.ToString() + ":" + funcion1.numMinuto.Value.ToString() + ":00";

                            #endregion
                            datos[0]["hora_inicio"] = b;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
