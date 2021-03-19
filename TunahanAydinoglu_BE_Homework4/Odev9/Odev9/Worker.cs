using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Odev9
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
             
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                try
                {


                    var pingSender = new Ping();
                    var hostNameOrAddress = "nisanyazilim.com";

                    Console.WriteLine($"PING {hostNameOrAddress} adresine ping atildi :");

                    for (int i = 0; i < 1; i++)
                    {
                        var reply = await pingSender.SendPingAsync(hostNameOrAddress);
                        Console.WriteLine($"{reply.Buffer.Length} bytes from {reply.Address}:" +
                                          $" status={reply.Status} time={reply.RoundtripTime}ms" +
                                          " sistem duzenli calisiyor...");
                    }
                }
                catch
                {
                    Console.WriteLine("Sistemde bir hata var lutfen kontrol ediniz");
                }
          
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
