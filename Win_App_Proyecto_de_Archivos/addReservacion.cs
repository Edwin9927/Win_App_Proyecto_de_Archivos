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
    public partial class addReservacion : Form
    {
        public addReservacion()
        {
            InitializeComponent();
        }

        private void addReservacion_Load(object sender, EventArgs e)
        {
            dataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblCliente.Text != "--")
            {
                object[] datos = new object[3];
                datos[1] = cbFuncion.Text;
                datos[2] = cbCliente.Text;
                try
                {
                    dataCine.reservaciones.Rows.Add(datos);

                    dataCine.WriteXml(Application.StartupPath + "\\Cine.xml");

                    MessageBox.Show("Reservación agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error al intentar hacer la reservación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Por favor, seleccione una funcion y/o un cliente","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void cbPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] datos;
            datos = dataCine.funciones.Select("id='" + cbFuncion.Text + "'");
            DataRow[] datosSala;
            datosSala = dataCine.salas.Select("id='" + datos[0]["id_sala"] + "'");
            lblSala.Text = datosSala[0]["nombre"].ToString();
            DataRow[] datosPeli;
            datosPeli = dataCine.peliculas.Select("id='" + datos[0]["id_pelicula"] + "'");
            lblPelicula.Text = datosPeli[0]["nombre"].ToString();
            lblHora.Text = datos[0]["hora_inicio"].ToString();
        }

        private void cbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] datos;
            datos = dataCine.clientes.Select("id='" + cbCliente.Text + "'");
            lblCliente.Text = datos[0]["Nombre"].ToString() + " " + datos[0]["apellido"].ToString(); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
