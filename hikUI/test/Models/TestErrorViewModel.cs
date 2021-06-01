// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Test.Models
{
    using NUnit.Framework;
    using hikUI.Models;

    /// <summary>(Unit Test Fixture) a controller for handling test materials.</summary>
    public class TestErrorViewModel
    {
        /// <summary>(Unit Test Method) Index action.</summary>
        [Test]
        public void Constructor()
        {
            ErrorViewModel model = new();
            Assert.IsFalse(model.ShowRequestId);
        }

        /// <summary>(Unit Test Method) Connect action.</summary>
        [Test]
        public void EmptyRequestId()
        {
            ErrorViewModel model = new()
            {
                RequestId = ""
            };
            Assert.IsFalse(model.ShowRequestId);
        }

        /// <summary>(Unit Test Method) Connect action.</summary>
        [Test]
        public void HasRequestId()
        {
            ErrorViewModel model = new()
            {
                RequestId = "request"
            };
            Assert.IsTrue(model.ShowRequestId);
        }
    }
}