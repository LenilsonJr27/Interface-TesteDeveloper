using InterfaceTestDev.Models;
using TesteDeveloper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IList<EstoqueProduto>>(new List<EstoqueProduto>());
builder.Services.AddSingleton<GerenciadorEstoque>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Estoque}/{action=Index}/{id?}");

app.Run();
