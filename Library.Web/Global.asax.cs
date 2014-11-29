using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using DataAnnotationsExtensions.ClientValidation.Adapters;
using Kendo.Mvc;
using Library.BusinessLayer.Attributes.Validation;
using Library.Web.Filters;
using CompareAttribute = Library.BusinessLayer.Attributes.Validation.CompareAttribute;

namespace Library.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationFilter());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ModelMetadataProviders.Current = new ModelMetadataProvider();

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(RequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(IntegerAttribute), typeof(IntegerAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(StringLengthAttribute), typeof(StringLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RangeAttribute), typeof(RangeAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EmailAttribute), typeof(EmailAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CompareAttribute), typeof(CompareAttributeAdapter));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var configuration = new Configuration.Configuration();
            configuration.ConfigureDatabase();

            var builder = configuration.GetContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            SiteMapManager.SiteMaps.Register<XmlSiteMap>("Library.en-US", sitmap => sitmap.LoadFrom("~/Sitemaps/Library.en-US.sitemap"));
            SiteMapManager.SiteMaps.Register<XmlSiteMap>("Library.ru-RU", sitmap => sitmap.LoadFrom("~/Sitemaps/Library.ru-RU.sitemap"));
        }
    }
}