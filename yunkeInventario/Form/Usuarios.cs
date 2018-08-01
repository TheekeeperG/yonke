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

        private
            void btnTipoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbname.Text != "Nombre" && tbuser.Text != "Nombre de usuario" && tbpass.Text != "Contraseña")
                {
                    conexion.addUsuario(tbname.Text, tbuser.Text, tbpass.Text, comboBox1.Text);
                    dataGridView1.DataSource = conexion.getUsuario();
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

        private void tbname_Enter(object sender, EventArgs e)
        {
            if (tbname.Text == "Nombre")
            {
                tbname.Text = "";
            }
        }

        private void tbname_Leave(object sender, EventArgs e)
        {
            if (tbname.Text == "")
            {
                tbname.Text = "Nombre";
            }
        }

        private void tbuser_Enter(object sender, EventArgs e)
        {
            if (tbuser.Text == "Nombre de usuario")
            {
                tbuser.Text = "";
            }
        }

        private void tbuser_Leave(object sender, EventArgs e)
        {
            if (tbuser.Text == "")
            {
                tbuser.Text = "Nombre de usuario";
            }
        }

        private void tbpass_Enter(object sender, EventArgs e)
        {
            if (tbpass.Text == "Contraseña")
            {
                tbpass.Text = "";
                tbpass.UseSystemPasswordChar = Enabled;
            }
        }

        private void tbpass_Leave(object sender, EventArgs e)
        {
            if (tbpass.Text == "")
            {
                tbpass.Text = "Contraseña";
                tbpass.UseSystemPasswordChar = false;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

        }
    }
}
