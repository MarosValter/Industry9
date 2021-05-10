using industry9.Client.Data.Dto;

namespace industry9.Client.Data.Store.Features.Dashboard.Actions
{
    public class AddLabelAction
    {
        public LabelData Label { get; }

        public AddLabelAction(LabelData label)
        {
            Label = label;
        }
    }
}
