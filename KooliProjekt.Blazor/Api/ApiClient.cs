using KooliProjekt.BlazorApp.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KooliProjekt.BlazorApp
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
                result.Value = await _httpClient.GetFromJsonAsync<List<Order>>("Order");
            }
            catch (Exception ex)
            {
                result.AddError("_", ex.Message);
            }

            return result;
        }

        public async Task<Result> Save(Order list)
        {
            HttpResponseMessage response;

            if (list.Id == 0)
            {
                response = await _httpClient.PostAsJsonAsync("order", list);
            }
            else
            {
                response = await _httpClient.PutAsJsonAsync("Order/" + list.Id, list);
            }

            using (response)
            {
                if (!response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Result>();
                    return result;
                }
            }

            return new Result();
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync("Order/" + id);
        }

        public async Task<Result<Order>> Get(int id)
        {
            var result = new Result<Order>();

            try
            {
                result.Value = await _httpClient.GetFromJsonAsync<Order>("Order/" + id);
            }
            catch (Exception ex)
            {
                result.AddError("_", ex.Message);
            }

            return result;
        }
    }
}
