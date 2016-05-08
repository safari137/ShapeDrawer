using System;

namespace ShapeDrawer.UI
{
    public class LabelRowPrompt : IPrompt
    {
        private string _input = string.Empty;
        private int _row = 4;

        public void Display()
        {
            ConsoleTool.ShowWarning("NOTE : Label rows greater than the shape height will not be displayed.");
            Console.WriteLine("On which row should I print the label?");
            Console.Write("> ");

            _input = Console.ReadLine();
        }

        public bool IsValid()
        {
            if (_input == string.Empty)
                return true;

            if (!int.TryParse(_input, out _row))
            {
                ConsoleTool.ShowError("Please enter a valid integer.");
                return false;
            }

            if (_row < 1)
            {
                ConsoleTool.ShowError("The row must be greater than 0");
                return false;
            }

            return true;
        }

        public object GetResult()
        {
            return _row;
        }
    }
}
