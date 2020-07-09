namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class RemoveLabelAction
    {
        public string LabelName { get; }

        public RemoveLabelAction(string labelName)
        {
            LabelName = labelName;
        }
    }
}
