// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Controllers
{
    using hikUI.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    /// <summary> A controller for handling the Home Page. </summary>
    public class HomeController : Controller
    {
        /// <summary> The logger. </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initialises a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        ///
        /// <param name="logger"> The logger. </param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary> Handle the Index view request. </summary>
        ///
        /// <returns> An IActionResult. </returns>
        public IActionResult Index()
        {
            _logger.LogInformation("Index");
            return this.View("Index");
        }

        /// <summary> Handle the Privacy view request. </summary>
        ///
        /// <returns> An IActionResult. </returns>
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy");
            return this.View("Privacy");
        }

        /// <summary> Handle exceptions. </summary>
        ///
        /// <returns> An IActionResult. </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Error");
            return this.View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
