// <copyright company="Louis Henry Nayegon.">
// Copyright (c) Louis Henry Nayegon. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary> A program. </summary>
    public class Program
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Program" /> class from being created.
        /// </summary>
        private Program()
        {
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary> Main entry-point for this application. </summary>
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
