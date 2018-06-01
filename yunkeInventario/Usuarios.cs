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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = conexion.getNivel();
            comboBox1.DisplayMember = "Nombre";
            dataGridView1.DataSource = conexion.getUsuario();
        }

        private void btnTipoAdd_Click(object sender, EventArgs e)
        {
            conexion.addUsuario(tbname.Text, tbuser.Text, tbpass.Text, comboBox1.Text);
            dataGridView1.DataSource = conexion.getUsuario();
        }
    }
    
}
