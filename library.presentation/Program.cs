using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using library.data.Data;
using library.data.Identity;
using library.business.Mapper;
using library.business.Services.AccountServices;
using library.business.Services.BookServices;
using library.business.Services.ContactServices;
using library.business.Services.HomeServices;
using library.business.Services.LendServices;
using library.business.Services.MemberServices;
using library.data.Repositories;
using library.data.Repositories.BookRepository;
using library.data.Repositories.ContactRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQLConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
        options.Lockout.AllowedForNewUsers = true;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true; 
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".LibraryApp.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };
});

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILendService, LendService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name:"admin",
    areaName:"AdminPanel",
    pattern:"admin/{controller=Book}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
