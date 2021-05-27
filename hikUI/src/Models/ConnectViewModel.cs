// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

using hik_client;

namespace hikUI.Models
{
    /// <summary> Connect view model. </summary>
    public class ConnectViewModel
    {
        /// <summary>Cameras connection settings.</summary>
        public Connection Cameras { get; set; }

        /// <summary>Model for connection view.</summary>
        ///
        /// <param name="cameras">Camera connection data.</param>
        public ConnectViewModel(Connection cameras)
        {
            this.Cameras = cameras;
        }
    }
}
