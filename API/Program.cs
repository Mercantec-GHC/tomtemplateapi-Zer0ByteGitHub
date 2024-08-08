using API.Components;

var WebBuilder = WebApplication.CreateBuilder(args);

// Add services to the container.
WebBuilder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
WebBuilder.Services.AddHttpClient();

var app = WebBuilder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change t  his for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
