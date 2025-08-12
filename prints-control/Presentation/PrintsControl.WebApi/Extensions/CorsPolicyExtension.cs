namespace PrintsControl.WebApi.Extensions;

public static class CorsPolicyExtension
{
    public static void ConfigureCorsPolicy(this ServiceCollection service)
    {
        service.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
}