// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Camera Reader Interface.</summary>
    public interface ICameraReader
    {
        /// <summary>Get the device information.</summary>
        ///
        /// <returns>The device information.</returns>
        Task<Dictionary<string, object>> GetDeviceInfo();
    }
}
