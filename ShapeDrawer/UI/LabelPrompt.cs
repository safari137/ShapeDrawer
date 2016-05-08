using System;

namespace ShapeDrawer.UI
{
    public class LabelPrompt : IPrompt
    {
        private string _input = "LU";

        public void Display()
        {
            ConsoleTool.ShowWarning("NOTE : If label characters exceed the characters on designted row, the label will be truncated.");
            Console.WriteLine("What label would you like to use? (Leave blank for \"LU\")");
            Console.Write("> ");

            var str = Console.ReadLine();

            _input = (str == string.Empty) ? _input : str;
        }

        public bool IsValid()
        {
            return true;
        }

        public object GetResult()
        {
            return _input;
        }
    }
}
