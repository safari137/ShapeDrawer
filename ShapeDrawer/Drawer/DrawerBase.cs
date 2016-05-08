using System.Collections.Generic;

namespace ShapeDrawer.Drawer
{
    public abstract class DrawerBase
    {
        public int LinesToDraw { get; set; }

        protected readonly Dictionary<int, string> LabelDictionary = new Dictionary<int, string>(); 


        public virtual bool IsReadyToDraw()
        {
            return true;
        }

        public bool AddLabel(int row, string label)
        {
            if (row < 1 || row > this.LinesToDraw)
                return false;

            if (LabelDictionary.ContainsKey(row))
                return false;

            LabelDictionary.Add(row, label);
            return true;
        }

        protected bool IsLabelRow(int row)
        {
            return LabelDictionary.ContainsKey(row);
        }

        public abstract void Draw();
    }
}
