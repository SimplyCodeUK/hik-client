// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client.Test
{
    using NUnit.Framework;
    using hik_client;

    /// <summary> (Unit Test Fixture) a controller for handling a connection. </summary>
    public class TestConnection
    {
        /// <summary> The connection under test. </summary>
        private Connection connection;

        /// <summary> Setup for all unit tests here. </summary>
        [SetUp]
        public void Setup()
        {
            this.connection = new Connection();
        }

        /// <summary> (Unit Test Method) Constructor. </summary>
        [Test]
        public void Constructor()
        {
            Assert.AreEqual(this.connection.Endpoint, "");
            Assert.AreEqual(this.connection.Username, "");
            Assert.AreEqual(this.connection.Password, "");
        }
    }
}