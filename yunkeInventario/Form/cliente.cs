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
            try {
                if (tbname.Text != "Nombre" && tblast.Text != "Apellidos" && tbphone.Text != "Telefono" && tbdir.Text != "Direccion") {
                    if (textBox1.Text != "RFC")
                    {
                        conexion.addCliente(tbname.Text, tblast.Text, tbdir.Text, tbphone.Text, textBox1.Text);
                        dataGridView1.DataSource = conexion.getCliente();
                    }
                    else {
                        conexion.addCliente(tbname.Text, tblast.Text, tbdir.Text, tbphone.Text, "");
                        dataGridView1.DataSource = conexion.getCliente();
                    }
                }

                else {
                    Form msg = new msg("No se pudó ingresar los datos correctamente", "Por favor revise  los campos y vuelva a intentarlo", "Error: 3", true);
                    msg.ShowDialog();
                }

            }
            catch  {
                Form msg = new msg("No se pudó ingresar los datos correctamente", "Por favor revise  los campos y vuelva a intentarlo", "Error: 3", true);
                msg.ShowDialog();
            }

        }

        private void cliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.getCliente();
        }

        private void tbname_Enter(object sender, EventArgs e)
        {
            if (tbname.Text == "Nombre") {
                tbname.Clear();
            }
        }

        private void tbname_Leave(object sender, EventArgs e)
        {
            if (tbname.Text == "")
            {
                tbname.Text = "Nombre";
            }
        }

        private void tblast_Leave(object sender, EventArgs e)
        {
            if (tblast.Text == "")
            {
                tblast.Text = "Apellidos";
            }
        }

        private void tblast_Enter(object sender, EventArgs e)
        {
            if (tblast.Text == "Apellidos")
            {
                tblast.Text = "";
            }
        }

        private void tbphone_Leave(object sender, EventArgs e)
        {
            if (tbphone.Text == "")
            {
                tbphone.Text = "Telefono";
            }
        }

        private void tbphone_Enter(object sender, EventArgs e)
        {
            if (tbphone.Text == "Telefono")
            {
                tbphone.Text = "";
            }
        }

        private void tbdir_Enter(object sender, EventArgs e)
        {
            if (tbdir.Text == "Direccion") {
                tbdir.Text = "";
            }
        }

        private void tbdir_Leave(object sender, EventArgs e)
        {
            if (tbdir.Text == "") {
                tbdir.Text = "Direccion";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tbdir.Text == "RFC")
            {
                tbdir.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (tbdir.Text == "")
            {
                tbdir.Text = "RFC";
            }
        }
    }
}
