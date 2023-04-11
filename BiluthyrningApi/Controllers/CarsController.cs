using BiluthyrningApi.Data;
using BiluthyrningApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiluthyrningApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICar carRepository;

		public CarsController(ICar carRepository)
		{
			this.carRepository = carRepository;
		}
		// GET: api/<CarsController>
		[HttpGet]
		public async Task<IEnumerable<Car>> Get()
		{
			return await carRepository.GetAllAsync();
		}
		// GET api/<CarsController>/5
		[HttpGet("{id}")]
		public async Task<Car> Get(int id)
		{
			return await carRepository.GetByIdAsync(id);
		}

		// POST api/<CarsController>
		[HttpPost]
		public async void Post([FromBody] Car car)
		{
			await carRepository.CreateAsync(car);
			return;
		}

		// PUT api/<CarsController>/5
		[HttpPut("{id}")]
		public async void Put(int id, [FromBody] Car car)
		{
			car.CarId = id;
			await carRepository.UpdateAsync(car);
			return;
		}

		// DELETE api/<CarsController>/5
		[HttpDelete("{id}")]
		public async void Delete(int id)
		{
			await carRepository.DeleteAsync(id);
			return;
		}
	}
}
