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
    public partial class Nav : Form
    {
        public Nav()
        {
            InitializeComponent();
        }

        private void Nav_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Login.usuario.name + " esta conectado");
            button6.Text = Login.usuario.name; 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                pictureBox3.Image = Properties.Resources.icon_restaurar; 
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                pictureBox3.Image = Properties.Resources.icon_maximizar;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void LoadForm(Object formOp) {
            if (this.Container.Controls.Count > 0) {
                this.Container.Controls.RemoveAt(0);
            }
            Form opened = formOp as Form;
            opened.TopLevel = false;
            opened.Dock = DockStyle.Fill;
            this.Container.Controls.Add(opened);
            this.Container.Tag = opened;
            opened.Show();
        }

        private void btnTipoReg_Click(object sender, EventArgs e)
        {
            LoadForm(new Tipo());
            lbMov.Text = "Registrar un nuevo tipo";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadForm(new Usuarios());
            lbMov.Text = "Registrar un nuevo usuario";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new Producto());
            lbMov.Text = "Registrar un nuevo producto";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new cliente());
            lbMov.Text = "Registrar un nuevo cliente";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog=  MessageBox.Show("¿Deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) {
                this.Close();  
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
