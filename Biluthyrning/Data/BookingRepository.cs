using Biluthyrning.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Biluthyrning.Data
{
    public class BookingRepository : IBooking
    {
        private readonly HttpClient client;

        public BookingRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<Booking> CreateAsync(Booking booking)
        {
            await client.PostAsJsonAsync($"api/Bookings", booking);
            return booking;
        }

        public async Task DeleteAsync(int id)
        {
            await client.DeleteAsync($"api/Bookings/{id}");
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Booking>>("api/Bookings");
        }
        public async Task<IEnumerable<Booking>> GetByIdDeleteAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Booking>>($"api/Bookings/{id}");
        }

        public async Task<Booking> GetByCarIdAsync(int carId)
        {
            return await client.GetFromJsonAsync<Booking>($"api/Bookings/Cars/{carId}");
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Booking>($"api/Bookings/{id}");
        }
        public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
        {
            return await client.GetFromJsonAsync<IEnumerable<Booking>>($"api/Bookings/Users/{userId}");
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            await client.PutAsJsonAsync($"api/Bookings/{booking.Id}", booking);
            return booking;
        }
    }
}
