// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    /// <summary> Service connection data settings. </summary>
    public class ServiceEndpoints
    {
        /// <summary> Gets or sets the Cameras connection data.</summary>
        ///
        /// <value> The Cameras connection data.</value>
        public Connection Cameras { get; set; }

        /// <summary> Constructor. </summary>
        public ServiceEndpoints()
        {
            this.Cameras = new();
        }
    }
}
