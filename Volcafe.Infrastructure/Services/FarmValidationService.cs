using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Volcafe.Infrastructure.Services
{
    public class FarmValidationService
    {
        //private async Task<string> ValidateFarmCoordinates()
        //{
        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", writeToken);
        //    client.DefaultRequestHeaders.Add("x-api-key", _secretsKeys.xapikey);
        //    var json = JsonConvert.SerializeObject(requestModel, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        //    Sending request to find web api REST service resource Get Company using HttpClient
        //    context.Logger.LogInformation("Payments API Invoke started");
        //    HttpResponseMessage response = await client.PostAsync(_secretsKeys.PaymentsAPI, stringContent);
        //    context.Logger.LogInformation("Payments API Invoke completed");
        //    var apiResponse = response.Content.ReadAsStringAsync().Result;
        //    response.EnsureSuccessStatusCode();
        //    return apiResponse;
        //}
    }
}
