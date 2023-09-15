namespace Data_Package_Tool.Helpers
{
    public class Consts
    {
        public static readonly string DuplicateDMWarning = "You have multiple dm channels with this recipient. There is no guarantee that Discord will open the right one.";
        public static readonly string InvalidTokenError = "Entered token is invalid or doesn't belong to the same account!";
        public static readonly string MissingTokenError = "You must enter your account token in the Settings tab to use this function.";
        public static readonly string MissingBotTokenError = "You must enter a bot token in the Settings tab to use this function.";
    }
}
