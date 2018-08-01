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
    public partial class NavMort : Form
    {
        public NavMort()
        {
            InitializeComponent();
        }

        private void NavMort_Load(object sender, EventArgs e)
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
            this.Close();
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
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new venta());
            lbMov.Text = "Registrar un nuevo producto";
           
        }

        private void tableLayoutPanel3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel3.Width == 193)
            tableLayoutPanel3.Width = 40;
            else
                tableLayoutPanel3.Width = 193;
        }

        private void Container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm(new reportes());
            lbMov.Text = "Reporte";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }


        }
    }
}
