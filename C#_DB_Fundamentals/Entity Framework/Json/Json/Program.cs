using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                FirstName = "Nickolay",
                LastName = "Nanov",
                Interests = new List<string>() { "BJJ", "Programming", "Gaming" }
            };

            string json = JsonConvert.SerializeObject(person, Formatting.Indented);

            Person person2 = JsonConvert.DeserializeObject<Person>(json);
            //Console.WriteLine(person2);

            var annonimus = new
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Age = 0.0,
                Interests = new List<string>()
            };

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var products = JObject.Parse(json);

            Console.WriteLine((products["Interests"][0].ToObject(typeof(string))).ToString()[0]);
        }
    }
}
