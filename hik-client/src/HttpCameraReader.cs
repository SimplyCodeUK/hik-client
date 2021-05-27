// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary> Http Camera Handler. </summary>
    public class HttpCameraReader : ICameraReader
    {
        /// <summary> Connection parameters. </summary>
        private readonly Connection connection;

        /// <summary> Http connection client. </summary>
        private readonly HttpClient client;

        /// <summary> Constructor. </summary>
        public HttpCameraReader(Connection connection)
        {
            this.connection = connection;
            this.client = new(new HttpClientHandler());
        }

        /// <summary> Get the device information. </summary>
        ///
        /// <returns> The device information. </returns>
        public async Task<string> getDeviceInfo()
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

            return info;
        }

        /// <summary> Generic asynchronous http get command. </summary>
        ///
        /// <param name="resource"> Resource endpoint. </param>
        ///
        /// <returns> null if the request failed or a string value of the body of the http response. </returns>
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
