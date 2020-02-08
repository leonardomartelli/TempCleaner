using System.ComponentModel;

namespace TempCleanner
{
    public enum eState
    {
        [Description("Dirty")]
        Dirty,
        
        [Description("Clean")]
        Clean
    }
}
