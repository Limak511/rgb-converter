
namespace RGBConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int conversionType = 0;
                string? conversionTypeUserInput = string.Empty;
                do
                {
                    Console.Clear();
                    Console.Write("Which RGB Conversion Type:\n1. from 0-1 to 0-255 conversion\n2. from 0-255 to 0-1 conversion\n0. Exit program\n\nEnter conversion type number: ");
                    conversionTypeUserInput = Console.ReadLine();
                } while (!CanConvertToInt(out conversionType, conversionTypeUserInput) || !IsNumberInRange(conversionType, 0, 2));

                switch (conversionType)
                {
                    case 1:
                        float redValue;
                        float greenValue;
                        float blueValue;
                        int colorEndRange = 1;
                        EnterColorValueValidator(out redValue, "red", colorEndRange);
                        EnterColorValueValidator(out greenValue, "green", colorEndRange);
                        EnterColorValueValidator(out blueValue, "blue", colorEndRange);
                        Console.Clear();
                        Console.WriteLine($"RGB ({redValue}, {greenValue}, {blueValue}) => RGB ({MathF.Round(redValue * 255)}, {MathF.Round(greenValue * 255)}, {MathF.Round(blueValue * 255)})");
                        break;
                    case 2:
                        colorEndRange = 255;
                        EnterColorValueValidator(out redValue, "red", colorEndRange);
                        EnterColorValueValidator(out greenValue, "green", colorEndRange);
                        EnterColorValueValidator(out blueValue, "blue", colorEndRange);
                        Console.Clear();
                        var fractionNumbersToKeep = 3;
                        Console.WriteLine($"RGB ({redValue}, {greenValue}, {blueValue}) => " +
                            $"RGB ({MathF.Round(redValue / 255, fractionNumbersToKeep)}, {MathF.Round(greenValue / 255, fractionNumbersToKeep)}, {MathF.Round(blueValue / 255, fractionNumbersToKeep)})");
                        break;
                    case 0:
                        return;
                }

                Console.Read();
            }
        }



        private static void EnterColorValueValidator(out float colorValue, string colorName, int colorEndRange)
        {
            string? colorValueUserInput = string.Empty;
            do
            {
                Console.Clear();
                Console.Write($"Enter {colorName.ToUpper()} value (0-{colorEndRange}): ");
                colorValueUserInput = Console.ReadLine();
            } while (!CanConvertToFloat(out colorValue, colorValueUserInput) || !IsNumberInRange(colorValue, 0, colorEndRange));
        }
        private static bool CanConvertToInt(out int conversionType, string? conversionTypeUserInput)
        {
            return int.TryParse(conversionTypeUserInput, out conversionType);
        }
        private static bool CanConvertToFloat(out float conversionType, string? conversionTypeUserInput)
        {
            return float.TryParse(conversionTypeUserInput, out conversionType);
        }
        private static bool IsNumberInRange(int number, int startRange, int endRange)
        {
            return number >= startRange && number <= endRange;
        }
        private static bool IsNumberInRange(float number, int startRange, int endRange)
        {
            return number >= startRange && number <= endRange;
        }
    }
}
