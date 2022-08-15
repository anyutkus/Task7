namespace Task7._2
{
    public static class PointGenerator
    {
        public static (double, double, int) GetPoint()
        {
            var c1 = RandomDouble();
            var c2 = RandomDouble();
            var rnd = new Random();
            var k = rnd.Next(0, 3) * 2 + 1;

            return (c1, c2, k);
        }

        private static double RandomDouble()
        {
            Random random = new();
            double result = random.NextDouble();

            return Math.Round(result * 10, 2);
        }
    }
}

