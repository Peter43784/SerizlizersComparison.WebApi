using SerializersComparison.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MsgPack.Serialization;
using SerializersComparison.Utils;
using WebApiContrib.Formatting;

namespace SerializersComparisonConsole
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            Client.BaseAddress = new Uri("http://localhost:56248/");
            Client.DefaultRequestHeaders.Accept.Clear();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result1 = GetRecordsAsync($"api/records/{DbConstants.Lar1000Records}", new JsonMediaTypeFormatter()).Result;
            stopwatch.Stop();
            Console.WriteLine("json: " + stopwatch.Elapsed);
            stopwatch.Restart();

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            var result2 = GetRecordsAsync($"api/records/{DbConstants.Lar1000Records}", new ProtoBufFormatter()).Result;

            stopwatch.Stop();
            Console.WriteLine("protobuf: " + stopwatch.Elapsed);
            stopwatch.Restart();

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-msgpack"));
            var result3 = GetRecordsMessagePack($"api/records/{DbConstants.Lar1000Records}").Result;
            stopwatch.Stop();
            Console.WriteLine("msgpack: " + stopwatch.Elapsed);

            Console.ReadKey();
        }


        static async Task<IEnumerable<HmdfEntity>> GetRecordsAsync(string path, MediaTypeFormatter formatter)
        {
            List<HmdfEntity> records = null;
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //records = await response.Content.ReadAsAsync<IEnumerable<IDictionary<string, object>>>();
                records = await response.Content.ReadAsAsync<List<HmdfEntity>>(new[] {formatter});
            }
            return records;
        }

        static async Task<IEnumerable<HmdfEntity>> GetRecordsMessagePack(string path)
        {
            List<HmdfEntity> records = null;
            var serializer = MessagePackSerializer.Get<List<HmdfEntity>>();
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                records =  serializer.Unpack(await response.Content.ReadAsStreamAsync());
            }
            return records;
        }
    }
}
