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
    public partial class cliente : Form
    {
        public cliente()
        {
            InitializeComponent();
        }

        private void btnTipoAdd_Click(object sender, EventArgs e)
        {
            conexion.addCliente(tbname.Text, tblast.Text, tbdir.Text, tbphone.Text);
            dataGridView1.DataSource = conexion.getCliente();
        }

        private void cliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.getCliente();
        }
    }
}
