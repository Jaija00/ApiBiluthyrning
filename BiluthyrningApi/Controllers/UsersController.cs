using BiluthyrningApi.Data;
using BiluthyrningApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiluthyrningApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUser userRepository;

		public UsersController(IUser userRepository)
        {
			this.userRepository = userRepository;
		}
        // GET: api/<UsersController>
        [HttpGet]
		public async Task <IEnumerable<User>> Get()
		{
			return await userRepository.GetAllAsync();
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<User> Get(int id)
		{
			return await userRepository.GetByIdAsync(id);
		}

		// POST api/<UsersController>
		[HttpPost]
		public async void Post([FromBody] User user)
		{
			await userRepository.CreateAsync(user);
			return;
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public async void Put(int id, [FromBody] User user)
		{
			user.UserId = id;
			await userRepository.UpdateAsync(user);
			return;
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public async void Delete(int id)
		{
			await userRepository.DeleteAsync(id);
			return;
		}
	}
}
