using System;
using Code.Enums;

namespace Code.Weapons
{
    public interface Weapon
    {
        float CurrentAccuracy { get; }
        FiringMode CurrentMode { get; }
        int CurrentAmmo { get; }
        WeaponType WeaponType { get; }

        void Attack(Action<int, int> displayAmmo);
        void Reload();
        void Aim();
        void CycleFiringMode();
        WeaponStats GetWeaponStats();

        void Randomize();
        void Enable();
        void Disable();
    }
}
