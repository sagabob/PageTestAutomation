using System;
using ClientService.Repository;
using ServiceCore.Configuration;

namespace IdPageConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new DocumentConnectionHandler("jsConfig.json", "DbConnection").DbConnectionConfiguration;

            IClientRepository clientRepository = new ClientRepository(config);

            var clientTest = new ClientTest(clientRepository);

            clientTest.GetClientByAlias("monash");

            Console.ReadKey();
        }
    }
}