// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    /// <summary> Camera Handler. </summary>
    public class CameraHandler
    {
        /// <summary> The data reader </summary>
        private readonly ICameraReader reader;

        /// <summary> Constructor </summary>
        public CameraHandler(ICameraReader reader)
        {
            this.reader = reader;
        }
    }
}
