using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IceCreamStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase//-----------------
    {

        public IUserService _userServices;
        public UserController(IUserService userService)
        {
            this._userServices = userService;
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<User> >Get(int id)
        {
           
            User user= (User)( await _userServices.getUserById(id));
            if (user == null)
                return BadRequest();
            
           return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("register")]
        public async Task<ActionResult<User>>Post([FromBody] User user)
        {
            User newUser= await _userServices.addUser(user);
            if (newUser!=null)
                return Ok(newUser);
            return BadRequest();

        }

        //to the login
        [HttpPost("login")]
        public async Task<ActionResult<User>>Post([FromBody] UserLogin userLogin)
        {
            User user = await  _userServices.login(userLogin);
            if (user != null)
                return Ok(userLogin);
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User> >Put(User userToUpdate)
        {
            User updatedUser = await _userServices.updateUser(userToUpdate);
            if (updatedUser != null)
                return Ok(updatedUser);
            return BadRequest();
        }


        //check the password:
        [HttpPost("/checkPassword")]
        public ActionResult<int> Post([FromBody]String password)
        {
            int powerPassword = _userServices.powerOfPassword(password);
            if (powerPassword != -1)
                return Ok(powerPassword);
            return BadRequest();
        }
        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
