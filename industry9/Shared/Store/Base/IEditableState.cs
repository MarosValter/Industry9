namespace industry9.Shared.Store.Base
{
    public interface IEditableState<out TObject>
    {
        TObject EditedObject { get; }
    }
}
