using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace yunkeInventario
{
    class conexion
    {
      
        public static MySqlConnection conection()
        {
            MySqlConnectionStringBuilder db = new MySqlConnectionStringBuilder();
            db.Server = "localhost";
            db.UserID = "root";
            db.Password = "13060613";
            db.Database = "yonke";
            MySqlConnection con = new MySqlConnection(db.ToString());
            con.Open();
            return con;

        }
        public static DataTable login(string name, string password)
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from usuarios where usuario='{0}' and password = '{1}';", name, password), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt; 
        }

        //Formulario Tipo.cs

        public static DataTable gettipo()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from tipos"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;
        }
        public static void addTipo(string name, string descr) {
            MySqlConnection con = conexion.conection();
           
            MySqlCommand com = new MySqlCommand(string.Format("insert into tipos (nombre, descripcion) values ('"+name+"','"+ descr+"');"), con);
             int n = com.ExecuteNonQuery();
        }
        public static DataTable getNivel() {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select nombre from NivelesAcceso"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getTipoNom()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select nombre from tipos"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getProd()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from Productos"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getUsuario()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from usuarios"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static void addUsuario(string name, string user, string pass, string lev)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select id_nivel from nivelesacceso where nombre='"+lev+"'"), con);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            int n = int.Parse(reader["id_nivel"].ToString());
            con.Close();


            con = conexion.conection();
            com = new MySqlCommand(string.Format("insert into usuarios (nombre, usuario, password, id_nivel) values ('" + name + "','" + user + "','" + pass +  "','" + n +"');"), con);
            n = com.ExecuteNonQuery();
        }
        public static void addProducto(string price, string code, string state, string tip)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select id_tipo from tipos where nombre='" + tip + "'"), con);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            int n = int.Parse(reader["id_tipo"].ToString());
            con.Close();


            con = conexion.conection();
            com = new MySqlCommand(string.Format("insert into productos (precio, codigo, estado, id_tipo) values ('" + price + "','" + code + "','" + state + "','" + n + "');"), con);
            n = com.ExecuteNonQuery();
        }
        public static void addCliente(string name, string last, string dir, string phone)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("insert into clientes (nombre, apellido, direccion, telefono) values ('" + name + "','" + last + "','" + dir + "','" + phone + "');"), con);
         
            int   n = com.ExecuteNonQuery();
        }
        public static DataTable getTableView(string table)
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from " + table), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getCliente()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from clientes"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }

    }
   
}
