using MassTransit;

namespace RabbitMQ.Extensions;

internal static class AppExtensions
{
    public static void AddRabbitMqService(this IServiceCollection services)
    {
        services.AddTransient<IBusPublish, PublishBus>();

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<RelatorioSolicitadoEnventConsumer>();

            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                var username = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
                var password = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
                var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
                var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST");

                cfg.Host(new Uri($"amqp://{host}:5672{vhost}"), hostCfg =>
                {
                    hostCfg.Username(username);
                    hostCfg.Password(password);
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}