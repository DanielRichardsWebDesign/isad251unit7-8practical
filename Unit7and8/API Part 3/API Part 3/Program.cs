using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace API_Part_3
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://xserve.uopnet.plymouth.ac.uk/modules/isad251/satkinson2/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.ReadLine();

            try
            {
                Console.WriteLine(" Getting Publishers...");
                var StatusCode = await GetAllPublishersAsync();
                Console.WriteLine($" Status code = {(int)StatusCode}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(" Creating a new Publisher : Shirley Atkinson");
            publisher p = new publisher();
            p.Publisher_Name = "Shirley Test";

            var url = await CreateNewPublisherAsync(p);
            Console.WriteLine($" Created at : {url}");

            var DeleteStatus = await DeletePublisherAsync(p.Publisher_Name);
            Console.WriteLine($" Status code = {(int)DeleteStatus}");
        }

        static async Task<HttpStatusCode> GetAllPublishersAsync()
        {
            HttpResponseMessage response = await client.GetAsync("publishers");
            if(response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                var _Data = JsonConvert.DeserializeObject<List<publisher>>(JsonString);
                foreach(publisher p in _Data)
                {
                    Console.WriteLine($"Publisher : {p.Publisher_Name} \t");
                }                
            }
            return response.StatusCode;
        }

        static async Task<Uri> CreateNewPublisherAsync(publisher p)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("publishers", p);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($" Status code = {response.StatusCode}");
            return response.Headers.Location;
        }

        static async Task<HttpStatusCode> DeletePublisherAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"publishers/{id}");
            return response.StatusCode;
        }

        static async Task<publisher> UpdatePublisherAsync(publisher p)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/publisher/{p.Publisher_Name}", "test");
            response.EnsureSuccessStatusCode();

            //Deserialize the updated publisher from the response body.
            p = await response.Content.ReadAsAsync<publisher>();
            return p;
        }

        
    }
}
