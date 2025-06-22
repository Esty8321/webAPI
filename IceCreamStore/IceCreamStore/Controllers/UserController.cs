using AutoMapper;
using DTOs;
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
        public readonly IMapper _mapper;

        public IUserService _userServices;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userServices = userService;
            _mapper = mapper;   
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<User> >Get(int id)
        {
           
            UserDTO user= (UserDTO)( await _userServices.getUserById(id));
            if (user == null)
                return BadRequest();
            
           return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("register")]
        public async Task<ActionResult<User>>Post([FromBody] User user)
        {
            User newUser= await _userServices.addUser(user);
            if (newUser != null)
            {
                return Ok(newUser);
            }
            return BadRequest();

        }

        //to the login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>>Post([FromBody] UserLogin userLogin)
        {
            UserDTO user = await  _userServices.login(userLogin);
            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("update")]
        public async Task<ActionResult<User> >Put(UserDTO userToUpdate)
        {
            User user=_mapper.Map<User>(userToUpdate);
            User updatedUser = await _userServices.updateUser(user);
            if (updatedUser != null)
                return Ok(updatedUser);
            return BadRequest();
        }


        //check the password:
        [HttpPost("checkPassword")]
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
