using System;

namespace ShapeDrawer.UI
{
    public static class ConsoleTool
    {
        private const ConsoleColor WarningColor = ConsoleColor.Yellow;
        private const ConsoleColor ErrorColor = ConsoleColor.Red;

        public static void ShowWarning(string message)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = WarningColor;

            Console.WriteLine(message);

            Console.ForegroundColor = previousColor;
        }

        public static void ShowError(string message)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ErrorColor;

            Console.WriteLine(message);

            Console.ForegroundColor = previousColor;
        }
    }
}
