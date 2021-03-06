﻿using Autofac;
using Microsoft.AspNet.Mvc.Filters;
using Pingo.Core.Middleware;
using Pingo.Core.Reflection;
using Serilog;
using System.Reflection;
using System.Linq;
using Module = Autofac.Module;

namespace Pingo.Core
{
    public class AutofacModule : Module
    {
        static ILogger logger = Log.ForContext<AutofacModule>();
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Global>().SingleInstance();
            logger.Information("Hi from pingo.filters Autofac.Load!");
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var derivedTypes = TypeHelper<MiddlewarePlugin>.FindDerivedTypes(assembly).ToArray();
            var derivedTypesName = derivedTypes.Select(x => x.GetTypeInfo().Name);
            logger.Information("Found these types: {DerivedTypes}", derivedTypesName);
            builder.RegisterTypes(derivedTypes).SingleInstance();
        }
    }
}
