using System.ComponentModel;

namespace transportation
{
    public static class DesignModeHelper
    {
        public static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
    }
}
