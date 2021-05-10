using System.Collections.Generic;
using industry9.Client.Data.Store.Base;

namespace industry9.Client.Data.Store.Features.Dashboard.Actions
{
    public class ToggleEditModeAction : IEditAction
    {
        public bool SaveChanges { get; }

        public bool Enabled { get; }

        public string[] Features { get; } = {"Dashboard"};

        public IDictionary<string, object> PersistActions { get; }

        public ToggleEditModeAction(bool enabled, bool saveChanges = false)
        {
            Enabled = enabled;
            SaveChanges = saveChanges;
            PersistActions = new Dictionary<string, object>();
        }

        public ToggleEditModeAction(object persistAction) : this(false, true)
        {
            PersistActions["Dashboard"] = persistAction;
        }
    }
}
