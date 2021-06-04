// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Test.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;
    using Microsoft.Extensions.Options;
    using Moq;
    using hik_client;
    using hikUI.Models;
    using hikUI.Controllers;
    using hik_client.Test.HttpMock;
    using System.Net.Http;
    using System.Collections.Generic;

    /// <summary>(Unit Test Fixture) a controller for handling test materials.</summary>
    public class TestHomeController
    {
        /// <summary>The controller under test.</summary>
        private HomeController controller;

        private static readonly ServiceEndpoints Endpoints = new()
        {
            Cameras = new Connection()
            {
                Endpoint = "http://localhost:8000/",
                Username = "username",
                Password = "password",
                Timeout = 1000
            }
        };

        /// <summary>The application settings.</summary>
        private static readonly AppSettings AppSettings = new()
        {
            ServiceEndpoints = Endpoints
        };

        /// <summary>The options.</summary>
        private static readonly IOptions<AppSettings> Options = new OptionsWrapper<AppSettings>(AppSettings);

        /// <summary>Setup for all unit tests here.</summary>
        [SetUp]
        public void Setup()
        {
            this.SetupDisconnected();
        }

        /// <summary>(Unit Test Method) Index action.</summary>
        [Test]
        public void Index()
        {
            var result = this.controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Index", viewResult.ViewName);
            Assert.IsNull(viewResult.ViewData.Model);
        }

        /// <summary>(Unit Test Method) Connect action.</summary>
        [Test]
        public void Connect()
        {
            var result = this.controller.Connect();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Connect", viewResult.ViewName);
            Assert.IsInstanceOf<ConnectViewModel>(viewResult.ViewData.Model);
        }

        /// <summary>(Unit Test Method) Refresh Device Info Async action.</summary>
        [Test]
        public async Task RefreshDeviceInfoAsyncNotConnected()
        {
            var result = await this.controller.RefreshDeviceInfoAsync();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.IsInstanceOf<ConnectViewModel>(viewResult.ViewData.Model);

            ConnectViewModel model = viewResult.ViewData.Model as ConnectViewModel;
            Assert.AreEqual("Not connected", model.DeviceInfoString);
        }

        /// <summary>(Unit Test Method) Refresh Device Info Async action.</summary>
        [Test]
        public async Task RefreshDeviceInfoAsyncConnected()
        {
            this.SetupConnected();
            var result = await this.controller.RefreshDeviceInfoAsync();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.IsInstanceOf<ConnectViewModel>(viewResult.ViewData.Model);

            ConnectViewModel model = viewResult.ViewData.Model as ConnectViewModel;
            Assert.IsInstanceOf<Dictionary<string, object>>(model.DeviceInfo);
            Assert.AreEqual(model.DeviceInfo["Version"], "1");
            Assert.AreEqual(model.DeviceInfo["About"], "About");
        }

        /// <summary>(Unit Test Method) Privacy action.</summary>
        [Test]
        public void Privacy()
        {
            var result = this.controller.Privacy();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Privacy", viewResult.ViewName);
            Assert.IsNull(viewResult.ViewData.Model);
        }

        /// <summary>(Unit Test Method) Error action.</summary>
        [Test]
        public void Error()
        {
            var result = this.controller.Error();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
            Assert.IsNotNull(viewResult.ViewData.Model);
            Assert.IsInstanceOf<ErrorViewModel>(viewResult.ViewData.Model);
        }

        /// <summary>Setup for disconnected services.</summary>
        private void SetupDisconnected()
        {
            CameraHandler handler = new(Options);
            this.controller = new(Mock.Of<ILogger<HomeController>>(), Options, handler)
            {
                ControllerContext = new()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            Assert.IsNotNull(this.controller);
        }

        /// <summary>Setup for connected services.</summary>
        private void SetupConnected()
        {
            MockHttpClientHandler httpHandler = new();
            httpHandler
                .AddRequest(HttpMethod.Get, Endpoints.Cameras.Endpoint + "System/deviceInfo")
                .ContentsJson("{'Version': '1', 'About': 'About'}");
            CameraHandler handler = new(Options, httpHandler);
            this.controller = new(Mock.Of<ILogger<HomeController>>(), Options, handler)
            {
                ControllerContext = new()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            Assert.IsNotNull(this.controller);
        }
    }
}