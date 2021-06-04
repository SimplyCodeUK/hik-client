// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    /// <summary>Camera Reader.</summary>
    public class CameraHandler
    {
        /// <summary>Connection parameters.</summary>
        private readonly Connection connection;

        /// <summary>Http connection client.</summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="CameraHandler" /> class.
        /// </summary>
        ///
        /// <param name="appSettings">App settings.</param>
        public CameraHandler(IOptions<AppSettings> appSettings)
            : this(appSettings, new())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CameraHandler" /> class.
        /// </summary>
        ///
        /// <param name="appSettings">App settings.</param>
        /// <param name="handler">Http handler.</param>
        public CameraHandler(IOptions<AppSettings> appSettings, HttpClientHandler handler)
        {
            this.connection = appSettings.Value.ServiceEndpoints.Cameras;
            this.httpClient = new(handler);
            this.TimeOut = new(0, 0, 0, 0, this.connection.Timeout);
        }

        /// <summary> Gets or sets the time out for http calls. </summary>
        ///
        /// <value> The time out. </value>
        public TimeSpan TimeOut
        {
            get => this.httpClient.Timeout;
            set => this.httpClient.Timeout = value;
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
                var response = await this.httpClient.GetAsync(this.connection.Endpoint + resource);

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
