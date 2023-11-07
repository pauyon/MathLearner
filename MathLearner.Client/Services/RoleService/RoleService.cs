using MathLearner.Domain.Entities;
using Newtonsoft.Json;

namespace MathLearnerWasmApp.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Role>?> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/role");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var roles = JsonConvert.DeserializeObject<List<Role>>(content);

                return roles;
            }

            return new List<Role>();
        }
    }
}
