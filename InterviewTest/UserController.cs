using Contract;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InterviewTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> Get()
        {
            var users = _repository.User.GetAll();
                                                       
            if (users.Exception != null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(users.Result);
           
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {


            var users = _repository.User.GetById(id);

            if (users.Exception != null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(users.Result);

        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(User user)
        {
                _repository.User.Add(user);
                _repository.Save();
                return Ok("Added Successfully");
            
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.User.Update(user);
                _repository.SaveChanges();
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async  Task<IActionResult> Delete(int id)
        {
            var userToUpdate = await _repository.User.GetById(id);
            _repository.User.Remove(userToUpdate);
            _repository.SaveChanges();
            return Ok("Updated Successfully");
        }

    }
}
