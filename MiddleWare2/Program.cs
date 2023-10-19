using MiddleWare2.CustomeMiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CustomMiddleWare>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("MiddleWare 1");
//    await next(context);
//});
//app.UseMiddleware<CustomMiddleWare>();
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("MiddleWare 3");
//    await next(context);
//});
app.CustomMiddleWare();
//app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized")
//&& context.Request.Query["IsAuthorized"] == "false", app =>
//{
//    app.Use(async (context,next) =>
//    {
//         await context.Response.WriteAsync("Conditional MiddleWare");
//        await next(context );
//    });
//});
//app.UseMiddleware();
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("MiddleWare 4");
//});
app.Run();
