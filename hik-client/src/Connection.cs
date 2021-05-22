// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    public class Connection
    {
        public Connection()
        {
            this.Endpoint = "";
            this.Username = "";
            this.Password = "";
        }

        /// <summary> Gets or sets the Connection endpoint.</summary>
        ///
        /// <value> The Connection endpoint.</value>
        public string Endpoint { get; set; }

        /// <summary> Gets or sets the Connection user name.</summary>
        ///
        /// <value> The Connection user name.</value>
        public string Username { get; set; }

        /// <summary> Gets or sets the Connection password.</summary>
        ///
        /// <value> The Connection password.</value>
        public string Password { get; set; }
    }
}
