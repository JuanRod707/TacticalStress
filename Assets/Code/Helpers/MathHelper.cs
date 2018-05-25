namespace Code.Helpers
{
    public static class MathHelper
    {
        public static int CalculatePercentage(int percentage, int total)
        {
            return (percentage * total) / 100;
        }

        public static float CalculatePercentage(float percentage, float total)
        {
            return (percentage * total) / 100f;
        }
    }
}
