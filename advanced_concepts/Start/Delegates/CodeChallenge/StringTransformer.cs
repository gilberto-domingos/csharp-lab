namespace CodeChallenge;

public static class StringTransformer
{
    private static Func<string, string> transformer;

    private static string mode;
    public static string Mode
    {
        get => mode;
        set
        {
            mode = value;
            switch (mode)
            {
                case "UPPER":
                    transformer = ToUpper;
                    break;
                case "LOWER":
                    transformer = ToLower;
                    break;
                case "REVERSE":
                    transformer = Reverse;
                    break;
                default:
                    transformer = s => s; // Fallback
                    break;
            }
        }
    }

    public static string TransformString(string input)
    {
        return transformer(input);
    }

    private static string ToUpper(string s) => s.ToUpper();

    private static string ToLower(string s) => s.ToLower();

    private static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}