using Autofac;
using AutoMapper;
using Locadora_filmes_web.Data.Repository;
using Locadora_filmes_web.IOC.Mappers;
using Locadora_filmes_web.Service.Interfaces.Repository;
using Locadora_filmes_web.Service.Services;

namespace Locadora_filmes_web.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            //Cliente
            builder.RegisterType<ClienteService>();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingCliente());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }
}
