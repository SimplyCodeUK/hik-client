// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hikUI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using hik_client;

    /// <summary>Connect view model.</summary>
    public class ConnectViewModel
    {
        /// <summary>Cameras connection settings.</summary>
        public Connection Cameras { get; set; }

        /// <summary>Device information as a string.</summary>
        [Display(Name = "Device Information")]
        public string DeviceInfoString => this.DeviceInfo == null ? "Not connected" : this.DeviceInfo.ToString();

        /// <summary>Device information.</summary>
        public Dictionary<string, object> DeviceInfo;

        /// <summary>Model for connection view.</summary>
        ///
        /// <param name="cameras">Camera connection data.</param>
        public ConnectViewModel(Connection cameras)
        {
            this.Cameras = cameras;
            this.DeviceInfo = null;
        }
    }
}
