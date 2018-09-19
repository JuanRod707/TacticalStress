using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Enums;
using Code.Actors;
using Code.BodyParts;
using Code.Enums;
using Code.Generators.Weapons;
using Code.Infrastructure.Repositories;
using Code.Interfaces;
using Code.Weapons.Rifle;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Weapons.Shotgun
{
    public class Shotgun : MonoBehaviour, Weapon
    {
        public FiringMode CurrentMode
        {
            get { return firingModes[currentFiringMode]; }
        }

        public int CurrentAmmo { get; private set; }
        public WeaponType WeaponType { get { return WeaponType.Shotgun; } }

        public ParticleSystem muzzleEffect;
        
        private List<FiringMode> firingModes;
        GameObject shotLine;
        GameObject hitParticle;
        GameObject bulletHole;
        //ParticleSystem muzzleEffect;
        private ShotgunStats stats;
        private AudioSource fireSfx;
        private bool isCycling;
        private int currentFiringMode;
        private WeaponState currentState;
        float accuracyModifier;
        private float currentAccuracy;
        private Action<int, int> displayAmmoAction = (a, b) => { };

        public float CurrentAccuracy
        {
            get { return currentAccuracy + accuracyModifier; }
        }

        public WeaponStats GetWeaponStats()
        {
            return stats;
        }

        public void Initialize(ShotgunStats stats)
        {
            if (Repos.ParticleRepo != null)
            {
                shotLine = Repos.ParticleRepo.ShotLine;
                hitParticle = Repos.ParticleRepo.ShotHit;
                bulletHole = Repos.ParticleRepo.BulletHole;
            }

            this.stats = stats;
            currentAccuracy = this.stats.Accuracy;
            //body.GetComponent<RifleAssembly>().Assemble(barrel, stock, mag);
            //muzzleEffect = barrel.GetComponent<BarrelAssembly>().MuzzleEffect;

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
                foreach (var _ in Enumerable.Range(0, stats.PelletCount))
                {
                    var aimPoint = GetRandomArcPoint();
                    var firePosition = muzzleEffect.transform.position;
                    var ray = new Ray(firePosition, aimPoint - firePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, stats.Range))
                    {
                        if (hit.rigidbody != null)
                        {
                            var damageable = hit.rigidbody.GetComponent<Damageable>();
                            if (damageable != null)
                            {
                                damageable.ReceiveDamage(stats.DamagePerRound);
                            }

                            var pushable = hit.rigidbody.GetComponent<Pushable>();
                            if (pushable != null)
                            {
                                pushable.Push(hit.point, stats.PushForce);
                            }
                        }
                        else
                        {
                            DisplayHit(hit.point, bulletHole);
                        }

                        DisplayHit(hit.point, hitParticle);
                        DisplayShot(hit.point);
                    }
                    else
                    {
                        DisplayShot(aimPoint);
                    }
                }

                if (currentAccuracy > 1 && currentAccuracy > stats.MinAccuracy)
                {
                    currentAccuracy -= stats.Recoil;
                }

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

        Vector3 GetRandomArcPoint()
        {
            var randomPoint = Random.insideUnitSphere * GetComponentInParent<Actor>().Inaccuracy;
            var cam = Camera.main.transform;
            var result = (cam.forward * stats.Range) + randomPoint;

            var ray = new Ray(cam.position, result);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, stats.Range))
            {
                result = hit.point;
            }

            return result;
        }

        void DisplayShot(Vector3 hitPoint)
        {
            var shotLine = Instantiate(this.shotLine).GetComponent<LineRenderer>();
            shotLine.SetPositions(new [] { muzzleEffect.transform.position, hitPoint });
        }

        void DisplayHit(Vector3 hitPoint, GameObject hitParticle)
        {
            Instantiate(hitParticle, hitPoint, Quaternion.identity);
        }

        void DisplayMuzzle()
        {
            muzzleEffect.Emit(1);
        }

        void ResetAccuracyModifier()
        {
            accuracyModifier = 0f;
        }

        public void Randomize()
        {
            Initialize(WeaponGenerator.GenerateNewShotgun(ItemQuality.Common));
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}
