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
    public partial class pagos : Form
    {
        public pagos()
        {
            InitializeComponent();
        }

        private void pagos_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hay pagos sin realizar este mes", "Adeudos",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            date1 = new DateTime(date1.Year, date1.Month, 1);
           
            date = date.AddMonths(1);
            int max = DateTime.DaysInMonth(date.Year, date.Month);
            date = new DateTime(date.Year, date.Month, max);
            dataGridView1.DataSource = conexion.getAlarma(date, date1);
        }
    }
}
