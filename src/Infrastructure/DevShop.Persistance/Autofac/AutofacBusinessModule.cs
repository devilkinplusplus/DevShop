using Autofac;
using DevShop.Persistance.Services.User;
using DevShop.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevShop.Persistance.Services;
using DevShop.Application.Abstractions.Services.Authentications;
using DevShop.Application.Repositories.Catagory;
using DevShop.Persistance.Repositories.Catagory;

namespace DevShop.Persistance.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<RoleService>().As<IRoleService>();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductpictureService>().As<IProductpictureService>();
            builder.RegisterType<PictureService>().As<IPictureService>();
            builder.RegisterType<CatagoryService>().As<ICatagoryService>();
            builder.RegisterType<CatagorysubService>().As<ICatagorysubService>();
            builder.RegisterType<SubcatagoryService>().As<ISubcatagoryService>();

            builder.RegisterType<CatagoryReadRepository>().As<ICatagoryReadRepository>();
            builder.RegisterType<CatagoryWriteRepository>().As<ICatagoryWriteRepository>();
        }
    }
}
