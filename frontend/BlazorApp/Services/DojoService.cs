using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Interfaces;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class DojoService : ICrudService<Dojo>
    {
        public HttpClient _http;
        public DojoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Dojo> CreateAsync(Dojo entity)
        {
            return await _http.PostAsJsonAsync("api/dojo", entity)
                .ContinueWith(response =>
                {
                    response.Result.EnsureSuccessStatusCode();
                    return response.Result.Content.ReadFromJsonAsync<Dojo>().Result ?? entity;
                });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"api/dojo/{id}")
                .ContinueWith(response => response.Result.IsSuccessStatusCode);
        }

        public async Task<IEnumerable<Dojo>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Dojo>>("api/dojo") ?? new List<Dojo>();
        }

        public async Task<Dojo?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Dojo?>($"api/dojo/{id}");
        }

        public async Task<Dojo> UpdateAsync(Dojo dojo)
        {
            return await _http.PutAsJsonAsync($"api/dojo/{dojo.Id}", dojo)
                .ContinueWith(response =>
                {
                    response.Result.EnsureSuccessStatusCode();
                    return response.Result.Content.ReadFromJsonAsync<Dojo>().Result ?? dojo;
                });
        }

        public async Task<IEnumerable<Member>> GetDojoMembersAsync(int dojoId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<Member>>($"api/dojo/{dojoId}/members")
             ?? new List<Member>();
        }
    }
}