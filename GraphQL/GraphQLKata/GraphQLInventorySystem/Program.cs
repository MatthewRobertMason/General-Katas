using GraphQLInventorySystem.Data;
using GraphQLInventorySystem.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GraphQLInventorySystem.GraphQL;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.WebSockets;
using GraphQLInventorySystem.GraphQL.Messaging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<InventoryRepository>();
builder.Services.AddSingleton<ItemRepository>();
builder.Services.AddSingleton<ItemCountsRepository>();

builder.Services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
builder.Services.AddScoped<InventorySchema>();

builder.Services.AddSingleton<UserAddedService>();
builder.Services.AddSingleton<InventoryAddedService>();
builder.Services.AddSingleton<ItemAddedService>();
builder.Services.AddSingleton<ItemCountsAddedService>();

builder.Services.AddSingleton<IDocumentExecuter, SubscriptionDocumentExecuter>();

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

WebSocketOptions wsOptions = new WebSocketOptions();
wsOptions.AllowedOrigins.Add("https://localhost:7128");
wsOptions.AllowedOrigins.Add("http://localhost:5128");
wsOptions.KeepAliveInterval = TimeSpan.FromSeconds(0);
app.UseWebSockets(wsOptions);

app.UseGraphQLWebSockets<InventorySchema>();
app.UseGraphQL<InventorySchema>();
app.UseGraphQLPlayground(new PlaygroundOptions());

app.Run();