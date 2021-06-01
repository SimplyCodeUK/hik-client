// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client.Test
{
    using NUnit.Framework;
    using hik_client;

    /// <summary>(Unit Test Fixture) a controller for handling a connection.</summary>
    public class TestServiceEndpoints
    {
        /// <summary>The service endpoint under test.</summary>
        private ServiceEndpoints serviceEndpoints;

        /// <summary>Setup for all unit tests here.</summary>
        [SetUp]
        public void Setup()
        {
            this.serviceEndpoints = new();
        }

        /// <summary>(Unit Test Method) Constructor.</summary>
        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.serviceEndpoints.Cameras);
        }
    }
}