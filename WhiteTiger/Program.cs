using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WhiteTiger
{
    public class Program
    {

        private static string PrivateKey { get; set; }
        private static string Certificate { get; set; }
        private static string Build { get; set; }

        public static void Main(string[] args)
        {
            var certPath = Environment.GetEnvironmentVariable("ASPNETCORE_Certificates_Default_Path");
            Console.WriteLine(certPath);

            PrivateKey = File.ReadAllText(certPath + "/privkey.pem");
            Certificate = File.ReadAllText(certPath + "/cert.pem");
            // parsing a cert from a PEM file. PEM read directly from file
            var cert = X509Certificate2.CreateFromPem(Certificate, PrivateKey);
            Console.WriteLine($"Certificate loaded with subject '{cert.Subject}' and a key type of '{cert.PublicKey.Oid.FriendlyName}'");
            var key = RSA.Create();
            key.ImportFromPem(PrivateKey);

            CreateHostBuilder(args).Build().Run();           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ConfigureHttpsDefaults(adapterOptions =>
                        {
                            adapterOptions.ServerCertificate = X509Certificate2.CreateFromPem(Certificate, PrivateKey);
                        });
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
