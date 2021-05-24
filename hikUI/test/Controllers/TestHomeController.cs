// <copyright company="Louis Henry Nayegon.">
// Copyright (c) Louis Henry Nayegon. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Test
{
    using NUnit.Framework;
    using hikUI.Controllers;
    using Moq;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using hikUI.Models;

    /// <summary> (Unit Test Fixture) a controller for handling test materials. </summary>
    public class TestHomeController
    {
        /// <summary> The controller under test. </summary>
        private HomeController controller;

        /// <summary> Setup for all unit tests here. </summary>
        [SetUp]
        public void Setup()
        {
            this.SetupDisconnected();
        }

        /// <summary> (Unit Test Method) Index action. </summary>
        [Test]
        public void Index()
        {
            var result = this.controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Index", viewResult.ViewName);
            Assert.IsNull(viewResult.ViewData.Model);
        }

        /// <summary> (Unit Test Method) Privacy action. </summary>
        [Test]
        public void Privacy()
        {
            var result = this.controller.Privacy();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual("Privacy", viewResult.ViewName);
            Assert.IsNull(viewResult.ViewData.Model);
        }

        /// <summary> (Unit Test Method) Error action. </summary>
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

        /// <summary> Setup for disconnected services. </summary>
        private void SetupDisconnected()
        {
            this.controller = new(Mock.Of<ILogger<HomeController>>())
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