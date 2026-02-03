using FinanceTracker.Infrastructure;
using FinanceTracker.Web.Components;
using FinanceTracker.Web.States.Errors;
using FinanceTracker.Web.States.Categories;
using FinanceTracker.Web.States.Accounts;
using FinanceTracker.Web.States.Transactions;
using FinanceTracker.Aplication.Categories.Commands;
using FinanceTracker.Aplication.Categories.Queries;
using FinanceTracker.Web.Services.Categories;
using FinanceTracker.Web.Services.Accounts;
using FinanceTracker.Web.Services.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructureServices(builder.Configuration);

// Register CQRS Handlers
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetAllCategories.Handler>();
builder.Services.AddScoped<GetCategoryById.Handler>();

// Register Application Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TransactionService>();

//Register States
builder.Services.AddScoped<ErrorState>();
builder.Services.AddScoped<CategoryState>();
builder.Services.AddScoped<AccountState>();
builder.Services.AddScoped<TransactionState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
