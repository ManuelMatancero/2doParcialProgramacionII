using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
    public class L_Persona
    {
        //Objeto de la clase D_Persona
        D_Persona d_Persona = new D_Persona();

        //Metodo insertar
        public void insertPersonaL(E_Persona e_Persona)
        {
            d_Persona.insertPersona(e_Persona);
        }

        //Metodo Editar
        public void updatePersonaL(E_Persona e_Persona)
        {
            d_Persona.updatePersona(e_Persona);
        }

        //Metodo Eliminar
        public void deletePersonaL(string id)
        {
            d_Persona.deletePersona(id);
        }

        //Metodo Listar
        public List<E_Persona> searchPersonaL(string buscar)
        {
            return d_Persona.listarPersonas(buscar);
        }

        //Metodo que me devuelve un dataSet con los datos que hay en la base de datos
        public DataSet mostrarDatosN()
        {
            return d_Persona.mostrarDatos();
        }



    }
}
