﻿using System;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pingo.Core.Reflection;
using Serilog;

namespace Pingo.Core.Startup
{
    public static class ConfigureEntityFrameworkRegistrantExtensions
    {
        static ILogger logger = Log.ForContext<ConfigureEntityFrameworkRegistrant>();

        public static EntityFrameworkServicesBuilder AddAllConfigureEntityFrameworkRegistrants(this EntityFrameworkServicesBuilder builder)
        {
            bool bCaughtException = false;
            logger.Information("AddAllConfigureEntityFrameworkRegistrants Enter");
            var types = TypeHelper<ConfigureEntityFrameworkRegistrant>
                .FindTypesInAssemblies(TypeHelper<ConfigureEntityFrameworkRegistrant>.IsPublicClassType);
            foreach (var type in types)
            {
                logger.Information("Found:{0}", type);
                var instance = (IConfigureEntityFrameworkRegistrant)Activator.CreateInstance(type);
                try
                {
                    instance.OnAddDbContext(builder);
                }
                catch (Exception e)
                {
                    bCaughtException = true;
                    logger.Fatal("Failed to call OnAddDbContext on type:{0},{1}", type, e.Message);
                }
            }
            if (bCaughtException)
            {
                throw new Exception("AddAllConfigureServicesRegistrants had one or more exceptions");
            }
            return builder;
        }
    }
}