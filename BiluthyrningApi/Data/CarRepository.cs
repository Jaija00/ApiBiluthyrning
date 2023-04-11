using BiluthyrningApi.Data;
using BiluthyrningApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiluthyrningApi.Data
{
	public class CarRepository : ICar
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CarRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}
		public void Set(Car car)
		{
			car.Name = car.Name;
			car.Brand = car.Brand;
			car.Price = car.Price;
			car.Size = car.Size;
			car.Color = car.Color;
			car.FuelType = car.FuelType;
			car.Gear = car.Gear;
		}
		public async Task<Car> CreateAsync(Car car)
		{
			applicationDbContext.Cars.Add(car);
			await applicationDbContext.SaveChangesAsync();
			return car;
		}

		public async Task DeleteAsync(int id)
		{
			var car = applicationDbContext.Cars.Find(id);
			applicationDbContext.Cars.Remove(car);
			await applicationDbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Car>> GetAllAsync()
		{
			return await applicationDbContext.Cars.OrderBy(c => c.Size).ThenBy(c => c.Gear).ToListAsync();
		}

		public async Task<Car> GetByIdAsync(int id)
		{
			return await applicationDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
		}

		public async Task<Car> UpdateAsync(Car car)
		{
			applicationDbContext.Update(car);
			await applicationDbContext.SaveChangesAsync();
			return car;
		}
	}
}
