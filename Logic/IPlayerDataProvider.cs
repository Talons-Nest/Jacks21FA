public interface IPlayerDataProvider
{
    Player Player { get; } // Provide access to the Player instance so that you know, you can inherit crap around everywhere.
    PlayerData PlayerData { get; } // Optionally, provide direct access to PlayerData if needed, which is a lot. Jeesh.
}
