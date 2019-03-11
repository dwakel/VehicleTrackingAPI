using Gps.Core.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gps.Core.Filters
{
    public class SeedStartupFilter : IStartupTask
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedStartupFilter(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //using (
            var scope = this._serviceProvider.CreateScope();//)
                                                            // {
            var service = scope.ServiceProvider;

            try
            {
                var context = service.GetRequiredService<GpsContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = service.GetRequiredService<ILogger<SeedStartupFilter>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
            //}
        }
    }
}