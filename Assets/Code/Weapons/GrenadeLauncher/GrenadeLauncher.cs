using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Enums;
using Assets.Code.Weapons.Munitions;
using Code.Weapons.Rifle;
using UnityEngine;

namespace Code.Weapons.GrenadeLauncher
{
    public class GrenadeLauncher : MonoBehaviour, Weapon
    {
        public GameObject GrenadePrefab;

        private List<FiringMode> firingModes;
        
        ParticleSystem muzzleEffect;
        private AudioSource fireSfx;

        private bool isCycling;
        private int currentFiringMode;

        private WeaponState currentState;

        float accuracyModifier;
        private float currentAccuracy;
        private Action<int, int> displayAmmoAction = (a, b) => { };
        GrenadeLauncherStats stats;

        public FiringMode CurrentMode { get { return firingModes[currentFiringMode]; } }

        public int CurrentAmmo { get; private set; }

        public float CurrentAccuracy { get { return currentAccuracy + accuracyModifier; } }

        public void Initialize(GrenadeLauncherStats stats, Transform body, Transform barrel, Transform stock, Transform mag)
        {
            this.stats = stats;
            currentAccuracy = this.stats.Accuracy;
            body.GetComponent<RifleAssembly>().Assemble(barrel, stock, mag);
            muzzleEffect = barrel.GetComponent<BarrelAssembly>().MuzzleEffect;

            fireSfx = GetComponent<AudioSource>();

            firingModes = CreateFiringModes();
            CurrentAmmo = this.stats.AmmoPerMag;
        }

        public void Reload()
        {
            CurrentAmmo = stats.AmmoPerMag;
        }

        public void CycleFiringMode()
        {
            currentFiringMode++;
            if (currentFiringMode >= firingModes.Count)
            {
                currentFiringMode = 0;
            }

            accuracyModifier = CurrentMode.AccuracyModifier;
        }

        public WeaponStats GetWeaponStats()
        {
            return stats;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        public void Aim()
        {
            accuracyModifier = CurrentMode.AccuracyModifier + stats.AimBonus;
        }

        public void Attack(Action<int, int> displayAmmo)
        {
            if (currentState == WeaponState.Ready)
            {
                displayAmmoAction = displayAmmo;
                var firingTime = CurrentMode.RoundsToFire * stats.RateOfFire;
                currentState = WeaponState.Firing;
                StartCoroutine(TimedFire(firingTime));
            }
        }

        private List<FiringMode> CreateFiringModes()
        {
            var modes = new List<FiringMode>();

            modes.Add(new FiringMode
            {
                ModeName = "Semi",
                AccuracyModifier = 5f,
                RoundsToFire = 1,
                TimePercentageCost = 30
            });

            return modes;
        }

        IEnumerator TimedFire(float time)
        {
            yield return new WaitForSeconds(time);
            currentState = WeaponState.Ready;
            accuracyModifier = CurrentMode.AccuracyModifier;
        }

        void Shoot()
        {
            if (!isCycling && CurrentAmmo > 0)
            {
                var grenade = Instantiate(GrenadePrefab, muzzleEffect.transform.position, transform.rotation).GetComponent<Grenade>();
                grenade.Launch(200f);

                CurrentAmmo--;
                displayAmmoAction(CurrentAmmo, stats.AmmoPerMag);
                fireSfx.Play();
                DisplayMuzzle();
                StartCoroutine(CycleBullet());
            }
        }

        void Update()
        {
            if (!isCycling && currentAccuracy < stats.Accuracy)
            {
                currentAccuracy += stats.AimRecovery;
            }

            if (currentState == WeaponState.Firing)
            {
                Shoot();
            }
        }

        IEnumerator CycleBullet()
        {
            isCycling = true;
            yield return new WaitForSeconds(stats.RateOfFire);
            isCycling = false;
        }

        void DisplayMuzzle()
        {
            muzzleEffect.Emit(1);
        }

        void ResetAccuracyModifier()
        {
            accuracyModifier = 0f;
        }
    }
}
