namespace transportation
{
    public static class AppSession
    {
        public static CurrentUser CurrentUser { get; set; }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
