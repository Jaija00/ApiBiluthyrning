using BiluthyrningApi.Data;
using BiluthyrningApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiluthyrningApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBooking bookingRepository;

		public BookingsController(IBooking bookingRepository)
		{
			this.bookingRepository = bookingRepository;
		}
		// GET: api/<BookingsController>
		[HttpGet]
		public async Task<IEnumerable<Booking>> Get()
		{
			return await bookingRepository.GetAllAsync();
		}

		// GET api/<BookingsController>/5
		[HttpGet("{id}")]
		public async Task<Booking> Get(int id)
		{
			return await bookingRepository.GetByIdAsync(id);
		}

		[HttpGet("Cars/{carId}")]
		public async Task<Booking> GetByCar(int carId)
		{
			return await bookingRepository.GetByCarIdAsync(carId);
		}

        [HttpGet("Users/{userId}")]
        public async Task<IEnumerable<Booking>> GetByUser(int userId)
        {
            return await bookingRepository.GetByUserIdAsync(userId);
        }

        // POST api/<BookingsController>
        [HttpPost]
		public async Task Post([FromBody] Booking booking)
		{
			await bookingRepository.CreateAsync(booking);
			return;
		}

		// PUT api/<BookingsController>/5
		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] Booking booking)
		{
			booking.Id = id;
			await bookingRepository.UpdateAsync(booking);
			return;
		}

		// DELETE api/<BookingsController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await bookingRepository.DeleteAsync(id);
			return;
		}
	}
}
