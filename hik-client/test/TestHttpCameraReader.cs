// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client.Test
{
    using NUnit.Framework;
    using hik_client;
    using System.Net.Http;
    using System.Collections.Generic;

    /// <summary>(Unit Test Fixture) a controller for handling a connection.</summary>
    public class TestHttpCameraReader
    {
        /// <summary>The connection settings.</summary>
        private Connection connection;

        /// <summary>Setup for all unit tests here.</summary>
        [SetUp]
        public void Setup()
        {
            this.connection = new()
            {
                Endpoint = "http://localhost/"
            };
        }

        /// <summary>(Unit Test Method) Constructor.</summary>
        [Test]
        public void GetDeviceInfo()
        {
            HttpMock.MockHttpClientHandler httpHandler = new();
            httpHandler
                .AddRequest(HttpMethod.Get, this.connection.Endpoint + "System/deviceInfo")
                .ContentsJson("{'Version': '1', 'About': 'About'}");
            HttpCameraReader reader = new(this.connection, httpHandler);

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
                .AddRequest(HttpMethod.Get, this.connection.Endpoint + "ISAPI/System/deviceInfo")
                .ContentsJson("{'Version': '1', 'About': 'ISAPI About'}");
            HttpCameraReader reader = new(this.connection, httpHandler);

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
            HttpCameraReader reader = new(this.connection, httpHandler);

            var result = reader.GetDeviceInfo();
            result.Wait();
            Assert.AreEqual(result.Result, null);
        }
    }
}
