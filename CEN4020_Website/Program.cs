using CEN4020_Website.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using CEN4020_Website.Pages.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options => {
        options.Cookie.Name = "MyCookieAuth";
        options.LoginPath = "/LoginRegister/Login";
        options.AccessDeniedPath = "/LoginRegister/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminCredentialsRequired",
        policy => policy.RequireClaim("PapersChair", "Admin"));
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AuthorCredentials",
        policy => policy.RequireClaim("UserAuthor", "Author"));
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("ReviewerCredentials",
        policy => policy.RequireClaim("UserReviewer", "Reviewer"));
});

builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();
builder.Services.Configure<ResetMessageSenderOptions>(options =>
{
    options.SendGridKey = builder.Configuration["ExternalProviders:SendGrid:SENDGRID_API_KEY"];
    options.SenderEmail = builder.Configuration["ExternalProviders:SendGrid:SenderEmail"];
    options.SenderName = builder.Configuration["ExternalProviders:SendGrid:SenderName"];
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
