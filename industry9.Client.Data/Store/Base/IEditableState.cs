namespace industry9.Client.Data.Store.Base
{
    public interface IEditableState<out TObject>
    {
        TObject EditedObject { get; }
    }
}
