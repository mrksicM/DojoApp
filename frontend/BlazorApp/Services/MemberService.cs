using System.Net.Http.Json;
using BlazorApp.Models;

public class MemberService
{
    private readonly HttpClient _http;

    public MemberService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Member>> GetMembersAsync()
    {
        return await _http.GetFromJsonAsync<List<Member>>("api/Members") ?? new List<Member>();
    }

    public async Task<Member?> CreateMemberAsync(Member Member)
    {
        var response = await _http.PostAsJsonAsync("api/Members", Member);
        return await response.Content.ReadFromJsonAsync<Member>();
    }
}

