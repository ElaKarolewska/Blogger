﻿using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Domain.Entities.Cosmos;
using Microsoft.Azure.Documents.Client;

namespace WebAPI.Installers
{
    public class CosmosInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
            Configuration["CosmosSettings:DatabaseName"],
            Configuration["CosmosSettings:AccountUri"],
            Configuration["CosmosSettings:AccountKey"],
            new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });

            services.AddCosmosStore<CosmosPost>(cosmosStoreSettings);
        }
    }
}
