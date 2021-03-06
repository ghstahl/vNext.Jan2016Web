﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using IdentityServer4.Core.Services.InMemory;

namespace P6IdentityServer4.Services
{
    /// <summary>
    /// In-memory client store
    /// </summary>
    public class JsonClientStore : IClientStore
    {
        readonly IEnumerable<Client> _clients;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryClientStore"/> class.
        /// </summary>
        /// <param name="clients">The clients.</param>
        public JsonClientStore(IEnumerable<Client> clients)
        {
            _clients = clients;
        }

        /// <summary>
        /// Finds a client by id
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns>
        /// The client
        /// </returns>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            try
            {
                var temp = new Client
                {
                    ClientId = "client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.ClientCredentials,

                    AllowedScopes = new List<string>
                    {
                        "api1",
                        "api2"
                    }
                };

                var query =
                    from client in _clients
                    where client.ClientId == clientId && client.Enabled
                    select client;

                var result = query.SingleOrDefault();
                return Task.FromResult(result);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
