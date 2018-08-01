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
    public partial class NavReg : Form
    {
        public NavReg()
        {
            InitializeComponent();
        }

        private void NavReg_Load(object sender, EventArgs e)
        {

        }
        private void LoadForm(Object formOp)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form opened = formOp as Form;
            opened.TopLevel = false;
            opened.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(opened);
            this.panel1.Tag = opened;
            opened.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            venta.cliente1 = "8";
            venta.cliente2 = "Mostrador";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new cliente());
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
      
            this.Close();
        }
      

        private void panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            cerrar.Text = "       "+ venta.cliente2;  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            venta.cliente1 = "-1";
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new clienteRegistrado());
        }
    }
}
