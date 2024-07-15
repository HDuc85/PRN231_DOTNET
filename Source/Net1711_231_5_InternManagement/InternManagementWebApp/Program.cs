using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
=======

>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
builder.Services.AddRazorPages();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
<<<<<<< HEAD
builder.Services.AddHttpClient(); // Register the HTTP client factory
=======
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
=======
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
<<<<<<< HEAD
=======

>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
