using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace repositories
{
    public class UserRepository :IUserRepository
    {

        webApiServerContext objectContext;//_objectContext
        public UserRepository(webApiServerContext objectContext,IConfiguration configuration)
        {
            this.objectContext = objectContext;
        }
        //all the function with the file'


        //get byId
        public async Task<User> getUserById(int id)//GetUserById - clean code function name should be in PascalCase
        {
            return await objectContext.Users.FindAsync(id);
        }

       

        //create new user
        public async Task<User> addUser(User user)//AddUser
        {

            await objectContext.Users.AddAsync(user);
            await objectContext.SaveChangesAsync();
            return user;
        }



        public async Task<User> updateUser(User userToUpdate)//UpdateUser
        {
            var existingUser = await objectContext.Users.FindAsync(userToUpdate.Id);//use getUserById function
            if (existingUser == null)
                throw new Exception("User not found");

            // Update fields manually
            // existingUser.Email = userToUpdate.Email;
            // existingUser.FirstName = userToUpdate.FirstName;
            // existingUser.LastName = userToUpdate.LastName;
            // existingUser.Password = userToUpdate.Password;
            objectContext.Users.Update(userToUpdate);
            await objectContext.SaveChangesAsync();
            return existingUser;
        }



        public async Task<User> login(UserLogin userLogin)//Login
        {
            return await objectContext.Users.Where(user => user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();
        }

       
    }
}
