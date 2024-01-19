namespace BarberTech.Infraestructure.Authentication
{
    public static class Permissions
    {
        public static class Feedbacks
        {
            public const string View = "feedbacks:view";

            public const string Edit = "feedbacks:edit";
        }

        public static class Haircuts
        {
            public const string View = "haircuts:view";

            public const string Edit = "haircuts:edit";
        }

        public static class Establishments
        {
            public const string View = "establishments:view";

            public const string Edit = "establishments:edit";
        }

        public static class Users
        {
            public const string View = "users:view";

            public const string Edit = "users:edit";
        }
    }
}
