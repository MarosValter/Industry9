namespace industry9.Shared.Store.Base
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
