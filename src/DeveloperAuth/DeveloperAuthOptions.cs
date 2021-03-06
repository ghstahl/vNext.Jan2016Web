// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNet.Authentication.P6Common.Messages;
using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Authentication.DeveloperAuth
{
    /// <summary>
    /// Options for the DeveloperAuth authentication middleware.
    /// </summary>
    public class DeveloperAuthOptions : RemoteAuthenticationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperAuthOptions"/> class.
        /// </summary>
        public DeveloperAuthOptions()
        {
            AuthenticationScheme = DeveloperAuthDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-developerauth");
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            Events = new DeveloperAuthEvents();
        }

        /// <summary>
        /// Gets or sets the consumer key used to communicate with DeveloperAuth.
        /// </summary>
        /// <value>The consumer key used to communicate with DeveloperAuth.</value>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret used to sign requests to DeveloperAuth.
        /// </summary>
        /// <value>The consumer secret used to sign requests to DeveloperAuth.</value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public static ISecureDataFormat<RequestToken> StateDataFormat { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IDeveloperAuthEvents"/> used to handle authentication events.
        /// </summary>
        public new IDeveloperAuthEvents Events
        {
            get { return (IDeveloperAuthEvents)base.Events; }
            set { base.Events = value; }
        }

        /// <summary>
        /// Defines whether access tokens should be stored in the
        /// <see cref="ClaimsPrincipal"/> after a successful authentication.
        /// This property is set to <c>false</c> by default to reduce
        /// the size of the final authentication cookie.
        /// </summary>
        public bool SaveTokensAsClaims { get; set; }
    }
}
