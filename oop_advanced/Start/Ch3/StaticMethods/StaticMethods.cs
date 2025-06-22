// Example file for Advanced C#: Object Oriented Programming by Joe Marini
// Using static methods

public class Temperature {
    public const double ROOM_TEMP_LOWER_C = 20.0;
    public const double ROOM_TEMP_UPPER_C = 23.0;

    public Temperature(double t) {
        Temp = t;
    }

    public static double FtoC(double FTemp)
    {
        double CTemp = (FTemp - 32.0) * (5.0 / 9.0);
        return CTemp;
    }
    
    public static double CtoF(double CTemp)
    {
        double FTemp = (CTemp * (9.0 / 5.0)) + 32.0;
        return FTemp;
    }
    public double Temp { get; set; }
    
    public static bool IsRoomTemp(double temp) {
        return temp >= ROOM_TEMP_LOWER_C && temp <= ROOM_TEMP_UPPER_C;
    }
    
}
