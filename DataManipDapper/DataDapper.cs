using System.Data;
using System.Data.Common;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data{

    public class DataDapper{

        private string _connectDb = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

        public IEnumerable<T> LoadData<T>(string pull_request){
            IDbConnection dbConnection = new SqlConnection(_connectDb);

            return dbConnection.Query<T>(pull_request);


        }

        public T LoadDataSingle<T>(string pull_request){
            IDbConnection dbConnection = new SqlConnection(_connectDb);

            return dbConnection.QuerySingle<T>(pull_request);


        }

        public int ExecuteSql(string pull_request){
            IDbConnection dbConnection = new SqlConnection(_connectDb);

            return dbConnection.Execute(pull_request);


        }

        public IDataReader SelectSql(string select_request){
            IDbConnection dbConnection = new SqlConnection(_connectDb);

            var result = dbConnection.ExecuteReader(select_request);
            ReadTable(result);
            
            return result;
        }

        public void ReadTable(IDataReader obj){
            while (obj.Read())
            {
                for (int i = 0; i < obj.FieldCount; i++)
                {
                    Console.WriteLine(obj[i].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}

