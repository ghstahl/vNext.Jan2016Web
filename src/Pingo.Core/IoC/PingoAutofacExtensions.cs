﻿using System;
using System.Reflection;
using Autofac;
using Pingo.Core.Attributes;
using Pingo.Core.Reflection;
using Serilog;

namespace Pingo.Core.IoC
{
    public static class PingoAutofacExtensions
    {
        static ILogger logger = Log.ForContext<AutofacModule>();

/*************************************************************************************************
Place the attribute, ServiceRegistrant, on the class you which to auto register and tell me what types
In the case below we want the implamenter: AuthMessageSender, to be used for the IEmailSender, and ISmsSender types

  [ServiceRegistrant(typeof(IEmailSender), typeof(ISmsSender))]
    public class AuthMessageSender : IEmailSender, ISmsSender{}

Usage:
    public class AutofacModule : Module
    {
        static ILogger logger = Log.ForContext<AutofacModule>();
        protected override void Load(ContainerBuilder builder)
        {
            logger.Information("Hi from Pingo.Authorization Autofac.Load!");
            var assembly = this.GetType().GetTypeInfo().Assembly;
            builder.AutoRegisterServiceRegistrants(assembly);
        }
    }
*************************************************************************************************/
        public static void AutoRegisterServiceRegistrants(this ContainerBuilder builder,Assembly assembly)
        {
            var types = TypeHelper<Type>.FindTypesInAssembly(assembly);
            types = TypeHelper<Type>.FindTypesWithCustomAttribute<ServiceRegistrantAttribute>(types);
            foreach (var type in types)
            {

                var attribute = type.GetTypeInfo().GetCustomAttribute<ServiceRegistrantAttribute>();
                logger.Information("Found:{0}, with:{1}", type, attribute.Types);
                builder.RegisterType(type).As(attribute.Types);
            }
        }
    }
}
