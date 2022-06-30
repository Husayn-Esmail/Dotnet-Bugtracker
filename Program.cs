using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BugtrackerContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("BugtrackerContext") ?? throw new InvalidOperationException("Connection string 'BugtrackerContext' not found.")));
    builder.Services.AddDbContext<UserContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.")));
    builder.Services.AddDbContext<IssueContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("IssueContext") ?? throw new InvalidOperationException("Connection string 'IssueContext' not found.")));
    builder.Services.AddDbContext<JointUserIssueContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("JointUserIssueContext") ?? throw new InvalidOperationException("Connection string 'JointUserIssueContext' not found.")));
}
else
{
    builder.Services.AddDbContext<BugtrackerContext>(options=>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionBugtrackerContext") ?? throw new InvalidOperationException("Connection string 'ProductionBugtrackerContext' not found.")));
    builder.Services.AddDbContext<UserContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionUserContext") ?? throw new InvalidOperationException("Connection string 'ProductionUserContext' not found.")));
    builder.Services.AddDbContext<IssueContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionIssueContext") ?? throw new InvalidOperationException("Connection string 'ProductionIssueContext' not found.")));
    builder.Services.AddDbContext<JointUserIssueContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionJointUserIssueContext") ?? throw new InvalidOperationException("Connection string 'ProductionJointUserIssueContext' not found.")));
}


// Add services to the container.
builder.Services.AddControllersWithViews();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
