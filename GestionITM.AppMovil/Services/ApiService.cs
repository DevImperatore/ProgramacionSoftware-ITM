using GestionITM.AppMovil.Models;
using System.Net.Http.Json;

namespace GestionITM.AppMovil.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { username, password });
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result?.Token;
        }

        public async Task<PagedResult<CursoDto>?> GetCursosPaginadoAsync(int page, int pageSize)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<CursoDto>>(
                $"api/curso/paginado?page={page}&pageSize={pageSize}");
        }

        public async Task<HttpResponseMessage> MatricularAsync(int estudianteId, int cursoId)
        {
            return await _httpClient.PostAsJsonAsync("api/matricula", new { estudianteId, cursoId });
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
