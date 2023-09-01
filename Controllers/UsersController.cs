using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Events.Models;
using Events.Requests;
using Events.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _userService;
        private readonly IMapper _imapper;
        public UsersController(IUsers userService, IMapper imapper)
        {
            _userService = userService;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Adduser(CreateUser newUser){
            var user = _imapper.Map<User>(newUser);
            var res = await _userService.CreateUsersAsync(user);
            return CreatedAtAction(nameof(Adduser),  res);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetUsers(){
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetOneUser(Guid id){
            var user = await _userService.GetOneUserAsync(id);
            if(user == null){
                return NotFound( "User not found");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateUser(Guid id, CreateUser updatedUser){
            var response = await _userService.GetOneUserAsync(id);
            if(response == null){
                return NotFound("User not found");
            }
            var updated = _imapper.Map(updatedUser, response);
            var res = await _userService.UpdateUserAsync(updated);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(Guid id){
            var response = await _userService.GetOneUserAsync(id);
            if(response == null){
                return NotFound("User not found");
            }
            var res = await _userService.DeleteUserAsync(response);
            return Ok(res);
        }
    }
}