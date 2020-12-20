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
    public partial class addSala : Form
    {
        control control = new control();
        string nombre;
        int numero;
        public addSala()
        {
            InitializeComponent();
        }

        private void addSala_Load(object sender, EventArgs e)
        {
            dataCine.ReadXml(Application.StartupPath + "\\Sala.xml");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtNombre.Text.Length == 0 || txtNombre.TextLength > 25)
                {
                    txtNombre.Clear();
                    MessageBox.Show("Ingrese en nombre válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    nombre = txtNombre.Text;
                    txtNumero.Focus();
                }           
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.OnlyNum(e);
            if(e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    if (txtNumero.TextLength == 0 || txtNumero.TextLength > 2)
                        throw new Exception();
                    else
                    {
                        numero = int.Parse(txtNumero.Text);
                        btnAceptar.Focus();
                    }
                }
                catch
                {
                    txtNumero.Clear();
                    MessageBox.Show("Ingrese un numero válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNumero.TextLength != 0 && txtNombre.TextLength !=0)
            {
                object[] datos = new object[3];
                datos[1] = nombre;
                datos[2] = numero;

                dataCine.salas.Rows.Add(datos);

                dataCine.WriteXml(Application.StartupPath + "\\Sala.xml");

                MessageBox.Show("Sala agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
