public static class Global
{
    #region Tags
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const string PlayerDiscTag = "PlayerDisc";
    public const string DiscRetrieverTag = "DiscRetriever";
    public const string GoalTag = "Finish";
    public const string CameraMinimapTag = "MinimapCamera";
    #endregion

    #region Axis
    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";
    public const string MouseVerticalAxis = "Mouse X";
    public const string MouseHorizontalAxis = "Mouse Y";
    public const string JumpAxis = "Jump";
    public const string StartAxis = "Submit";
    public const string QuitAxis = "Cancel";
    public const string FireAxis = "Fire1";
    #endregion

    #region Scene Names
    public const string MainMenuScene = "Main Menu";
    public const string FirstLevelScene = "Game";
    #endregion

    #region Animations

    #endregion

    #region Constants

    public const double Tolerance = float.Epsilon;

    #endregion

    #region Functions

    public static string ReturnTimeToString(float time)
    {
        var minutes = UnityEngine.Mathf.FloorToInt(time / 60f);
        var seconds = UnityEngine.Mathf.RoundToInt(time % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        if (seconds <= 0)
            seconds = 0;
        if (minutes <= 0)
            minutes = 0;

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    #endregion

    public enum Language
    {
        English, Spanish, Portuguese, Italian, French, German, Catalan
    }

    public enum AdsCompany
    {
        Admob, UnityAds, AudienceNetwork
    }
}
