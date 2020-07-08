namespace industry9.Shared.Store.Dashboard
{
    public class AddLabelAction
    {
        public ILabel Label { get; }

        public AddLabelAction(ILabel label)
        {
            Label = label;
        }
    }
}
