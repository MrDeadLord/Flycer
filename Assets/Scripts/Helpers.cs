namespace Flycer.Helpers
{
    /// <summary>
    /// Matter/material of an object
    /// </summary>
    public enum Matter
    {
        Steel,
        Wood,
        Flesh,
        Dirt,
        Stone
    }

    /// <summary>
    /// Special abilitys
    /// </summary>
    public enum Ability
    {
        TimeSlow,
        Shield
    }

    /// <summary>
    /// Слои
    /// </summary>
    public enum Layer
    {
        IgnoreRayCast = 2,
        Player = 8,
        Enemy = 9,
        Envoirment = 10,
        GameController = 11,
        EnemyShells = 12,
        PlayerShells = 13
    }

    /// <summary>
    /// Все возможные кнопки в игре
    /// </summary>
    public enum Controls
    {
        Horizontal,
        Vertical,
        ChangePosition,
        Fire1,
        Fire2,
        Fire3,
        MouseX,
        MouseY,
        Pause
    }
}