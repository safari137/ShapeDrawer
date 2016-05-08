using System;
using ShapeDrawer.Drawer;

namespace ShapeDrawer.UI
{
    public class ShapePrompt : IPrompt
    {
        private string _option = string.Empty;

        public void Display()
        {
            Console.WriteLine("What would you like to draw?");
            Console.WriteLine("( 1 ) Triangle");
            Console.WriteLine("( 2 ) Square");
            Console.WriteLine("( 3 ) Diamond");
            Console.Write("> ");

            this._option = Console.ReadLine();
        }

        public bool IsValid()
        {
            var num = 0;
            if (!int.TryParse(_option, out num))
            {
                ConsoleTool.ShowError("Invalid Number");
                return false;
            }

            if (num < 1 || num > 3)
            {
                ConsoleTool.ShowError("Invalid Option");
                return false;
            }

            return true;
        }

        public object GetResult()
        {
            switch (_option)
            {
                case "1":
                    return new TriangleDrawer();
                case "2":
                    return new SquareDrawer();
                case "3":
                    return new DiamondDrawer();
                default:
                    throw new InvalidOperationException("Option not valid");
            }
        }
    }
}
