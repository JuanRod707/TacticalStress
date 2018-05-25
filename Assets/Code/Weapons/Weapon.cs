using System;

namespace Code.Weapons
{
    public interface Weapon
    {
        float Inaccuracy { get; }
        void Attack(Action<int, int> displayAmmo);
    }
}
