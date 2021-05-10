namespace industry9.Client.Data.Store.Base
{
    public interface IHistoryState
    {
        bool CanUndo { get; }
    }
}
