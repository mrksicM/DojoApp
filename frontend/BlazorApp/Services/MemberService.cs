using System.Net.Http.Json;
using BlazorApp.Interfaces;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class MemberService : ICrudService<Member>
    {
        private readonly HttpClient _http;

        public MemberService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Member>>("api/members/GetAll")
                   ?? Enumerable.Empty<Member>();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Member>($"api/members/{id}");
        }

        public async Task<Member> CreateAsync(Member entity)
        {
            var response = await _http.PostAsJsonAsync("api/members", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Member>() ?? entity;

        }

        public async Task<Member> UpdateAsync(Member entity)
        {
            var response = await _http.PutAsJsonAsync($"api/members/{entity.Id}", entity);
            return await response.Content.ReadFromJsonAsync<Member>() ?? entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/members/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}