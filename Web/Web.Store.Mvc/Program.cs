using Web.Store.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// HttpClients
builder.Services.AddHttpClient<PeopleApiClient>(c =>
    c.BaseAddress = new Uri("http://localhost:5011/"));
builder.Services.AddHttpClient<CepApiClient>(c =>
    c.BaseAddress = new Uri("http://localhost:5021/"));

var app = builder.Build();

// Em dev, sem HSTS pra simplificar
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Descomente a linha abaixo se quiser remover redirecionamento HTTPS
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=People}/{action=Index}/{id?}");

// ⚠️ ESSENCIAL
app.Run();
