using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Tasks;

namespace repositories
{
    public class UserRepository : IUserRepository
    {
        //string connetion = "Data Source=SRV2\\PUPILS;Initial Catalog=webApiServer;Integrated Security=True;TrustServerCertificate=True";

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
            objectContext.Users.Update(userToUpdate);
           await objectContext.SaveChangesAsync();
            return userToUpdate;
        }

       
       

        public async Task<User> login(UserLogin userLogin)
        {
            return await objectContext.Users.Where(user => user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();
        }

        
    }
}
