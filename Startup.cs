public class Startup {
    public void ConfigureServices(IServiceCollection services) {
        services.AddControllersWithViews();
        services.AddDbContext<SafeVaultDbContext>(...);
        services.AddAuthentication(...);
        services.AddAuthorization(...);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => {
            endpoints.MapDefaultControllerRoute();
        });
    }
}
