using Newtonsoft.Json;

namespace MathLearnerWasmApp.Services
{
    public abstract class Service<TEntity> : IService<TEntity> 
        where TEntity : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _controller;

        protected Service(HttpClient httpClient, string controller)
        {
            _httpClient = httpClient;
            _controller = controller;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/{_controller}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<TEntity>>(content);

                return items ?? new List<TEntity>();
            }

            return new List<TEntity>();
        }
    }
}
