using System.Collections.Generic;

namespace industry9.Client.Data.Store.Base
{
    public interface IEditAction
    {
        bool SaveChanges { get; }
        bool Enabled { get; }
        string[] Features { get; }
        IDictionary<string, object> PersistActions { get; }
    }
}
