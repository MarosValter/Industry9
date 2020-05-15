namespace industry9.Shared.Store.Dashboard
{
    public class AddLabelAction
    {
        public ILabelData Label { get; }

        public AddLabelAction(ILabelData label)
        {
            Label = label;
        }
    }
}
