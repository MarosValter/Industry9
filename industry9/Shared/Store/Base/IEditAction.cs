namespace industry9.Shared.Store.Base
{
    public interface IEditAction
    {
        bool SaveChanges { get; }
        bool Enabled { get; }
        string[] Features { get; }
    }
}
