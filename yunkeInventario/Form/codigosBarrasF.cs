using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.Drawing.Imaging; 

namespace yunkeInventario
{
    public partial class codigosBarrasF : Form
    {
        public codigosBarrasF(string idp, string tipop)
        {
            InitializeComponent();
            id = idp;
            tipo = tipop;

        }
        public string tipo;
        public string id;
        private void codigosBarrasF_Load(object sender, EventArgs e)
        {
            string id_def = tipo + " 301" + id;
            
            label2.Text = id_def;
            id_def = "301" + id;
            Login.usuario.code = id_def;
            BarcodeLib.Barcode code = new BarcodeLib.Barcode();
            code.IncludeLabel = true;
            pictureBox1.Image = code.Encode(BarcodeLib.TYPE.CODE128, label2.Text, Color.Black, Color.White);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = (Image)pictureBox1.Image.Clone();
            SaveFileDialog box = new SaveFileDialog();
            img.Save(@"F:\codigosBarras\" + label2.Text + ".png", ImageFormat.Png);
            /*  box.AddExtension = true;

              box.Filter = "Image PNG (*.png|*.png";
              box.ShowDialog();
              if (!string.IsNullOrEmpty(box.FileName)) {
                  img.Save(box.FileName, ImageFormat.Png);
              }
              img.Dispose();
              MessageBox.Show(box.FileName);
          }*/
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
