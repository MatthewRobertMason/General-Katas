using GraphQLKata.Data;
using GraphQLKata.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GraphQLKata.GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Server.Transports.AspNetCore;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<PersonRepository>();

builder.Services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
builder.Services.AddScoped<SimpleSchema>();
builder.Services.AddSingleton<PersonAddedService>();

builder.Services.AddWebSockets(o => o.KeepAliveInterval = TimeSpan.FromSeconds(0));

builder.Services.AddGraphQL()
    .AddGraphTypes(ServiceLifetime.Scoped)
    .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
    .AddErrorInfoProvider(p => p.ExposeExceptionStackTrace = true)
    .AddDataLoader()
    .AddWebSockets();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.UseWebSockets(new WebSocketOptions() { KeepAliveInterval = TimeSpan.FromSeconds(0)});
app.UseGraphQLWebSockets<SimpleSchema>("/graphql");
app.UseGraphQL<SimpleSchema>();
app.UseGraphQLPlayground(new PlaygroundOptions());

app.Run();
