using ASP_Test.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddDbContext<VideoDbContext> (dbContextOptns =>
{
    dbContextOptns.UseNpgsql("Host=localhost;Port=5432;Database=VideoStore;Username=postgres;Password=2113");
});
builder.Services.AddScoped<IVideoData, SQLData>();
//builder.Services.AddSingleton<IVideoData, TestData>();
builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
    _ = endpoints.MapRazorPages()
    );


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
