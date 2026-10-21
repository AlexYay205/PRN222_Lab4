using System.Text.Json;
using System.Text.Json.Serialization;
using Vegan.Services.DuyLD;

namespace Vegan_WorkerService.DuyLD
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IVeganPlaceServiceDuyLd _veganPlaceService;

        //public Worker(ILogger<Worker> logger)
        //{
        //    _logger = logger;
        //}

        public Worker(ILogger<Worker> logger, IVeganPlaceServiceDuyLd VeganPlaceServiceDuyLd) =>
            (_logger, _veganPlaceService) = (logger, VeganPlaceServiceDuyLd);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                await WriteLogFile();

                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task WriteLogFile()
        {
            try
            {
                var items = await _veganPlaceService.GetAllAsync();

                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var content = JsonSerializer.Serialize(items,opt);

                var filePath = @"D:\DuyLD_SE1905_WS.txt";

                using (var file = File.Open(filePath, FileMode.Append, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        await writer.WriteLineAsync(string.Format("{0}: {1}",
                            DateTime.Now.ToString(), content));
                        await writer.FlushAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing worker log file.");
            }
        }

    }
}
