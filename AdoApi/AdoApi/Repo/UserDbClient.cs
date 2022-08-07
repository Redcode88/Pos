using AdoApi.Model;
using AdoApi.translators;
using AdoApi.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdoApi.Repo
{
    public class UserDbClient
    {

     //   public static string Conn = "Data Source=(Local);Initial Catalog=AngTraining;Integrated Security=True";

        public List<UsersModel> GetAllUsers(string ConnString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<UsersModel>>(ConnString,
               "GetUsers", r => r.TranslateAsUsersList());
        }

        public string SaveUser(UsersModel model, string connString)
        {
           // connString = Conn;
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@EmailId",model.EmailId),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@Address",model.Address),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SaveUser", param);
            return (string)outParam.Value;
        }

        public string DeleteUser(int id, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
            return (string)outParam.Value;
        }
    }
}


  