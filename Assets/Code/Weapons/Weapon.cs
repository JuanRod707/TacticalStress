using System;

namespace Code.Weapons
{
    public interface Weapon
    {
        float CurrentAccuracy { get; }
        void Attack(Action<int, int> displayAmmo);
    }
}
