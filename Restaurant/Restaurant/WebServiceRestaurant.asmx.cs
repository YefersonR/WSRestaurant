using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace Restaurant
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceRestaurant : System.Web.Services.WebService
    {
        Datos datos;

        [WebMethod]
        public string agregar(string Nombre, string Direccion, string Rnc, string Telefono, string Persona_A_Cargo, int Cantidad_Empleados, DateTime Fecha_Creacion, DateTime Fecha_Modificacion, string Tipo_Comida, int Ventas_Mensuales_Promedio, string GuidReg)
        {
            datos = new Datos
            {
                Nombre = Nombre,
                Direccion = Direccion,
                Rnc = Rnc,
                Tel = Telefono,
                Pac = Persona_A_Cargo,
                Ca = Cantidad_Empleados,
                Fc = Fecha_Creacion,
                Fm = Fecha_Modificacion,
                Tc = Tipo_Comida,
                Vmp = Ventas_Mensuales_Promedio,
                Guidreg = GuidReg
            };
            string et = datos.Insertar();
            if (et == "12")
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
        [WebMethod]
        public string actualizar(string Nombre, string Direccion, string Rnc, string Telefono, string Persona_A_Cargo, int Cantidad_Empleados, DateTime Fecha_Creacion, DateTime Fecha_Modificacion, string Tipo_Comida, int Ventas_Mensuales_Promedio, string GuidReg)
        {
            Common(Nombre,Direccion,Rnc,Telefono,Persona_A_Cargo,Cantidad_Empleados,Fecha_Creacion,Fecha_Modificacion,Tipo_Comida,Ventas_Mensuales_Promedio,GuidReg);
            string status = datos.actualizar();

            if (status == "12")
                return "1";
            else
                return "2";
        }

        private void Common(string nombre, string direccion, string rnc, string telefono, string persona_A_Cargo, int cantidad_Empleados, DateTime fecha_Creacion, DateTime fecha_Modificacion, string tipo_Comida, int ventas_Mensuales_Promedio, string guidReg)
        {
            datos = new Datos
            {
                Nombre = nombre,
                Direccion = direccion,
                Rnc = rnc,
                Tel = telefono,
                Pac = persona_A_Cargo,
                Ca = cantidad_Empleados,
                Fc = fecha_Creacion,
                Fm = fecha_Modificacion,
                Tc = tipo_Comida,
                Vmp = ventas_Mensuales_Promedio,
                Guidreg = guidReg
            };

        }

        [WebMethod]
        public string borrar(int id)
        {
            datos = new Datos();
            string et = datos.eliminar(id);

            if (et == "12")
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
        [WebMethod]
        public List<Datos> select(int id)
        {
            datos = new Datos();
            List<Datos> lsdatos = datos.seleccionar(id);

            if (lsdatos != null)
                return lsdatos;
            else
                return lsdatos;
        }
    }
}