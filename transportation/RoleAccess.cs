namespace transportation
{
    public static class RoleAccess
    {
        public static string CurrentRole
        {
            get { return AppSession.CurrentUser != null ? AppSession.CurrentUser.RoleName : string.Empty; }
        }

        public static bool IsAdmin()
        {
            return CurrentRole == "admin";
        }

        public static bool IsDispatcher()
        {
            return CurrentRole == "dispatcher";
        }

        public static bool IsDriver()
        {
            return CurrentRole == "driver";
        }

        public static bool IsClient()
        {
            return CurrentRole == "client";
        }

        public static bool CanManageUsers()
        {
            return IsAdmin();
        }

        public static bool CanManageEmployees()
        {
            return IsAdmin();
        }

        public static bool CanManageOperationalDirectories()
        {
            return IsAdmin() || IsDispatcher();
        }

        public static bool CanViewReports()
        {
            return IsAdmin() || IsDispatcher();
        }
    }
}
