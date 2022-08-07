using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using POS.Models;
using System.Collections;

namespace POS.Entity
{
    public static class StateRepo
    {
        public static string conn = "Data Source=(Local);Initial Catalog=PosAdel;Integrated Security=True";
        static SqlConnection cn = new SqlConnection(conn);
        //Get all state from DataBase

        public static IEnumerable<States> GetAllStates()
        {
            try
            {
               var st = new List<States>();
               if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                using (SqlCommand cmd = new SqlCommand("[dbo].[SelectAllState]",cn))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        States states = new States
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Name = dr["Name"].ToString()
                        };
                        st.Add(states);
                        
                    }
                    dr.Close();
                    return st.ToList();
                    
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"the error is --- :{ex.Message}");
            }
        }

        //Get State by id
        public static States GetStatesById(int? Id)
        {
            try
            {

                States states = new States();
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[dbo].[SelectStateById]", cn))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID",Id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        states.ID = Convert.ToInt32(dr["ID"]);
                        states.Name = dr["Name"].ToString();

                    }
                    dr.Close();
                    cn.Close();
                }
              return states;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"the error is --- :{ex.Message}");
            }
        }


        public static IEnumerable<States> Search(string name)
        {
            try
            {
                var st = new List<States>();
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[dbo].[SearchState]", cn))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        States states = new States()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Name = dr["Name"].ToString()
                        };
                        st.Add(states);
                    }
                    dr.Close();
                    return st.ToList();
                }
               
            }
            catch (Exception ex)
            {
               throw new ArgumentException(ex.Message);
            }
        }

      




        public static List<States> SearchByName(string name)
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
            using (SqlCommand cmd = new SqlCommand("[dbo].[SearchState]", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataReader dr = cmd.ExecuteReader();
                States states = new States();
                var st = new List<States>();
                while (dr.Read())
                {
                     states.ID = Convert.ToInt32(dr["ID"]);
                     states.Name = dr["Name"].ToString();
                }
                st.Add(states);
                dr.Close();
                return st.ToList();
            }

            
        }



        //Delete Step Data By ID
        public static int DeleteState(int ID)
        {
            try
            {
              //  States states = new States();
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[dbo].[DeleteState]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                }
                return 200;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
           
        }

        public static int EditState(States states)
        {
            try
            {
                
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[dbo].[EditState]", cn))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID",states.ID);
                    cmd.Parameters.AddWithValue("@Name",states.Name);
                    cmd.ExecuteNonQuery();
                }

                cn.Close();
                return 200;
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //Save state from user Input
        public static int AddState(States states)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[dbo].[AddState]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", states.Name);
                    cmd.ExecuteNonQuery();
                }
                
                return 200;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"the error is --- :{ex.Message}");
            }
        }

    }
}
