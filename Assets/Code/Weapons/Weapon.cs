using System;

namespace Code.Weapons
{
    public interface Weapon
    {
        float CurrentAccuracy { get; }
        FiringMode CurrentMode { get; }
        int CurrentAmmo { get; }
     
        void Attack(Action<int, int> displayAmmo);
        void Reload();
        void Aim();
        void CycleFiringMode();
        WeaponStats GetWeaponStats();

        void Enable();
        void Disable();
    }
}
