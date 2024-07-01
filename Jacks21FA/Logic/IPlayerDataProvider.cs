public interface IPlayerDataProvider
{
    Player Player { get; } // Provide access to the Player instance
    PlayerData PlayerData { get; } // Optionally, provide direct access to PlayerData if needed
}
