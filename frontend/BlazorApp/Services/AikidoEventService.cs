using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Interfaces;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class AikidoEventService : ICrudService<AikidoEvent>
    {
        public HttpClient _http;
        public AikidoEventService(HttpClient http)
        {
            _http = http;
        }
        public async Task<AikidoEvent> CreateAsync(AikidoEvent entity)
        {
            return await _http.PostAsJsonAsync("api/aikidoevent", entity)
                .ContinueWith(response =>
                {
                    response.Result.EnsureSuccessStatusCode();
                    return response.Result.Content.ReadFromJsonAsync<AikidoEvent>().Result ?? entity;
                });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"api/aikidoevent/{id}")
                .ContinueWith(response => response.Result.IsSuccessStatusCode);
        }

        public async Task<IEnumerable<AikidoEvent>> GetAllAsync()
        {
            var response = await _http.GetAsync("api/aikidoevent");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<AikidoEvent>>() ?? new List<AikidoEvent>();
        }

        public async Task<AikidoEvent?> GetByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/aikidoevent/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AikidoEvent>();
        }

        public async Task<AikidoEvent> UpdateAsync(AikidoEvent entity)
        {
            var response = await _http.PutAsJsonAsync($"api/aikidoevent/{entity.Id}", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AikidoEvent>() ?? entity;
        }
    }
}