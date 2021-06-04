// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using hik_client;
    using hikUI.Models;

    /// <summary>A controller for handling the Home Page.</summary>
    public class HomeController : Controller
    {
        /// <summary>The view model.</summary>
        public readonly ConnectViewModel connectViewModel;

        /// <summary>The logger.</summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>The camera reader.</summary>
        private readonly CameraHandler cameraReader;

        /// <summary>
        /// Initialises a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        ///
        /// <param name="logger">The logger.</param>
        /// <param name="appSettings">The app settings.</param>
        /// <param name="handler">The camera handler.</param>
        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings, CameraHandler handler)
        {
            this.connectViewModel = new(appSettings.Value.ServiceEndpoints.Cameras);
            this._logger = logger;
            this.cameraReader = handler;
        }

        /// <summary>Handle the Index view request.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            this._logger.LogInformation("Index");
            return this.View("Index");
        }

        /// <summary>Handle the Connect view request.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        public IActionResult Connect()
        {
            this._logger.LogInformation("Connect");
            return this.View("Connect", this.connectViewModel);
        }

        /// <summary>Handle the RefreshDeviceInfo request from connect.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        public async Task<IActionResult> RefreshDeviceInfoAsync()
        {
            this._logger.LogInformation("RefreshDeviceInfo");
            this.connectViewModel.DeviceInfo = await this.cameraReader.GetDeviceInfo();
            return this.View("Connect", this.connectViewModel);
        }

        /// <summary>Handle the Privacy view request.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        public IActionResult Privacy()
        {
            this._logger.LogInformation("Privacy");
            return this.View("Privacy");
        }

        /// <summary>Handle exceptions.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            this._logger.LogInformation("Error");
            return this.View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
