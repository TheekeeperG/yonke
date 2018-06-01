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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form view = new DataView("Tipos");
            view.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Producto_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = conexion.getTipoNom();
            comboBox1.DisplayMember = "Nombre";
            dataGridView1.DataSource = conexion.getProd();
        }

        private void btnTipoAdd_Click(object sender, EventArgs e)
        {
            conexion.addProducto(tbPrecio.Text, tbCodigo.Text, tbEstado.Text, comboBox1.Text);

            dataGridView1.DataSource = conexion.getProd();
        }
    }
}
