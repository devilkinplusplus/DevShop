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
using DevShop.Persistance.Repositories.Subcatagory;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Application.Repositories.Catagorysub;
using DevShop.Persistance.Repositories.Catagorysub;
using DevShop.Persistance.Repositories.Products;
using DevShop.Application.Repositories.Products;
using DevShop.Persistance.Repositories.Pictures;
using DevShop.Application.Repositories.Pictures;
using DevShop.Persistance.Repositories.ProductPictures;
using DevShop.Application.Repositories.ProductPictures;
using DevShop.Persistance.Repositories.Reviews;
using DevShop.Application.Repositories.Reviews;

namespace DevShop.Persistance.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Idenity Services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            //Services
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductpictureService>().As<IProductpictureService>();
            builder.RegisterType<PictureService>().As<IPictureService>();
            builder.RegisterType<CatagoryService>().As<ICatagoryService>();
            builder.RegisterType<CatagorysubService>().As<ICatagorysubService>();
            builder.RegisterType<SubcatagoryService>().As<ISubcatagoryService>();
            builder.RegisterType<ReviewService>().As<IReviewService>();
            //Repositories
            builder.RegisterType<CatagoryReadRepository>().As<ICatagoryReadRepository>();
            builder.RegisterType<CatagoryWriteRepository>().As<ICatagoryWriteRepository>();
            builder.RegisterType<SubcatagoryReadRepository>().As<ISubcatagoryReadRepository>();
            builder.RegisterType<SubcatagoryWriteRepository>().As<ISubcatagoryWriteRepository>();
            builder.RegisterType<CatagorysubReadRepository>().As<ICatagorysubReadRepository>();
            builder.RegisterType<CatagorysubWriteRepository>().As<ICatagorysubWriteRepository>();
            builder.RegisterType<ProductReadRepository>().As<IProductReadRepository>();
            builder.RegisterType<ProductWriteRepository>().As<IProductWriteRepository>();
            builder.RegisterType<PictureReadRepository>().As<IPictureReadRepository>();
            builder.RegisterType<PictureWriteRepository>().As<IPictureWriteRepository>();
            builder.RegisterType<ProductPictureReadRepository>().As<IProductPictureReadRepository>();
            builder.RegisterType<ProductPictureWriteRepository>().As<IProductPictureWriteRepository>();
            builder.RegisterType<ReviewReadRepository>().As<IReviewReadRepository>();
            builder.RegisterType<ReviewWriteRepository>().As<IReviewWriteRepository>();
        }
    }
}
