// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>Http Camera Handler.</summary>
    public class HttpCameraReader : ICameraReader
    {
        /// <summary>Connection parameters.</summary>
        private readonly Connection connection;

        /// <summary>Http connection client.</summary>
        private readonly HttpClient client;

        /// <summary>
        /// Initialises a new instance of the <see cref="HttpCameraReader" /> class.
        /// </summary>
        ///
        /// <param name="connection">Connection data.</param>
        /// <param name="handler">Http handler.</param>
        public HttpCameraReader(Connection connection, HttpClientHandler handler)
        {
            this.connection = connection;
            this.client = new(handler);
        }

        /// <summary>Get the device information.</summary>
        ///
        /// <returns>The device information.</returns>
        public async Task<Dictionary<string, object>> GetDeviceInfo()
        {
            var info = await this.GetAsync("ISAPI/System/deviceInfo");

            if (info == null)
            {
                // Try fallback URL
                info = await this.GetAsync("System/deviceInfo");
            }

            if (info == null)
            {
                return null;
            }

            var ret = JsonConvert.DeserializeObject<Dictionary<string, object>>(info);

            return ret;
        }

        /// <summary>Generic asynchronous http get command.</summary>
        ///
        /// <param name="resource">Resource endpoint.</param>
        ///
        /// <returns>null if the request failed or a string value of the body of the http response.</returns>
        private async Task<string> GetAsync(string resource)
        {
            try
            {
                var response = await this.client.GetAsync(this.connection.Endpoint + resource);

                // Throw an exception if not successful
                response.EnsureSuccessStatusCode();

                // Get the content
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
