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
        D_Persona d_Persona = new D_Persona();

        public void insertPersonaL(E_Persona e_Persona)
        {
            d_Persona.insertPersona(e_Persona);
        }

        public void updatePersonaL(E_Persona e_Persona)
        {
            d_Persona.updatePersona(e_Persona);
        }

        public void deletePersonaL(string id)
        {
            d_Persona.deletePersona(id);
        }

        public List<E_Persona> searchPersonaL(string buscar)
        {
            return d_Persona.listarPersonas(buscar);
        }

        public DataSet mostrarDatosN()
        {
            return d_Persona.mostrarDatos();
        }



    }
}
