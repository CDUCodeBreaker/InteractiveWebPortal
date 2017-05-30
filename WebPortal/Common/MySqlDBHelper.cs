using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Common
{
    public class MySqlDBHelper
    {
        static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["WebPortalConnString"].ToString();

        public static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }

        public static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, MySqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return table;
        }

        public static int ExecuteNonQuery(string CommandName, CommandType cmdType, MySqlParameter[] pars)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            if (result > 0)
            {
                return result;
            }
            else
                return 0;
        }
    }
}
