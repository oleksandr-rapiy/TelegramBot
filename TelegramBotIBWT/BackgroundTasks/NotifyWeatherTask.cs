﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IBWT.Framework.Scheduler;
using TelegramBotIBWT.Data.Entities;
using TelegramBotIBWT.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TelegramBotIBWT.BackgroundTasks
{
    public class NotifyWeatherTask : IScheduledTask
    {
        private readonly IServiceProvider services;

        public string Schedule => "0 8,12,15,19 * * *";

        public NotifyWeatherTask(
            ILogger<NotifyWeatherTask> logger,
            IServiceProvider services
        )
        {
            this.services = services;
        }
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using(var scope = services.CreateScope())
            {
                IDataRepository<TGUser> tgUserRepository = (IDataRepository<TGUser>) scope.ServiceProvider.GetService(typeof(IDataRepository<TGUser>));

                List<TGUser> users = tgUserRepository.All().ToList();

            }
        }
    }
}