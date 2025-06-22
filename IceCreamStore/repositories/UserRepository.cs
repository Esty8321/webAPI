using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace repositories
{
    public class UserRepository :IUserRepository
    {

        webApiServerContext objectContext;
        public UserRepository(webApiServerContext objectContext,IConfiguration configuration)
        {
            this.objectContext = objectContext;
        }
        //all the function with the file'


        //get byId
        public async Task<User> getUserById(int id)
        {
            User user = await objectContext.Users.FindAsync(id);
            return user;
        }

       

        //create new user
        public async Task<User> addUser(User user)
        {

            await objectContext.Users.AddAsync(user);
            await objectContext.SaveChangesAsync();
            return user;
        }



        public async Task<User> updateUser(User userToUpdate)
        {
            var existingUser = await objectContext.Users.FindAsync(userToUpdate.Id);
            if (existingUser == null)
                throw new Exception("User not found");

            // Update fields manually
            existingUser.Email = userToUpdate.Email;
            existingUser.FirstName = userToUpdate.FirstName;
            existingUser.LastName = userToUpdate.LastName;
            existingUser.Password = userToUpdate.Password;

            await objectContext.SaveChangesAsync();
            return existingUser;
        }



        public async Task<User> login(UserLogin userLogin)
        {
            return await objectContext.Users.Where(user => user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();
        }

       
    }
}
