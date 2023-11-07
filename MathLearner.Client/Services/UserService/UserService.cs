using MathLearner.Domain.Entities;
using Newtonsoft.Json;

namespace MathLearnerWasmApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string _baseServerUrl;

        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }

        public async Task<List<User>?> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/user");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);

                return users;
            }

            return new List<User>();
        }
    }
}
