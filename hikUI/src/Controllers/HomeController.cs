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
    using hik_client;
    using hikUI.Models;

    /// <summary>A controller for handling the Home Page.</summary>
    public class HomeController : Controller
    {
        /// <summary>The view model.</summary>
        public readonly ConnectViewModel connectViewModel;

        /// <summary>The logger.</summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>The camera handler.</summary>
        private readonly CameraHandler cameraHandler;

        /// <summary>
        /// Initialises a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        ///
        /// <param name="logger">The logger.</param>
        /// <param name="handler">The camera handler.</param>
        public HomeController(ILogger<HomeController> logger, CameraHandler handler)
        {
            this._logger = logger;
            this.cameraHandler = handler;
            this.connectViewModel = new();
            this.connectViewModel.Cameras = this.cameraHandler.Connection;
        }

        /// <summary>Handle the Index view request.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            this._logger.LogInformation("Index");
            return this.View("Index");
        }

        /// <summary>Handle the Connect view request.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public IActionResult Connect()
        {
            this._logger.LogInformation("Connect Get");
            return this.View("Connect", this.connectViewModel);
        }

        /// <summary>Handle the post request from connect.</summary>
        ///
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Connect(ConnectViewModel connectViewModel)
        {
            this._logger.LogInformation("Connect Post");
            this.cameraHandler.SetConnection(connectViewModel.Cameras);
            this.connectViewModel.Cameras = connectViewModel.Cameras;
            this.connectViewModel.DeviceInfo = await this.cameraHandler.GetDeviceInfo();
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
