namespace NPP_InfoSystem.CCL.Security
{
    // Служба, що зберігає поточного активного користувача
    public static class SecurityContext
    {
        private static NppUser? _currentUser;

        public static void SetUser(NppUser user)
        {
            _currentUser = user;
        }

        public static NppUser? GetUser()
        {
            return _currentUser;
        }
    }
}