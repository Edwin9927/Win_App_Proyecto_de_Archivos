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
    public partial class addFuncion : Form
    {
        public addFuncion()
        {
            InitializeComponent();
        }

        private void addFuncion_Load(object sender, EventArgs e)
        {
            dataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            object[] datos = new object[4];
            DataRow[] datosPelicula;
            DataRow[] datosSala;
            datosPelicula = dataCine.peliculas.Select("nombre='" + cbPelicula.Text + "'");
            datosSala = dataCine.salas.Select("nombre='" + cbSala.Text + "'");
            #region Fijacion de la hora y fecha
            string b;
            string a = dateTimeFecha.Value.ToString();
            char[] espacio = { ' ' };
            string[] trozos = a.Split(espacio);
            if (numMinuto.Value < 10)
                b = trozos[0] + " " + numHora.Value.ToString() + ":0" + numMinuto.Value.ToString() + ":00";
            else
                b = trozos[0] + " " + numHora.Value.ToString() + ":" + numMinuto.Value.ToString() + ":00";
            #endregion

            datos[1] = datosPelicula[0]["id"];
            datos[2] = datosSala[0]["id"];
            datos[3] = b;

            try
            {
                dataCine.funciones.Rows.Add(datos);

                dataCine.WriteXml(Application.StartupPath + "\\Cine.xml");

                MessageBox.Show("Funcion agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error al intentar agregar la funcion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close();
        }
    }
}
