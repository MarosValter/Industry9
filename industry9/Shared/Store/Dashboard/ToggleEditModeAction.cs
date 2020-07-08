using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.Dashboard
{
    public class ToggleEditModeAction : IEditAction
    {
        public bool SaveChanges { get; }

        public bool Enabled { get; }

        public string[] Features { get; } = {"Dashboard"};

        public ToggleEditModeAction(bool enabled, bool saveChanges)
        {
            Enabled = enabled;
            SaveChanges = saveChanges;
        }
    }
}
