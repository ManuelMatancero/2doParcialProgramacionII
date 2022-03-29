using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Persona
    {
        //Atributos
        private int idpersona;
        private string codigoPersona;
        private string nombre;
        private string apellido;
        private string direccion;
        private DateTime fechaNacimiento;
        private string celular;

        //Atributos get Set
        public int Idpersona { get => idpersona; set => idpersona = value; }
        public string CodigoPersona { get => codigoPersona; set => codigoPersona = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Celular { get => celular; set => celular = value; }

        //Cosntructor vacio
        public E_Persona()
        {
        }
        //Constructor
        public E_Persona(string nombre, string apellido, string direccion, DateTime fechaNacimiento, string celular)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.FechaNacimiento = fechaNacimiento;
            this.Celular = celular;
        }
        //Constructor
        public E_Persona(int idpersona, string nombre, string apellido, string direccion, DateTime fechaNacimiento, string celular)
        {
            this.idpersona = idpersona;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.celular = celular;
        }
        //Metodos get y set de la forma tradicional
        public int getIdPersona()
        {
            return this.Idpersona;
        }

        public string getCodigoPersona()
        {
            return this.CodigoPersona;
        }

        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public string getNombre()
        {
            return this.Nombre;
        }

        public void setApellido(string apellido)
        {
            this.Apellido = apellido;
        }

        public string getApellido()
        {
            return this.Apellido;
        }

        public void setDireccion(string direccion)
        {
            this.Direccion = direccion;
        }

        public string getDireccion()
        {
            return this.Direccion;
        }

        public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            this.FechaNacimiento = fechaNacimiento;
        }

        public DateTime getFechaNacimiento()
        {
            return this.FechaNacimiento;
        }

        public void setCelular(string celular)
        {
            this.Celular = celular;
        }

        public string getCelular()
        {
            return this.Celular;
        }
    }
}
