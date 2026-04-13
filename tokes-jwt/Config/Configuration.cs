namespace JwtBearer.Config;

public class Configuration
{
    public static string Privatekey { get; set; } = Environment.GetEnvironmentVariable("PRIVATE_KEY") ??
                                                    throw new InvalidOperationException("PRIVATE_KEY not set");
}