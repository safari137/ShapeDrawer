namespace ShapeDrawer.UI
{
    interface IPrompt
    {
        void Display();
        bool IsValid();
        object GetResult();
    }
}
