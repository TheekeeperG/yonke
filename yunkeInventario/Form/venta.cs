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
    public partial class venta : Form
    {
        public venta()
        {
            InitializeComponent();
        }

        private void venta_Load(object sender, EventArgs e)
        {
            string cliente = "";
            cliente1 = cliente;
            while (cliente1 == "") {
                MessageBox.Show("Por favor, seleccione un cliente.");
                NavReg nav = new NavReg();
                nav.ShowDialog();
            }
            if (cliente1 == "-1") { 
            if (this.Controls.Count > 0)
            {
                this.Controls.RemoveAt(0);
            } }
            codigo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void llenarCarrito() {
            try
            {
                string codigov = (codigo.Text);
                codigo.Clear();
                if (id_venta == -1)
                {
                    id_venta = conexion.getMaxId_venta();
                    id_venta++;
                }
                try {
                    string prod = conexion.getDisProducto(codigov);
                    if (prod == "No Disponible")
                    {
                        Form msg = new msg("Producto no disponible", "El producto que se intentó agregar  no esta disponible.", "Error: 4", true);
                        msg.ShowDialog();
                    }
                    else if (prod == "No existe")
                    {
                        Form msg = new msg("Producto no encontrado", "El producto que se intentó agregar no existe.", "Error: 4", true);
                        msg.ShowDialog();
                    }
                    else
                    {
                        conexion.addCarrito(codigov, id_venta);
                        dataGridView2.DataSource = conexion.getCarrito(id_venta);
                        label2.Text = cliente2;
                    }
                }

                catch
                {
                    Form msg = new msg("Producto no encontrado", "El producto que se intentó agregar no existe o no esta disponible.", "Error: 4", true);
                    msg.ShowDialog();
                }
            }
            catch {
                Form msg = new msg("Producto no encontrado", "El producto que se intentó agregar no existe o no esta disponible.", "Error: 4", true);
                msg.ShowDialog();
            }
        }
        private int id_venta = -1;
        public static string cliente1 = "";
        public static string cliente2 = "";
        private void codigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               llenarCarrito();
            }

        }

        private void codigo_Leave(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void venta_MouseEnter(object sender, EventArgs e)
        {
            label2.Text = cliente2; 
        }

        private void tableLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            label2.Text = cliente2; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double total=0;
         
            for (int i = 0; i< dataGridView2.RowCount-1; i++) {
              total +=  double.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
            }
            label3.Text = total.ToString(); 
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       
            if (dataGridView2.ColumnCount != 0)
            {
                if (radioButton1.Checked)
                {
                    conexion.addVenta(id_venta.ToString(), cliente1, DateTime.Now, label3.Text, "0");
                    MessageBox.Show("Venta realizada");
                    dataGridView2.DataSource = new DataTable(); 
                }
                else if (radioButton2.Checked)
                {

                    int max = conexion.addDeuda(cliente1, label3.Text, 3);

                    conexion.addVenta(id_venta.ToString(), cliente1, DateTime.Now, label3.Text, max.ToString());
                    MessageBox.Show("Venta realizada");
                    dataGridView2.DataSource = new DataTable();
                }
                else if (radioButton3.Checked)
                {

                    int max = conexion.addDeuda(cliente1, label3.Text, 6);

                    conexion.addVenta(id_venta.ToString(), cliente1, DateTime.Now, label3.Text, max.ToString());
                    MessageBox.Show("Venta realizada");
                    dataGridView2.DataSource = new DataTable();
                }
                else 
                {

                    int max = conexion.addDeuda(cliente1, label3.Text, 9);

                    conexion.addVenta(id_venta.ToString(), cliente1, DateTime.Now, label3.Text, max.ToString());
                    MessageBox.Show("Venta realizada");
                    dataGridView2.DataSource = new DataTable();
                }
            }
         
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = cliente2;
             
            if (label2.Text == "Mostrador")
            {

                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
            }
            else {
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
            }
            if (label2.Text != "")
            {
                timer2.Enabled = true;
            }
        }
    }
}
