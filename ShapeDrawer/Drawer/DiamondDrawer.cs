﻿using System;

namespace ShapeDrawer.Drawer
{
    public class DiamondDrawer : DrawerBase
    {
        private int _labelIndex = 0;
        private int _diamondRow = 1;

        public override void Draw()
        {
            if (!IsReadyToDraw())
                throw new InvalidOperationException("Shape is not ready to draw.  Check property values.");

            if ((LinesToDraw % 2) == 0)
                throw new InvalidOperationException("Cannot draw a diamond with even number of lines to draw");

            DrawDiamondTop();
            DrawDiamondBottom();
        }

        private void DrawDiamondTop()
        {
            var maxLength = LinesToDraw/2 + 1;

            for (var i = 0; i < maxLength; i++, _diamondRow++)
            {
                var line = AddSpaces(i);
                for (var x = 0; x <= i; x++)
                {
                    if (!IsLabelRow(_diamondRow))
                        line += "X ";
                    else
                        line += GetLabelCharacter(x, _diamondRow, _diamondRow);
                }
                Console.WriteLine(line);
            }
        }

        private void DrawDiamondBottom()
        {
            var triangleRow = 1;
            var maxLength = LinesToDraw/2 - 1;

            for (var i = maxLength; i >= 0; i--, triangleRow++, _diamondRow++)
            {
                var line = AddSpaces(i);
                var characterIndex = 0;

                for (var x = i; x >= 0; x--)
                {
                    if (!IsLabelRow(_diamondRow))
                        line += "X ";
                    else
                        line += GetLabelCharacter(characterIndex++, _diamondRow, triangleRow);
                }

                Console.WriteLine(line);
            }
        }

        private string GetLabelCharacter(int characterIndex, int diamondRow, int triangleRow)
        {
            var label = LabelDictionary[diamondRow];
            var blanks = (triangleRow > label.Length) ? triangleRow - label.Length : 0;
            var character = "X ";

            if (characterIndex == 0)
                _labelIndex = 0;

            if (characterIndex >= blanks / 2 && _labelIndex < label.Length)
                character = label[_labelIndex++] + " ";

            return character;
        }

        private string AddSpaces(int index)
        {
            var spacesToDraw = (LinesToDraw - 1) / 2 - index;
            var spaces = "";

            for (var i = 0; i < spacesToDraw; i++)
                spaces += " ";

            return spaces;
        }

        public override bool IsReadyToDraw()
        {
            return LinesToDraw % 2 != 0;
        }
    }
}
