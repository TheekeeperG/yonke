using System;
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
    public partial class Tipo : Form
    {
        public Tipo()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tipo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.gettipo();
        }

        private void btnTipoAdd_Click(object sender, EventArgs e)
        {
            conexion.addTipo(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = conexion.gettipo();
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
