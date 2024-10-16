using BlazorApp.Share;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAppLogin.Client.Services
{
    public class _UserServices : UserInterface
    {
        private readonly HttpClient _http;

        public _UserServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<_UserViewModels>> _List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<_List>>
        }
    }
}
