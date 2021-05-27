// <copyright company="Simply Code Ltd.">
// Copyright (c) Simply Code Ltd. All rights reserved.
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace hik_client
{
    using System.ComponentModel.DataAnnotations;

    /// <summary> Connection properties. </summary>
    public class Connection
    {
        /// <summary> Constructor </summary>
        public Connection()
        {
            this.Endpoint = "";
            this.Username = "";
            this.Password = "";
        }

        /// <summary> Gets or sets the Connection endpoint.</summary>
        ///
        /// <value> The Connection endpoint.</value>
        [Display(Name = "Endpoint", Prompt = "Enter Endpoint")]
        public string Endpoint { get; set; }

        /// <summary> Gets or sets the Connection user name.</summary>
        ///
        /// <value> The Connection user name.</value>
        [Display(Name = "Username", Prompt = "Enter Username")]
        public string Username { get; set; }

        /// <summary> Gets or sets the Connection password.</summary>
        ///
        /// <value> The Connection password.</value>
        [Display(Name = "Password", Prompt = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
