namespace PipelineAppSun;


public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            var kestrelSection = context.Configuration.GetSection("Kestrel");

            serverOptions.Configure(kestrelSection)
                .Endpoint("HTTPS", endpointConfig =>
                {
                    endpointConfig.ListenOptions.UseHttps(httpsOptions =>
                    {
                        httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
                    });
                });
        });
        
        var app = builder.Build();
        
        app.MapControllers();
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        //app.UseAuthorization();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.Run();
    }
}