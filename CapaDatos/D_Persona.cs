using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaDatos
{
    public class D_Persona
    {
        //Objeto de la clase sqlConnection con el strin connection como parametro
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CS3DG9F;Initial Catalog=AGENDELECTRONIC;Integrated Security=True");

        //metodo para insertar en la base de datos
        public void insertPersona(E_Persona e_Persona)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTAR", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", e_Persona.getNombre());
            cmd.Parameters.AddWithValue("@APELLIDO", e_Persona.getApellido());
            cmd.Parameters.AddWithValue("@DIRECCION", e_Persona.getDireccion());
            cmd.Parameters.AddWithValue("@FECHANACIMIENTO", e_Persona.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@CELULAR", e_Persona.getCelular());
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //Metodo para actualizar o editar un registro
        public void updatePersona(E_Persona e_Persona)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PERSONA", e_Persona.getIdPersona());
            cmd.Parameters.AddWithValue("@NOMBRE", e_Persona.getNombre());
            cmd.Parameters.AddWithValue("@APELLIDO", e_Persona.getApellido());
            cmd.Parameters.AddWithValue("@DIRECCION", e_Persona.getDireccion());
            cmd.Parameters.AddWithValue("@FECHANACIMIENTO", e_Persona.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@CELULAR", e_Persona.getCelular());
            cmd.ExecuteNonQuery();
            conexion.Close();

        }


        //metodo eliminar registro
        public void deletePersona(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PERSONA", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //metodo para listar los registros en un objeto de tipo list
        public List<E_Persona> listarPersonas(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_Persona> Listar = new List<E_Persona>();

            while (leerFilas.Read())
            {
                Listar.Add(new E_Persona
                {
                    Idpersona = leerFilas.GetInt32(0),
                    CodigoPersona= leerFilas.GetString(1),
                    Nombre= leerFilas.GetString(2),
                    Apellido= leerFilas.GetString(3),
                    Direccion = leerFilas.GetString(4),
                    FechaNacimiento= leerFilas.GetDateTime(5),
                    Celular=leerFilas.GetString(6)

                });
            }
            conexion.Close();
            return Listar;
        }

        //metodo para mostrar los datos en un dataSet
        public DataSet mostrarDatos()
        {

            conexion.Open();
            string qwery = "select * from PERSONA";
            SqlDataAdapter adaptador = new SqlDataAdapter(qwery, conexion);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);
            conexion.Close();
            return datos;

        }




    }
}
