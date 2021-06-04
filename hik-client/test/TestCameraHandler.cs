// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client.Test
{
    using System.Net.Http;
    using System.Collections.Generic;
    using Microsoft.Extensions.Options;
    using NUnit.Framework;
    using hik_client;

    /// <summary>(Unit Test Fixture) a controller for handling a connection.</summary>
    public class TestCameraHandler
    {
        /// <summary>The connection settings.</summary>
        private static readonly Connection Connection = new()
        {
            Endpoint = "http://localhost:8000/"
        };

        /// <summary> The service endpoints. </summary>
        private static readonly ServiceEndpoints Endpoints = new()
        {
            Cameras = Connection
        };

        /// <summary> The application settings. </summary>
        private static readonly AppSettings AppSettings = new()
        {
            ServiceEndpoints = Endpoints
        };

        /// <summary> The options. </summary>
        private static readonly IOptions<AppSettings> Options = new OptionsWrapper<AppSettings>(AppSettings);

        /// <summary>Setup for all unit tests here.</summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>(Unit Test Method) Constructor.</summary>
        [Test]
        public void GetDeviceInfo()
        {
            HttpMock.MockHttpClientHandler httpHandler = new();
            httpHandler
                .AddRequest(HttpMethod.Get, Connection.Endpoint + "System/deviceInfo")
                .ContentsJson("{'Version': '1', 'About': 'About'}");
            CameraHandler reader = new(Options, httpHandler);

            var result = reader.GetDeviceInfo();
            result.Wait();
            Assert.IsInstanceOf<Dictionary<string, object>>(result.Result);
            Assert.AreEqual(result.Result["Version"], "1");
            Assert.AreEqual(result.Result["About"], "About");
        }

        /// <summary>(Unit Test Method) Get Device Info ISAPI url.</summary>
        [Test]
        public void GetDeviceInfoISAPI()
        {
            HttpMock.MockHttpClientHandler httpHandler = new();
            httpHandler
                .AddRequest(HttpMethod.Get, Connection.Endpoint + "ISAPI/System/deviceInfo")
                .ContentsJson("{'Version': '1', 'About': 'ISAPI About'}");
            CameraHandler reader = new(Options, httpHandler);

            var result = reader.GetDeviceInfo();
            result.Wait();
            Assert.IsInstanceOf<Dictionary<string, object>>(result.Result);
            Assert.AreEqual(result.Result["Version"], "1");
            Assert.AreEqual(result.Result["About"], "ISAPI About");
        }

        /// <summary>(Unit Test Method) Get Device Info.</summary>
        [Test]
        public void GetDeviceInfoFail()
        {
            HttpMock.MockHttpClientHandler httpHandler = new();
            CameraHandler reader = new(Options, httpHandler);

            var result = reader.GetDeviceInfo();
            result.Wait();
            Assert.AreEqual(result.Result, null);
        }
    }
}
