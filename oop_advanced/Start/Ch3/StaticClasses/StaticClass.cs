public static class Converter {
    public static double INCH_CM_CONVERT = 2.54;

    public static double InToCm(double inches) {
        return inches * INCH_CM_CONVERT;
    }

    public static double CmToIn(double centimeters) {
        return centimeters / INCH_CM_CONVERT;
    }
}
