﻿using System;
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
    public partial class newCliente : Form
    {
        public newCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addCliente cliente = new addCliente();
            cliente.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchCliente cliente = new searchCliente();
            cliente.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            reportviewerCliente cliente = new reportviewerCliente();
            cliente.ShowDialog();
        }

        private void newCliente_Load(object sender, EventArgs e)
        {
            dataCine.ReadXml(Application.StartupPath + "\\Cine.xml");
        }
    }
}
