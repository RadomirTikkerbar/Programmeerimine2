using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.WpfApp.Api
{
    public class ApiClient : IApiClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7136/api/TodoLists/");
        }

        public async Task<IList<TodoList>> List()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TodoList>>("");

            return result;
        }

        public async Task Save(TodoList list)
        {
            if(list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync("", list);
            }
            else
            {
                await _httpClient.PutAsJsonAsync(list.Id.ToString(), list);
            }
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync(id.ToString());
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
