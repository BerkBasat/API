using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6_Dapper.Models;
using System.Data.SqlClient;

namespace Net6_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<User> users = await SelectAllUsers(connection);
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryFirstAsync<User>("select * from users where id = @Id", new
            {
                Id = userId
            });
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into users (username, firstname, lastname, password) values (@UserName, @FirstName, @LastName, @Password)", user);
            return Ok(await SelectAllUsers(connection));
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update users set username = @UserName, firstname = @FirstName, lastname = @LastName, password = @Password where id = @Id", user);
            return Ok(await SelectAllUsers(connection));
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int userId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from users where id = @Id", new
            {
                Id = userId
            });
            return Ok(await SelectAllUsers(connection));
        }

        private static async Task<IEnumerable<User>> SelectAllUsers(SqlConnection connection)
        {
            return await connection.QueryAsync<User>("select * from users");
        }
    }
}
