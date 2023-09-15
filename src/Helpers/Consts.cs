namespace Data_Package_Tool.Helpers
{
    public class Consts
    {
        public static readonly string DuplicateDMWarning = "You have multiple dm channels with this user! This is likely due to a bug which allowed opening multiple dms when messaging someone for the first time.\n\nSince Discord only saves a single dm channel as the default dm, there is no guarantee that it will open the right one.";
        public static readonly string InvalidTokenError = "Entered token is invalid or doesn't belong to the same account!";
        public static readonly string MissingTokenError = "You must enter your account token in the Settings tab to use this function.";
        public static readonly string MissingBotTokenError = "You must enter a bot token in the Settings tab to use this function.";
        public static readonly string InvalidBotTokenError = "Entered token is invalid!";
        public static readonly string WrongTokenType = "Entered bot token belongs to your own account!";
    }
}
