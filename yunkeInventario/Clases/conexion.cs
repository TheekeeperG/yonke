using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            db.Server = "192.168.43.198";
            db.UserID = "root";
            db.Password = "fiora1305";
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

            MySqlCommand com = new MySqlCommand(string.Format("insert into tipos (nombre, descripcion) values ('" + name + "','" + descr + "');"), con);
            int n = com.ExecuteNonQuery();
        }
        public static DataTable getNivel() {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select nombre from NivelesAcceso where id_nivel < 9"), con);
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
            MySqlCommand com = new MySqlCommand(string.Format("select tipos.nombre, precio, codigo, estado from productos join tipos where productos.id_tipo = tipos.id_tipo order by id_producto desc;"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getUsuario()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select * from usuarios where id_nivel < 9"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static int lastIdProd()
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select max(id_producto) from productos;"), con);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            int n = int.Parse(reader["max(id_producto)"].ToString());
            con.Close();
            return n;
        }
        public static void addUsuario(string name, string user, string pass, string lev)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select id_nivel from nivelesacceso where nombre='" + lev + "'"), con);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            int n = int.Parse(reader["id_nivel"].ToString());
            con.Close();


            con = conexion.conection();
            com = new MySqlCommand(string.Format("insert into usuarios (nombre, usuario, password, id_nivel) values ('" + name + "','" + user + "','" + pass + "','" + n + "');"), con);
            n = com.ExecuteNonQuery();
        }
        public static void addVenta(string id, string id_cliente, DateTime fecha, string total, string deuda) {
            MySqlConnection con = conexion.conection();
            MySqlConnection con1 = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("insert into ventas (id_venta,id_cliente, fecha, total, deuda) values (" + id + "," + id_cliente + ",'" + fecha.ToString("yyyy-MM-dd") + "','" + total + "','" + deuda + "');"), con);
            MySqlDataReader reader = com.ExecuteReader();
            con.Close();
            MySqlCommand com1 = new MySqlCommand(string.Format("UPDATE productos join carritos  SET productos.estado='No Disponible'  where productos.id_producto = carritos.id_producto and carritos.id_venta =" + id + ";"), con1);
            MySqlDataReader reader1 = com1.ExecuteReader();
        }
        public static int addDeuda(string id_cliente, string total, int mens)
        {
            double pre = double.Parse(total);
            double men = pre / mens;
            double interes = 0;
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("insert into deudas(mensualidades, interes, id_cliente, mensualidad, total) values (" + mens + "," + interes + "," + id_cliente + "," + men + ", " + pre + ");"), con);
            int na = com.ExecuteNonQuery();
            int max = 0;
            MySqlConnection con1 = conexion.conection();
            MySqlCommand com1 = new MySqlCommand(string.Format("select max(id_deuda) from deudas;"), con);
            MySqlDataReader reader = com1.ExecuteReader();
            int n;
            try
            {
                reader.Read();

                n = int.Parse(reader["max(id_deuda)"].ToString());
                con.Close();
            }
            catch
            {
                n = 0;
            }
            DateTime date = DateTime.Today;
            for (int i = 0; i < mens; i++) {

                con.Open();
                int maxf = DateTime.DaysInMonth(date.Year, date.Month);
                date = new DateTime(date.Year, date.Month, maxf);

                MySqlCommand com2 = new MySqlCommand(string.Format("insert into pagos(id_deuda, id_cliente, fecha, estado) values (" + n + "," + id_cliente + ",'" + date.ToString("yyyy-MM-dd") + "','" + "No pagado" + "');"), con);
                int no = com2.ExecuteNonQuery();
                date = date.AddMonths(1);
                con.Close();
            }
            return n;
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

        public static void addCliente(string name, string last, string dir, string phone, string rfc)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("insert into clientes (nombre, apellido, direccion, telefono,rfc) values ('" + name + "','" + last + "','" + dir + "','" + phone + "'"+ rfc+"');"), con);
         
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
            MySqlCommand com = new MySqlCommand(string.Format("select * from clientes where nombre != 'Mostrador'"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static DataTable getAlarma(DateTime date, DateTime date1)
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select cl.nombre ,pa.fecha, pa.estado, de.mensualidades, de.mensualidad, de.total from clientes cl join deudas de join pagos pa where cl.id_cliente = de.id_cliente and pa.id_deuda = de.id_deuda and pa.fecha <= '" + date.ToString("yyyy-MM-dd")+"' and pa.fecha >= '"+date1.ToString("yyyy-MM-dd")+"' order by pa.fecha;"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        public static bool getAlarmaQ(DateTime date, DateTime date1)
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select cl.nombre ,pa.fecha, pa.estado, de.mensualidades, de.mensualidad, de.total from clientes cl join deudas de join pagos pa where cl.id_cliente = de.id_cliente and pa.id_deuda = de.id_deuda and pa.fecha <= '" + date.ToString("yyyy-MM-dd") + "' and pa.fecha >= '" + date1.ToString("yyyy-MM-dd") + "' order by pa.fecha;"), con);
            MySqlDataReader reader = com.ExecuteReader();
            if (reader.Read()) { return true; }
            else { return false; }
        }
        public static DataTable getVentas()
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select ventas.id_venta, productos.codigo, productos.precio, clientes.nombre, clientes.apellido, ventas.total from productos join clientes join ventas join carritos where carritos.id_venta = ventas.id_venta and ventas.id_cliente = clientes.id_cliente and productos.id_producto = carritos.id_producto;" +
                ""), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
        /*select ventas.id_venta, productos.codigo, productos.precio, clientes.nombre, clientes.apellido, ventas.total from productos join clientes join ventas join carritos where carritos.id_venta = ventas.id_venta and ventas.id_cliente = clientes.id_cliente;*/
        public static int getMaxId_venta() {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select max(id_venta) from carritos;"), con);
            MySqlDataReader reader = com.ExecuteReader();
            int n;
            try { reader.Read();
            
                 n = int.Parse(reader["max(id_venta)"].ToString());
                con.Close();
            }
            catch {
                n = 0; 
            }
            return n;
        }
        public static string getDisProducto(string cod)
        {
            MySqlConnection con = conexion.conection();
            MySqlCommand com = new MySqlCommand(string.Format("select estado from productos where codigo="+cod +" ;"), con);
            MySqlDataReader reader = com.ExecuteReader();
            string n;
            try
            {
                reader.Read();

                n = reader["estado"].ToString();
                con.Close();
            }
            catch
            {
                n = "No existe";
            }
            return n;
        }

        public static void addCarrito(string name, int descr)
        {


            MySqlConnection con = conexion.conection();
            MySqlConnection con1 = conexion.conection();

            MySqlCommand com = new MySqlCommand(string.Format("select id_producto from productos where codigo ='"+ name+"';"), con);
            MySqlDataReader reader = com.ExecuteReader();
            int n1;
            try
            {
                reader.Read();

                n1 = int.Parse(reader["id_producto"].ToString());
               
            }
            catch
            {
                n1 = 0;
               
            }
           
        MySqlCommand com1 = new MySqlCommand(string.Format("insert into carritos (id_producto, id_venta) values ('" + n1 + "','" + descr + "');"), con1);
            int n = com1.ExecuteNonQuery();
        }
        public static DataTable getCarrito(int i)
        {
            MySqlConnection con = conexion.conection();

            DataTable dt = new DataTable();
            MySqlCommand com = new MySqlCommand(string.Format("select productos.codigo, tipos.nombre, productos.precio from productos join tipos join carritos where productos.id_tipo = tipos.id_tipo and carritos.id_producto = productos.id_producto and carritos.id_venta="+i+";"), con);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            adap.Fill(dt);

            return dt;

        }
    }
   
}
