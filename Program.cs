using JPT.Data;
using JPT.Services;
using JPT.Hubs;
using YourApp.Services;

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IServiceTicket, ServiceTicket>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ServiceTicket}/{action=Index}/{id?}");

app.MapHub<SupportTicketHub>("/supportTicketHub");
app.MapHub<ChatHub>("/chatHub");

app.Run();
