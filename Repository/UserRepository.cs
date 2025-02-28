using Dapper;
using Microsoft.Data.SqlClient;
using Pos.Auth.Api.Models.Command;
using Pos.Auth.Api.Repository.Models;


namespace Pos.Auth.Api.Repository
{
    public class UserRepository
    {
        public async Task<bool> CreatedAsync(RegisterCommand registerCommand)
        {
            string sql= "INSERT INTO Users (FirstName,LastName,Email,Identification,Age,Password) VALUES (@FirstName,@LastName,@Email,@Identification,@Age,@Password)";
            using (var connection = new SqlConnection("Data Source=PCJEYM\\SQLEXPRESS;Initial Catalog=Inventario;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            { 
                connection.Open();
                AuthDatabaseModel authDatabaseModel=new AuthDatabaseModel
                {
                    Email = registerCommand.Email,
                    Password = registerCommand.Password,
                    FirstName = registerCommand.FirstName,  
                    LastName = registerCommand.LastName,
                    Age = registerCommand.Age,
                    Identification = registerCommand.Identification
                };
                int rowsAffected = await connection.ExecuteAsync(sql, authDatabaseModel);//rowsAffected insercion de filas num
                return rowsAffected > 0;
            }
           
        }
    }
}
