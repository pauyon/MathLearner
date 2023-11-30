﻿using Newtonsoft.Json;
using System.Text;

namespace MathLearnerWasmApp.Services
{
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : class, new()
    {
        private readonly HttpClient _httpClient;
        private readonly string _controller;

        protected Service(HttpClient httpClient, string controller)
        {
            _httpClient = httpClient;
            _controller = controller;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entityJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/api/{_controller}", entityJson);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<TEntity>(content);

                return item ?? new TEntity();
            }

            return new TEntity();
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

        public virtual async Task<TEntity?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/{_controller}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<TEntity>(content);

                return entity ?? new TEntity();
            }

            return new TEntity();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
