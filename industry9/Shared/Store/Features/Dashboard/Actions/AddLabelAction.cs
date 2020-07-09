namespace industry9.Shared.Store.Features.Dashboard.Actions
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
