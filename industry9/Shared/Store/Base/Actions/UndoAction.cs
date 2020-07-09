namespace industry9.Shared.Store.Base.Actions
{
    public class UndoAction
    {
        public string[] Features { get; }

        public UndoAction(params string[] feature)
        {
            Features = feature;
        }
    }
}
