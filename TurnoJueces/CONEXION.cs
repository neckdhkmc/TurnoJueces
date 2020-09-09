using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace TurnoJueces
{
    class CONEXION
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-4BK74NR\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");

        //SqlConnection con = new SqlConnection("Server=(local); Initial Catalog = Turnos; Integrated Security = True");
        private SqlCommandBuilder cmb;//GENERA AUTOMATICAMENTE COMANDO SQL 
        public DataSet ds = new DataSet(); // SE GUARDA UNA COPIA DE LA BD 
        public SqlDataAdapter da;//ADAPTA LOS COMANDOS DE QSL A LAS TABLAS
        public SqlCommand comando; // CREAMOS UN METODO  LLAMADO COMANDO 

        SqlDataReader dr;
        SqlCommand cmd;
        public void conectar() {

            try
            {
                con.Open();
            }
            catch {
                MessageBox.Show("CONEXION REALIZADA");
            }

          

        }
        public void desconectar() {
            con.Close();

        }

        public void consulta(string sql, string tabla) {

            ds.Tables.Clear();

            da = new SqlDataAdapter(sql, con);//ADAPTAMOS LOS CAMPOS  DE LA TABLA 
            cmb = new SqlCommandBuilder(da);// GUARDAMOS EN MEMORIA 
            da.Fill(ds, tabla);//ACTUALIZA PARA QUE COINCIDAN LOS CAMPOS 


        }
        public bool insertar(string sql)//CREAMOS EL METODO INSERTAR  QUE SERA DE TIPO BOOLEANO 
        {
            con.Open();//ABRIMOS LA CONEXION CON LA BASE 
            comando = new SqlCommand(sql, con);// MANDAMOS LLAMAR EL METODO COMANDO  Y CREAMOS UN NUEVO QUERY A LA BASE 
            int i = comando.ExecuteNonQuery();//DECLARAMOS  LA VARIABLE I = QUERY DE INSERCION 
            con.Close();//cerramos la conexion
            if (i > 0)// SI LA INSERCION TIENE MAS DE UN DATO 
            {

                return true;// ENTONCES  RETORNAMOS VERDADERO 
            }
            else// SI NO 
            {
                return false;

            }

        }
        public bool eliminar(string tabla, string condicion)//CREAMOS EL METODO ELIMINAR 
        {
            con.Open();// ABRIMOS LA CONEXION 
            string elimina = " delete from " + tabla + " where " + condicion;
            comando = new SqlCommand(elimina, con);

            int i = comando.ExecuteNonQuery();//DECLARAMOS  LA VARIABLE I = QUERY DE INSERCION 
            con.Close();//cerramos la conexion

            if (i > 0)
            {
                return true;


            }

            else
            {


            }
            return false;
        }
        public bool eliminar2(string tabla)//CREAMOS EL METODO ELIMINAR 
        {
            con.Open();// ABRIMOS LA CONEXION 
            string elimina = " delete from " + tabla;
            comando = new SqlCommand(elimina, con);

            int i = comando.ExecuteNonQuery();//DECLARAMOS  LA VARIABLE I = QUERY DE INSERCION 
            con.Close();//cerramos la conexion

            if (i > 0)
            {
                return true;


            }

            else
            {


            }
            return false;
        }
        public bool actualizar(string tabla, string campos, string condicion)
        {

            con.Open();
            string actualizar = "update " + tabla + " Set " + campos + " where " + condicion;
            SqlCommand comando = new SqlCommand(actualizar, con);
            int i = comando.ExecuteNonQuery();

            con.Close();
            if (i > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }

        public bool actualizar_CAUSAPENAL(string tabla, string campos, string condicion)
        {

            //con.Open();
            string actualizar = "update " + tabla + " Set " + campos + " where " + condicion;
            SqlCommand comando = new SqlCommand(actualizar, con);
            int i = comando.ExecuteNonQuery();

            //con.Close();
            if (i > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }
        public bool actualizar_CAMPOS(string tabla, string campos)
        {

            con.Open();
            string actualizar = "update " + tabla + " Set " + campos;
            SqlCommand comando = new SqlCommand(actualizar, con);
            int i = comando.ExecuteNonQuery();

            con.Close();
            if (i > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }
        public bool actualizar_numericos(string tabla, string campo, string condicion)
        {

            con.Open();
            string actualizar_numericos = "update " + tabla + " Set " + campo  + " where " +condicion;
          
            SqlCommand comando = new SqlCommand(actualizar_numericos, con);
            int i = comando.ExecuteNonQuery();

            con.Close();
            if (i > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }
        public bool Eliminar_Disponibilidad(string tabla)//CREAMOS EL METODO ELIMINAR 
        {
            con.Open();// ABRIMOS LA CONEXION 
            string elimina = " delete from " + tabla;
            comando = new SqlCommand(elimina, con);

            int i = comando.ExecuteNonQuery();//DECLARAMOS  LA VARIABLE I = QUERY DE INSERCION 
            con.Close();//cerramos la conexion

            if (i > 0)
            {
                return true;


            }

            else
            {


            }
            return false;
        }
        public void llenarNombre(ComboBox cb)//metodo para llenar combo del formulario editar causa penal
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("Select NOMBRE from Jueces", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["NOMBRE"].ToString());
                }
                cb.SelectedIndex = 0;
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el ComboBox: " + ex.ToString());
            }

        }
        public static DataTable Buscar(string NUM_OFICIO)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection("Data Source = DESKTOP-4BK74NR\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");
            //SqlConnection con = new SqlConnection("Server=(local); Initial Catalog = Turnos; Integrated Security = True");
            string consulta = "SELECT CARPETA_JUDICIAL,FECHA_RECEPCION, DELITO, JUEZ, DEPENDENCIA FROM Causa_Penal WHERE NUM_OFICIO=@NUM_OFICIO"; //consulta

            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@NUM_OFICIO", NUM_OFICIO);
            SqlDataAdapter adap = new SqlDataAdapter(comando);
            adap.Fill(dt);

            return dt;
        }


    }
}
