namespace industry9.Client.Data.Store.Base.Actions
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
