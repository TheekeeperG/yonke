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
    public partial class DataView : Form
    {
        private string table; 
        public DataView(string tableP)
        {
            InitializeComponent();
            table = tableP; 
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.getTableView(table);
        }
    }
}
