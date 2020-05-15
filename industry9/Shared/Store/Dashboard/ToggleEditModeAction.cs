using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.Dashboard
{
    public class ToggleEditModeAction : IEditAction
    {
        public string[] Features { get; } = {"Dashboard", "AppBar"};

        public bool Enabled { get; }

        public bool SaveChanges { get; set; }

        public ToggleEditModeAction(bool enabled, bool saveChanges)
        {
            Enabled = enabled;
            SaveChanges = saveChanges;
        }
    }
}
