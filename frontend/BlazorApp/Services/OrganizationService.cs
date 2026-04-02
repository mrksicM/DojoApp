using System.Net.Http.Json;
using BlazorApp.Models;
using BlazorApp.Interfaces;

namespace BlazorApp.Services
{
    public class OrganizationService : ICrudService<Organization>
    {
        private readonly HttpClient _http;
        public OrganizationService(HttpClient http)
        {
            _http = http;
        }

        public Task<Organization> CreateAsync(Organization entity)
        {
            var response = _http.PostAsJsonAsync("api/organization", entity);
            return response.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully)
                {
                    var res = t.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return res.Content.ReadFromJsonAsync<Organization>().Result ?? entity;
                    }
                }
                return entity;
            });
        }

        public Task<bool> DeleteAsync(int id)
        {
            var response = _http.DeleteAsync($"api/organization/{id}");
            return response.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully)
                {
                    return t.Result.IsSuccessStatusCode;
                }
                return false;
            });
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Organization>>("api/organization")
                   ?? Enumerable.Empty<Organization>();
        }

        public Task<Organization?> GetByIdAsync(int id)
        {
            return _http.GetFromJsonAsync<Organization>($"api/organization/{id}");
        }

        public Task<Organization> UpdateAsync(Organization entity)
        {
            var response = _http.PutAsJsonAsync($"api/organization/{entity.Id}", entity);
            return response.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully)
                {
                    var res = t.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return res.Content.ReadFromJsonAsync<Organization>().Result ?? entity;
                    }
                }
                return entity;
            });
        }
    }
}