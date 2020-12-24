using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.HostedServices
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger, IConfiguration configuration,
            IServiceScopeFactory scopeFactory, IEmailService emailService)
        {
            _logger = logger;
            _configuration = configuration;
            _scopeFactory = scopeFactory;
            _emailService = emailService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            // next exact hour
            var currentDateNextHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            currentDateNextHour = currentDateNextHour.AddHours(DateTime.Now.Hour + 1);

            // time span to next exact hour
            var timeToExactHour = currentDateNextHour.Subtract(DateTime.Now);

            //_timer = new Timer(DoWork, null, timeToExactHour, TimeSpan.FromHours(1));
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var maxHoursToNextOccurrence = Convert.ToDouble(_configuration[Constants.MaxHoursToNextOccurrence]);
            var maxMinutesToNextOccurrence = Convert.ToDouble(_configuration[Constants.MaxMinutesToNextOccurrence]);

            // send notification email
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
            var reminders = dbContext.Set<Reminder>().ToList().OrderBy(x => x.NextOccurrence)
                .Where(x => x.HoursForNextOccurrence <= maxHoursToNextOccurrence || x.MinutesForNextOccurrence <= maxMinutesToNextOccurrence);

            foreach (var reminder in reminders)
            {
                // send notification email
                var subject = $"Recordatorio: {reminder.RecurrentOn.ToLongDateString()} {reminder.RecurrentOn.ToShortTimeString()} - {reminder.Name}";
                var message = $"<html>" +
                              $"<body>" +
                              $"<div>Fecha: {reminder.RecurrentOn.ToLongDateString()} {reminder.RecurrentOn.ToShortTimeString()}</div>" +
                              $"<div>Titulo: {reminder.Name}</div>" +
                              $"<div>Descripcion: {reminder.Description}</div>" +
                              $"</body>" +
                              $"</html>";
                _emailService.SendEmail(reminder.Email, "Recordatorio", subject, string.Empty, message);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}