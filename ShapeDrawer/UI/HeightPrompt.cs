using System;

namespace ShapeDrawer.UI
{
    public class HeightPrompt : IPrompt
    {
        private string _input = string.Empty;
        private int _height = 0;

        public void Display()
        {
            ConsoleTool.ShowWarning("NOTE: Diamonds require odd number of rows");
            Console.WriteLine("How tall should the shape be?");
            Console.Write("> ");

            this._input = Console.ReadLine();
        }

        public bool IsValid()
        {
            if (!int.TryParse(_input, out _height))
            {
                ConsoleTool.ShowError("\nInvalid Number");
                return false;
            }

            if (_height < 1)
            {
                ConsoleTool.ShowError("\nHeight must be an integer greater than 0.");
                return false;
            }

            return true;
        }

        public object GetResult()
        {
            return _height;
        }
    }
}
