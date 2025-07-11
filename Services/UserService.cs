
using Dapper;
using JPT.Data;      
using JPT.Services;  
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using YourApp.Models; 


namespace YourApp.Services
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;

        public UserService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddUserModel>> GetAllUsersAsync()
        {
            var sql = "SELECT * FROM \"Users\"";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddUserModel>(sql);
        }

        public async Task<AddUserModel?> GetUserByIdAsync(int id)
        {
            var sql = "SELECT * FROM \"Users\" WHERE \"Id\" = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<AddUserModel>(sql, new { Id = id });
        }

        public async Task AddUserAsync(AddUserModel user)
        {
            var sql = @"INSERT INTO ""Users""
                        (""Branch"", ""Counter"", ""Role"", ""Username"", ""FullName"", ""NepaliName"",
                         ""Address"", ""Gender"", ""Contact"", ""OtherContact"", ""Email"",
                         ""PasswordOption"", ""Password"", ""Active"", ""Remarks"")
                        VALUES
                        (@Branch, @Counter, @Role, @Username, @FullName, @NepaliName,
                         @Address, @Gender, @Contact, @OtherContact, @Email,
                         @PasswordOption, @Password, @Active, @Remarks)";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sql, user);
        }

        // This is the corrected Update method
        public async Task UpdateUserAsync(EditUserModel model)
        {
            var sqlGet = "SELECT * FROM \"Users\" WHERE \"Id\" = @Id";
            using var connection = _context.CreateConnection();
            var userToUpdate = await connection.QuerySingleOrDefaultAsync<AddUserModel>(sqlGet, new { Id = model.Id });

            if (userToUpdate == null)
            {
                throw new KeyNotFoundException($"User with ID {model.Id} was not found for update.");
            }

            // Map properties from ViewModel to the fetched entity
            userToUpdate.Branch = model.Branch;
            userToUpdate.Counter = model.Counter;
            userToUpdate.Role = model.Role;
            userToUpdate.Username = model.Username;
            userToUpdate.FullName = model.FullName;
            userToUpdate.NepaliName = model.NepaliName;
            userToUpdate.Address = model.Address;
            userToUpdate.Gender = model.Gender;
            userToUpdate.Contact = model.Contact;
            userToUpdate.OtherContact = model.OtherContact;
            userToUpdate.Email = model.Email;
            userToUpdate.PasswordOption = model.PasswordOption;
            userToUpdate.Active = model.Active;
            userToUpdate.Remarks = model.Remarks;

            var sqlUpdate = @"UPDATE ""Users"" SET
                ""Branch"" = @Branch, ""Counter"" = @Counter, ""Role"" = @Role,
                ""Username"" = @Username, ""FullName"" = @FullName, ""NepaliName"" = @NepaliName,
                ""Address"" = @Address, ""Gender"" = @Gender, ""Contact"" = @Contact,
                ""OtherContact"" = @OtherContact, ""Email"" = @Email,
                ""PasswordOption"" = @PasswordOption, ""Active"" = @Active, ""Remarks"" = @Remarks
                WHERE ""Id"" = @Id";

            await connection.ExecuteAsync(sqlUpdate, userToUpdate);
        }

        public async Task DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM \"Users\" WHERE \"Id\" = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
        }

    } 

} 