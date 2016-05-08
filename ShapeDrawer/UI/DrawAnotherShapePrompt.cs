using System;

namespace ShapeDrawer.UI
{
    public class DrawAnotherShapePrompt : IPrompt
    {
        private ConsoleKeyInfo _keyPressed;

        public void Display()
        {
            Console.WriteLine("Would you like to draw another shape? Y/N");
            Console.Write("> ");

            _keyPressed = Console.ReadKey();
        }

        public bool IsValid()
        {
            if (_keyPressed.Key != ConsoleKey.N && _keyPressed.Key != ConsoleKey.Y)
            {
                ConsoleTool.ShowError("Invalid Entry.");
                return false;
            }

            return true;
        }

        public object GetResult()
        {
            return _keyPressed.Key == ConsoleKey.Y;
        }
    }
}
