namespace industry9.Shared.Store.Dashboard
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
