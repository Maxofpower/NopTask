//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Widgets.m2hwebTask.Controllers;
using Nop.Plugin.Widgets.m2hwebTask.Data;
using Nop.Plugin.Widgets.m2hwebTask.Domain;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.m2hweb.Infrastructure
{

	public class DependencyRegistrar : IDependencyRegistrar
	{
	
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
		{
            this.RegisterPluginDataContext<m2hwebHtmlRecordObjectContext>(builder, "nop_object_context_m2hweb");
            builder.RegisterType<EfRepository<m2hwebRecord>>().As<IRepository<m2hwebRecord>>().WithParameter<EfRepository<m2hwebRecord>, ConcreteReflectionActivatorData, SingleRegistrationStyle>(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_m2hweb")).InstancePerLifetimeScope();
            //this.RegisterPluginDataContext<UnlimitedHtmlRecordObjectContext>(builder, "nop_object_context_m2hweb");
            builder.RegisterType<m2hwebRecord>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));

		}

	
		public int Order
		{
			get
			{
				return 1;
			}
		}

		
		private const string CONTEXT_NAME = "nop_object_context_m2hweb";
	}
}
