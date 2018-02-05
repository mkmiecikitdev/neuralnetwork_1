using System;

public class RandomGenerator {

    private static Random random = new Random();

    public static double Double(double min, double max) {
        if (min > max)
            throw new ArgumentException("min should be less than max");
        return random.NextDouble() * (max - min) + min;
    }

    public static double Double() {
        return random.NextDouble();
    }

    public static int Next(int min, int max) {
        if (min > max)
            throw new ArgumentException("min should be less than max");
        return random.Next(min, max + 1);
    }

    public static float Float() {
        return (float)Double();
    }
	
}
