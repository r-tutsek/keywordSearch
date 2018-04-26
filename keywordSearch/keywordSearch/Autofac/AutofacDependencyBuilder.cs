using Autofac;
using Autofac.Integration.WebApi;
using keywordSearchData.DAL;
using keywordSearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace keywordSearch
{
    public static class AutofacDependencyBuilder
    {
        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<YoutubeSearchLogService>().As<IYoutubeSearchLogService>();
            builder.RegisterType<YoutubeSearchLogRepository>().As<IYoutubeSearchLogRepository>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }   
    }
}