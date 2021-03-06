using System;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pingo.Core.Reflection;
using Serilog;

namespace Pingo.Core.Startup
{
    public static class ConfigureRegistrantExtensions
    {
        static ILogger logger = Log.ForContext<AutofacModule>();

        public static IApplicationBuilder AddAllConfigureRegistrants(this IApplicationBuilder app)
        {
            bool bCaughtException = false;
            logger.Information("AddAllConfigureRegistrants Enter");
            var types = TypeHelper<ConfigureRegistrant>
                .FindTypesInAssemblies(TypeHelper<ConfigureRegistrant>.IsPublicClassType);
            foreach (var type in types)
            {
                logger.Information("Found:{0}", type);
                var instance = (IConfigureRegistrant)Activator.CreateInstance(type);
                try
                {
                    instance.OnConfigure(app);
                }
                catch (Exception e)
                {
                    bCaughtException = true;
                    logger.Fatal("Failed to call OnConfigure on type:{0},{1}", type, e.Message);
                }
            }
            if (bCaughtException)
            {
                throw new Exception("AddAllConfigureRegistrants had one or more exceptions");
            }
            return app;
        }
    }
}