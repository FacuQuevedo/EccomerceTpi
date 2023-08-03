using Service.Inmplementations;
using Service.Interfaces;
namespace Eccomerce
{
    public static class CompositeRoot
    {
        public static void DependecyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserSerivice>();
            builder.Services.AddScoped<IAuthService, AuthSerivce>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<IShippingService, ShippingService>();
            //builder.Services.AddScoped<IVariantService, VariantService>();
            builder.Services.AddScoped<IsalesService, SalesService>();

        }

    }
}
