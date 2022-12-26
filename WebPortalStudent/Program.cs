using WebPortalStudent.Models;
using Microsoft.AspNetCore.HttpOverrides;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net;
using WebPortalStudent.Lib;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebPortalStudent.Services;
using WebPortalStudent.Mapper;
using WebPortalStudent.Lib;
using WebPortalStudent.Mapper;

void GetDefaultHttpClient(IServiceProvider serviceProvider, HttpClient httpClient, string hostUri)
{
    if (!string.IsNullOrEmpty(hostUri))
        httpClient.BaseAddress = new Uri(hostUri);
    //client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
    httpClient.Timeout = TimeSpan.FromMinutes(1);
    httpClient.DefaultRequestHeaders.Clear();
    httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}

HttpClientHandler GetDefaultHttpClientHandler()
{
    return new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
        UseCookies = false,
        AllowAutoRedirect = false,
        UseDefaultCredentials = true,
        //ClientCertificateOptions = ClientCertificateOption.Manual, //No check SSL host
        //ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true, //No check SSL host
    };
}

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie = new CookieBuilder
    {
        Name = "Authentication",
        HttpOnly = true,
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always
    };
    options.LoginPath = new PathString("/Account/LogIn");
    options.LogoutPath = new PathString("/Account/SignOut");
    options.AccessDeniedPath = new PathString("/Error/403");
    options.SlidingExpiration = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient("base")
    .ConfigureHttpClient((serviceProvider, httpClient) => GetDefaultHttpClient(serviceProvider, httpClient, builder.Configuration.GetSection("ApiSettings:UrlApi").Value))
    .SetHandlerLifetime(TimeSpan.FromMinutes(5)) //Default is 2 min
    .ConfigurePrimaryHttpMessageHandler(x => GetDefaultHttpClientHandler());

builder.Services.AddHttpClient("custom")
    .ConfigureHttpClient((serviceProvider, httpClient) => GetDefaultHttpClient(serviceProvider, httpClient, string.Empty))
    .SetHandlerLifetime(TimeSpan.FromMinutes(5)) //Default is 2 min
    .ConfigurePrimaryHttpMessageHandler(x => GetDefaultHttpClientHandler());

builder.Services.AddSingleton<IBase_CallApi, Base_CallApi>();
builder.Services.AddSingleton<ICallBaseApi, CallBaseApi>();
builder.Services.AddSingleton<ICallApi, CallApi>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.Configure<Config_ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.Configure<Config_TokenUploadFile>(builder.Configuration.GetSection("TokenUploadFile"));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<IS_Person, S_Person>();
builder.Services.AddScoped<IS_News, S_News>();
builder.Services.AddScoped<IS_NewsCategory, S_NewsCategory>();
builder.Services.AddScoped<IS_TeacherSubject, S_TeacherSubject>();
builder.Services.AddScoped<IS_Subject, S_Subject>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor,

        // IIS is also tagging a X-Forwarded-For header on, so we need to increase this limit, 
        // otherwise the X-Forwarded-For we are passing along from the browser will be ignored
        ForwardLimit = 2
    });

    app.UseDeveloperExceptionPage();
}

app.UseRequestLocalization();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

//app.UseMiddleware<SecurityHeadersMiddleware>(); //App config security header

app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        const int durationInSeconds = 7 * 60 * 60 * 24; //7 days
        ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] =
                "public,max-age=" + durationInSeconds;
    }
});

app.UseRouting();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "News",
        pattern: "tin-tuc",
        defaults: new { controller = "News", action = "Index" });
    endpoints.MapControllerRoute(
        name: "News Page",
        pattern: "tin-tuc/{titleSlug}-{id}",
        defaults: new { controller = "News", action = "Detail" });
    endpoints.MapControllerRoute(
        name: "History update",
        pattern: "history-update",
        defaults: new { controller = "HistoryUpdate", action = "Index" });
    endpoints.MapControllerRoute(
        name: "Teacher Subject",
        pattern: "giao-vien-mon/{name}",
        defaults: new { controller = "Teacher", action = "Subject" });
    endpoints.MapControllerRoute(
        name: "Error page",
        pattern: "error/{statusCode}",
        defaults: new { controller = "Error", action = "Index" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
