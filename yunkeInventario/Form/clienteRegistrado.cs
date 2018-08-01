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
    public partial class clienteRegistrado : Form
    {
        public clienteRegistrado()
        {
            InitializeComponent();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
         
        }

        private void clienteRegistrado_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            venta.cliente1 = dataGridView1.CurrentRow.Cells["id_cliente"].Value.ToString();

            this.Close();
        }

        private void clienteRegistrado_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.getCliente();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                codigo.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                venta.cliente2 = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString()+" "+ dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();

            }
        }
    }
}
