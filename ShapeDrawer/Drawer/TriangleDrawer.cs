using System;
using System.Collections.Generic;

namespace ShapeDrawer.Drawer
{
    public class TriangleDrawer : DrawerBase
    {
        private int _labelIndex = 0;

        public override void Draw()
        {
            if (!IsReadyToDraw())
                throw new InvalidOperationException("Shape is not ready to draw.  Check property values.");

            for (var i = 0; i < LinesToDraw; i++)
            {
                var line = AddSpaces(i);
                for (var x = 0; x <= i; x++)
                {
                    var row = i + 1;

                    if (!IsLabelRow(row))
                        line += "X ";
                    else
                        line += GetLabelCharacter(x, row);
                    
                }
                Console.WriteLine(line);
            }
        }

        private string GetLabelCharacter(int characterIndex, int row)
        {
            var label = LabelDictionary[row];
            var blanks = (row > label.Length) ? row - label.Length : 0;
            var character = "X ";

            if (characterIndex == 0)
                _labelIndex = 0;

            if (characterIndex >= blanks / 2 && _labelIndex < label.Length)
                character = label[_labelIndex++] + " ";

            return character;
        }

        private string AddSpaces(int index)
        {
            var spacesToDraw = (LinesToDraw - 1) - index;
            var spaces = "";

            for (var i = 0; i < spacesToDraw; i++)
                spaces += " ";

            return spaces;
        }
    }
}
