using Biluthyrning.Models;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Data
{
	public class UserRepository : IUser
	{
        private readonly HttpClient client;

        public UserRepository(HttpClient client)
		{
            this.client = client;
        }
		public async Task<User> CreateAsync(User user)
		{
			await client.PostAsJsonAsync($"api/Users", user);
			return user;
		}

		public async Task DeleteAsync(int id)
		{
			await client.DeleteAsync($"api/Users/{id}");
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await client.GetFromJsonAsync<IEnumerable<User>>($"api/Users");
		}

		public async Task<User> GetByIdAsync(int id)
		{
			return await client.GetFromJsonAsync<User>($"api/Users/{id}");
		}

		public async Task<User> UpdateAsync(User user)
		{
			await client.PutAsJsonAsync<User>($"api/Users/{user.UserId}", user);
			return user;
		}
	}
}
