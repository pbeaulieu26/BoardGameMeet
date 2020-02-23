namespace BoardGameGeek
{
    public static class Constants
    {
        public static string AppName = "BoardGameGeek";

		// OAuth
		// For Google login, configure at https://console.developers.google.com/
		public static string iOSClientId = "6XH5yEJAag";
		public static string AndroidClientId = "6XH5yEJAag";

		// These values do not need changing
		public static string Scope = "Everything";
		public static string AuthorizeUrl = "https://www.boardgameatlas.com/oauth/authorize";
		public static string AccessTokenUrl = "https://www.boardgameatlas.com/oauth/authorize";
		public static string UserInfoUrl = "https://www.boardgameatlas.com/oauth/authorize";

		// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		public static string iOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string AndroidRedirectUrl = "BoardGameMeet.FBCorp.com:/oauth2redirect";
    }
}
