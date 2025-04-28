using Entities;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace repositories
{
    public class UserRepository
    {
        //all the function with the file'
        const String filePath = "F:\\webAPI\\iceCreamStore\\users.txt";

        //get byId
        public User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.ID == id)
                        return user;

                }
            }
            return null;
        }

        //create new user
        public User addUser(User user)
        {
            int numberOfUsers = -1;
            try
            {
                numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            }
            catch { }
            user.ID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

       

        public User updateUser(User userToUpdate)
        {
            User user = null;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.ID == userToUpdate.ID)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty )
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return user;
            }
            return null;

        }

        public User login(UserLogin userLogin)//user login
        {
            
            using (StreamReader reader = System.IO.File.OpenText(filePath)) { 
                string? currentUserInFile;
            while ((currentUserInFile = reader.ReadLine()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user?.Email == userLogin.Email&&user.Password==userLogin.Password)
                             return user;
                }
            return null;

        }}

    }

    //delete
    //public ActionResult<User> deleteUser(int id)
    //{

    //}
}

