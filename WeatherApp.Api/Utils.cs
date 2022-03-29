namespace WeatherApp.Api
{
    public class Utils
    {
        public static bool IsInputValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return true;
        }
    }
}
