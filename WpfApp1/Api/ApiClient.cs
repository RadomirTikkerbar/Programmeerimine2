using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.WpfApp.Api
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7136/api/");
        }

        public async Task<Result<List<Order>>> List()
        {
            var result = new Result<List<Order>>();

            try
            {
                result.Value = await _httpClient.GetFromJsonAsync<List<Order>>("TodoLists");
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task Save(Order list)
        {
            if (list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync("TodoLists", list);
            }
            else
            {
                await _httpClient.PutAsJsonAsync("TodoLists/" + list.Id, list);
            }
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync("TodoLists/" + id);
        }
    }
}