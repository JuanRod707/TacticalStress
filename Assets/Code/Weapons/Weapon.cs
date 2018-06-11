using System;

namespace Code.Weapons
{
    public interface Weapon
    {
        float CurrentAccuracy { get; }
        FiringMode CurrentMode { get; }
        int CurrentAmmo { get; }
        void Attack(Action<int, int> displayAmmo);
    }
}
