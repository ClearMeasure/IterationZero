using System;
using System.Web;
using System.Web.Mvc;
using Core;
using Infrastructure.DataAccess;
using StructureMap;

namespace Infrastructure.DependencyResolution
{
	public class DependencyRegistrarModule : IHttpModule
	{
		private static bool _dependenciesRegistered;
		private static readonly object Lock = new object();

		public void Init(HttpApplication context)
		{
			context.BeginRequest += context_BeginRequest;
		}

		public void Dispose() {}

		private static void context_BeginRequest(object sender, EventArgs e)
		{
			EnsureDependenciesRegistered();
		}

		public static void EnsureDependenciesRegistered()
		{
			if (!_dependenciesRegistered)
			{
				lock (Lock)
				{
					if (!_dependenciesRegistered)
					{
					    Initialize();
                        DataContext.EnsureStartup();
						_dependenciesRegistered = true;
					}
				}
			}
		}

	    private static void Initialize()
	    {
            ObjectFactory.Initialize(x => x.AddRegistry<StructureMapRegistry>());
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
	        VisitorRepositoryFactory.Build = () => ObjectFactory.GetInstance<IVisitorRepository>();
	    }

	}
}