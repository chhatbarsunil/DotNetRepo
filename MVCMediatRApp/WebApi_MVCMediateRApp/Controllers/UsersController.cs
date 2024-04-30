
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebApi_MVCMediateRApp.Application.UserProcessor.Commands;
using WebApi_MVCMediateRApp.Application.UserProcessor.Queries;
using WebApi_MVCMediateRApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_MVCMediateRApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;


        public UsersController(IMediator mediator )
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet("users")]
        public async Task<IList<UserViewModel>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());

            return result;
            
        }

        // GET api/<UsersController>/5
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            //check Id found in database;
            try
            {
                var response = await _mediator.Send(new GetUserByIdQuery(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost("adduser")]
        public async Task<IActionResult> AddCustomer(CreateUserRequestModel createUserRequestModel)
        {
            try
            {
                var response = await _mediator.Send(new CreateUserCommand(createUserRequestModel));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("updateuser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequestModel updateUserRequestModel)
        {
            try
            {
                var foundedUser = await _mediator.Send(new GetUserByIdQuery(id));
                if (foundedUser.Id != 0)
                {
                    var result = await _mediator.Send(new UpdateUserCommand(updateUserRequestModel));


                    return Ok($"User Updated Sucessfully");
                }
                else
                {
                    return Ok($"Id {id} not found in database");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var foundedUser = await _mediator.Send(new GetUserByIdQuery(id));
                if(foundedUser.Id != 0)
                {
                    var result = await _mediator.Send(new DeleteUserCommand(id));
                    
                    
                    return Ok($"User Deleted Sucessfully ");
                }
                else
                {
                    return Ok($"Id {id} not found in database");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
