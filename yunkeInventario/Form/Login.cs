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
    public partial class Login : Form
    {
        public static Usuario usuario = new Usuario();
        public Login()
        {
            InitializeComponent();
        }
        public static void unhide() {
            
        }
        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "USUARIO") {
                txtname.Text = ""; 
            }
            
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "") {
                txtname.Text = "USUARIO"; 
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "CONTRASEÑA") {
                txtpassword.Text = "";
                txtpassword.UseSystemPasswordChar = Enabled; 
            }

        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "") {
                txtpassword.Text = "CONTRASEÑA";
                txtpassword.UseSystemPasswordChar = false; 

            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.DarkGray;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor =  Color.FromArgb(130, 52, 102);
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.DarkGray;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(130, 52, 102);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                string name = txtname.Text;
                string pass = txtpassword.Text;
                DataTable dt = new DataTable();
                try
                {
                    dt = conexion.login(name, pass);
                }
                catch
                {
                    Form msg = new msg("Error con la base de datos", "Hubó un error al intentar conectarse a la base de datos, por favor revise las configuraciones y vuelva a intentarlo.", "Error: 1", false);
                    msg.ShowDialog();
                   
                }try
            {
                usuario.id = dt.Rows[0]["id_usuario"].ToString();
                usuario.name = dt.Rows[0]["nombre"].ToString();
                usuario.pass = dt.Rows[0]["password"].ToString();
                usuario.user = dt.Rows[0]["usuario"].ToString();
                usuario.level = dt.Rows[0]["id_nivel"].ToString();
                Hide();
                if (usuario.level == "1")
                {
                    using (Nav mainNav = new Nav())
                        mainNav.ShowDialog();
                    Show();
                }
                else if (usuario.level == "9")
                {
                    using (SU mainNav = new SU())
                        mainNav.ShowDialog();
                    Show();
                }
                else
                {
                    using (NavMort mainNav = new NavMort())
                        mainNav.ShowDialog();
                    Show();
                }
            }
            catch {
                Form msg = new msg("Error fatal", "Hubó un error que impide que la aplicación siga funcionando.", "Error: 5", true);
                msg.ShowDialog();
            }

         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
