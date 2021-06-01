// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Camera Handler.</summary>
    public class CameraHandler
    {
        /// <summary>The data reader</summary>
        private readonly ICameraReader reader;

        /// <summary>
        /// Initialises a new instance of the <see cref="CameraHandler" /> class.
        /// </summary>
        ///
        /// <param name="reader">The camera reader</param>
        public CameraHandler(ICameraReader reader)
        {
            this.reader = reader;
        }

        /// <summary>Get the device information.</summary>
        ///
        /// <returns>The device information.</returns>
        public Task<Dictionary<string, object>> GetDeviceInfo()
        {
            return this.reader.GetDeviceInfo();
        }
    }
}
