using HatuaMVP.Core.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatuaMVP.Api
{
    public static class StartupTaskWebHostExtensions
    {
        public static async Task RunWithTasksAsync(this IWebHost webHost, CancellationToken cancellationToken = default)
        {
            // Load all tasks from DI
            var startupTasks = webHost.Services.GetServices<IStartupTask>();

            // Execute all the tasks
            foreach (var startupTask in startupTasks)
            {
                //comment when creating controller scaffold
                //Uncomment when running application
                await startupTask.ExecuteAsync(cancellationToken);
            }

            // Start the tasks as normal
            //comment when creating controller scaffold
            //Uncomment when running application
            await webHost.RunAsync(cancellationToken);
        }
    }
}