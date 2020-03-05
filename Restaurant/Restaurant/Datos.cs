using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Restaurant
{
    public class Datos
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Rnc { get; set; }
        public string Tel { get; set; }
        public string Pac { get; set; }
        public int Ca { get; set; }
        public DateTime Fc { get; set; }
        public DateTime Fm { get; set; }
        public string Tc { get; set; }
        public int Vmp { get; set; }
        public string Guidreg { get; set; }
        public Datos()
        {

        }
        string Conex = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public string Insertar()
        {
          
            using (SqlConnection conec = new SqlConnection(Conex))
            {
                SqlCommand cmd = new SqlCommand("spinsertar", conec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@direccion", Direccion);
                cmd.Parameters.AddWithValue("@rnc", Rnc);
                cmd.Parameters.AddWithValue("@tel", Tel);
                cmd.Parameters.AddWithValue("@pac", Pac);
                cmd.Parameters.AddWithValue("@ca", Ca);
                cmd.Parameters.AddWithValue("@fc", Fc);
                cmd.Parameters.AddWithValue("@fm", Fm);
                cmd.Parameters.AddWithValue("@tc", Tc);
                cmd.Parameters.AddWithValue("@vmp", Vmp);
                cmd.Parameters.AddWithValue("@guidreg", Guidreg);


                conec.Open();
                int c = cmd.ExecuteNonQuery();

                if (c > 0)
                {
                    return "E";
                }
                else
                {
                    return "F";
                }

            }
        }
        
         public string actualizar()
         {
             using (SqlConnection conec = new SqlConnection(Conex))
             {
                 SqlCommand cmd = new SqlCommand("spactualizar", conec);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@nombre", Nombre);
                 cmd.Parameters.AddWithValue("@direccion", Direccion);
                 cmd.Parameters.AddWithValue("@rnc", Rnc);
                 cmd.Parameters.AddWithValue("@tel", Tel);
                 cmd.Parameters.AddWithValue("@pac", Pac);
                 cmd.Parameters.AddWithValue("@ca", Ca);
                 cmd.Parameters.AddWithValue("@fc", Fc);
                 cmd.Parameters.AddWithValue("@fm", Fm);
                 cmd.Parameters.AddWithValue("@tc", Tc);
                 cmd.Parameters.AddWithValue("@vmp", Vmp);
                 cmd.Parameters.AddWithValue("@guidreg", Guidreg);

                conec.Open();
                 int count = cmd.ExecuteNonQuery();
                 conec.Close();

                 if (count > 0)
                     return "E";
                 else
                     return "F";
             }
         }
 
        public List<Datos> seleccionar(int id)
        {
            using (SqlConnection conec = new SqlConnection(Conex))
               {
                    SqlCommand cmd = new SqlCommand("spseleccionar", conec);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    conec.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    List<Datos> lsdatos = new List<Datos>();
                    while (dr.Read())
                    {
                        Datos datos = new Datos
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Direccion = dr["EmpSalary"].ToString(),
                            Rnc = dr["Rnc"].ToString(),
                            Tel = dr["Tel"].ToString(),
                            Pac = dr["Pac"].ToString(),
                            Tc = dr["Tc"].ToString(),
                            Guidreg = dr["Guidreg"].ToString(),
                            
  

                        };

                        lsdatos.Add(datos);
                    }

                    return lsdatos;
                }
            }

        public string eliminar(int id)
        {
                using (SqlConnection conec = new SqlConnection(Conex))
                {
                    SqlCommand cmd = new SqlCommand("speliminar", conec);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    conec.Open();
                    int count = cmd.ExecuteNonQuery();
                    conec.Close();

                    if (count > 0)
                        return "E";
                    else
                        return "F";
                }
            }
        }
    }

