﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yunkeInventario
{
    public partial class reportes : Form
    {
        public reportes()
        {
            InitializeComponent();
        }

        private void reportes_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = conexion.getVentas();
        }
    }
}
