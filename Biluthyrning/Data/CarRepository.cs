using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Data
{
    public class CarRepository : ICar
    {
        private readonly HttpClient client;

        public CarRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            await client.PostAsJsonAsync($"api/Cars", car);
            return car;
        }

        public async Task DeleteAsync(int id)
        {
            await client.DeleteAsync($"api/Cars/{id}");
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Car>>("api/Cars");
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Car>($"api/Cars/{id}");
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            await client.PutAsJsonAsync($"api/Cars/{car.CarId}", car);
            return car;
        }
    }
}
