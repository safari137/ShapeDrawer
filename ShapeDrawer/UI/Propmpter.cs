using System;
using ShapeDrawer.Drawer;

namespace ShapeDrawer.UI
{
    public class Propmpter
    {
        public Propmpter()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Start()
        {
            var isPrompting = true;
            while (isPrompting)
            {
                var shape = (Drawer.DrawerBase)Prompt(new ShapePrompt());

                shape.LinesToDraw = (int) Prompt(new HeightPrompt());

                StartLabelPrompt(ref shape);

                TryDrawShape(shape);

                isPrompting = (bool) Prompt(new DrawAnotherShapePrompt());
            }

            Console.WriteLine("\n\nGood Bye!");
        }

        private static void StartLabelPrompt(ref DrawerBase shape)
        {
            var isAddingLabels = true;

            while (isAddingLabels)
            {
                var label = (string) Prompt(new LabelPrompt());
                var labelRow = (int) Prompt(new LabelRowPrompt());

                shape.AddLabel(labelRow, label);

                isAddingLabels = (bool) Prompt(new AddAnotherLabel());
            }
            Console.WriteLine();
        }

        private static bool TryDrawShape(Drawer.DrawerBase shape)
        {
            if (shape.IsReadyToDraw())
            {
                shape.Draw();
                return true;
            }

            ConsoleTool.ShowError(
               "Shape cannot be drawn.  Ensure that the height of the shape is greater than or equal to the row you print the label on.  Diamonds must have an odd number of rows");

            return false;
        }

        private static object Prompt(IPrompt prompter)
        {
            do
            {
                Console.WriteLine();
                prompter.Display();
            } while (!prompter.IsValid());

            return prompter.GetResult();
        }
    }
}
