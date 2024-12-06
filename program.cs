#if DEBUG
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    
    context.Database.EnsureCreated();

    
    SeedData.Generate(context, userManager);
}
#endif
