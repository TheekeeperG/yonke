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
    public partial class msg : Form
    {
        string t, m, er;
        bool cl;
        public msg(string titulo, string mensaje, string error, bool cerrar)
        {
            InitializeComponent();
            t = titulo;
            m = mensaje;
            er = error;
            cl = cerrar; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cl)
                this.Close();
            else

                Application.Exit(); 
        }

        private void msg_Load(object sender, EventArgs e)
        {
            label1.Text = t;
            richTextBox1.Text = m;
            if (!cl)
                richTextBox1.Text += " La aplicación debe cerrarse.";
            label3.Text = er; 
        }
    }
}
