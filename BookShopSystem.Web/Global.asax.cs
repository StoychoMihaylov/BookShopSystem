using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BookShopSytem.Models.Bms.Authors;
using BookShopSytem.Models.Bms.Books;
using BookShopSytem.Models.Bms.Categories;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.Vms.Authors;
using BookShopSytem.Models.Vms.Books;
using BookShopSytem.Models.Vms.Categories;

namespace BookShopSystem.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Author, DetailedAuthorVm>()
                .ForMember(vm => vm.BookTitles, configurationExpression =>
                configurationExpression.MapFrom(author => author.Books.Select(book => book.Title)));

                expression.CreateMap<AddAuthorBm, Author>();

                expression.CreateMap<Book, AuthorBookVm>()
                .ForMember(vm => vm.CategoryNames, configurationExpression =>
                configurationExpression.MapFrom(book => book.Categories.Select(category => category.Name)));

                expression.CreateMap<Book, ShortBookVm>();

                expression.CreateMap<EditBookBm, Book>()
                    .ForMember(book => book.ReleaseDate, configurationExpression =>
                        configurationExpression.MapFrom(vm => DateTime.ParseExact(vm.ReleaseDate, "dd-MM-yyyy", null)));

                expression.CreateMap<Author, DetailedBookAuthorVm>()
                    .ForMember(vm => vm.FullName, configurationExpression =>
                        configurationExpression.MapFrom(author => author.FirstName + " " + author.LastName));

                expression.CreateMap<Book, DetailedBookVm>()
                    .ForMember(vm => vm.CategoryNames, configurationExpression =>
                        configurationExpression.MapFrom(book => book.Categories.Select(category => category.Name)));

                expression.CreateMap<Category, CategoryVm>();

                expression.CreateMap<AddCategoryBm, Category>();

                expression.CreateMap<AddBookBm, Book>().ForMember(book => book.Categories, 
                    configurationExpression => configurationExpression.Ignore());
            });
        }
    }
}
