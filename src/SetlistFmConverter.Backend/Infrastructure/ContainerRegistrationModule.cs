using System.Reflection;
using Autofac;
using SetlistFmConverter.Backend.Infrastructure.Base;
using Module = Autofac.Module;

namespace SetlistFmConverter.Backend.Infrastructure;

public class ContainerRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var services =
            Assembly
                .GetExecutingAssembly()
                .GetTypes().Where(t => t is { IsClass: true, IsAbstract: false } &&
                                       typeof(BaseService).IsAssignableFrom(t))
                .ToArray();
        
        builder.RegisterTypes(services).AsImplementedInterfaces();
    }
}