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
            try
            {
                if (textBox1.Text != "Nombre" && textBox2.Text != "Descripción")
                {
                    conexion.addTipo(textBox1.Text, textBox2.Text);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = conexion.gettipo();
                }
                else
                {
                    Form msg = new msg("No se pudó ingresar los datos correctamente", "Por favor revise  los campos y vuelva a intentarlo", "Error: 3", true);
                    msg.ShowDialog();
                }
            }
            catch {
                Form msg = new msg("No se pudó ingresar los datos correctamente", "Por favor revise  los campos y vuelva a intentarlo", "Error: 3", true);
                msg.ShowDialog();
            }
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nombre")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nombre";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Descripción")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Descripción";
            }
        }
    }
}
