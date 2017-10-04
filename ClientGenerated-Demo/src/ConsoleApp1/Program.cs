using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientConfig = new Configuration();
            ////Add the username and password
            //clientConfig.Username = "John";
            //clientConfig.Password = "SecretPassword";
            //clientConfig.

            //ValuesApi instance = new ValuesApi(clientConfig);
            ValuesApi instance = new ValuesApi("http://localhost:53626/");
            int? id = 2;
            var response = instance.ApiValuesByIdGet(id);
            Console.WriteLine(response);

            Person p = instance.ApiValuesByIdByNameGet(1, "helen");
            Console.WriteLine(p.ToJson());

            //Person p2 = await ;

            Task.WaitAll(GetPersonAsync(instance));
            

            Console.ReadLine();
        }

        private static async Task<Person> GetPersonAsync(ValuesApi instance)
        {
            Person p = await instance.ApiValuesByIdByNameGetAsync(2, "daniel");
            Console.WriteLine("=>" + p?.ToJson());

            Person p2 = await instance.ApiValuesByIdByNameGetAsync(2, "max");
            Console.WriteLine("=>" + p2?.ToJson());

            return p;
        }
    }
}
