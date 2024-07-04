namespace AspNetCoreEmpty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // place to register our services
            //builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            // place to set the request pipeline

            app.MapDefaultControllerRoute();
            
            app.Run();
           
        }
    }
}




/*

var builder = WebApplication.CreateBuilder(args);// setup server with default values
                                                 // createBuilder creates a server with default settings, args= inputs from command line

// between builder and app => this is the place where we register our services

var app = builder.Build(); // builds the server with default configurations mentioned

//setting the request pipeline (between builder.build and app.run) =>

//---------------------------------------------------------------------------------------------------------------
//app.Use(async (context, next)=>{
//    Console.WriteLine("Middleware one Request");
//    await context.Response.WriteAsync("Hello from Middleware One");
//    await next();
//    Console.WriteLine("Middleware one Response");
//});

//app.Use(async (context, next) => {
//    Console.WriteLine("Middleware two Request");
//    await context.Response.WriteAsync("Hello from Middleware Two");
//    await next();
//    Console.WriteLine("Middleware two Response");
//});
//---------------------------------------------------------------------------------------------------------------

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//var options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("foo.html");
//app.UseDefaultFiles(options);

// order of middleware is important

//app.UseDefaultFiles(); // it will go and check wwwroot if index.html or index.htm or default.html or default.htm are present and executes them
//app.UseStaticFiles(); // when we write this the below code won't be executed... (it gets short circuited)

// instead of writing the above two middlewares seperately, we have a middleware which does both the works at a time
var options = new FileServerOptions();
options.DefaultFilesOptions.DefaultFileNames.Clear();
options.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
app.UseFileServer(options);


app.Use(async (context, next) => {
    //throw new Exception("Error");
    await context.Response.WriteAsync($"Environment = {builder.Environment.EnvironmentName}  ");
    //await context.Response.WriteAsync($"Welcome to {app.Configuration["Logging:LogLevel:Default"]}");
    await context.Response.WriteAsync($"Welcome to {app.Configuration["Company"]}");
    await next();
});

app.Run();

*/