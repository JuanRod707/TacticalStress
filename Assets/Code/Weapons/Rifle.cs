using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Enums;
using Code.Actors;
using Code.BodyParts;
using Code.Infrastructure.Repositories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Weapons
{
    public class Rifle : MonoBehaviour, Weapon
    {
        public RifleStats Stats;

        public FiringMode CurrentMode
        {
            get { return firingModes[currentFiringMode]; }
        }
        public int CurrentAmmo { get; private set; }

        private List<FiringMode> firingModes;
        GameObject shotLine;
        GameObject hitParticle;
        GameObject bulletHole;
        ParticleSystem muzzleEffect;
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

        public void Initialize(RifleStats stats, Transform body, Transform barrel, Transform stock, Transform mag)
        {
            if (Repos.ParticleRepo != null)
            {
                shotLine = Repos.ParticleRepo.ShotLine;
                hitParticle = Repos.ParticleRepo.ShotHit;
                bulletHole = Repos.ParticleRepo.BulletHole;
            }

            Stats = stats;
            currentAccuracy = Stats.Accuracy;
            body.GetComponent<RifleAssembly>().Assemble(barrel, stock, mag);
            muzzleEffect = barrel.GetComponent<BarrelAssembly>().MuzzleEffect;

            fireSfx = GetComponent<AudioSource>();

            firingModes = CreateFiringModes();
            CurrentAmmo = Stats.AmmoPerMag;
        }

        public void Reload()
        {
            CurrentAmmo = Stats.AmmoPerMag;
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
            accuracyModifier = CurrentMode.AccuracyModifier + Stats.AimBonus;
        }

        public void Attack(Action<int, int> displayAmmo)
        {
            if (currentState == WeaponState.Ready)
            {
                displayAmmoAction = displayAmmo;
                var firingTime = CurrentMode.RoundsToFire * Stats.RateOfFire;
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

            modes.Add(new FiringMode
            {
                ModeName = "3-round burst",
                AccuracyModifier = -15f,
                RoundsToFire = 3,
                TimePercentageCost = 40
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
                var aimPoint = GetRandomArcPoint();
                var firePosition = muzzleEffect.transform.position;
                var ray = new Ray(firePosition, aimPoint - firePosition);
                RaycastHit hit;
            
                if (Physics.Raycast(ray, out hit, Stats.Range))
                {
                    if (hit.rigidbody != null)
                    {
                        var bodyPart = hit.rigidbody.GetComponent<BodyPart>();
                        if (bodyPart != null)
                        {
                            bodyPart.ReceiveDamage(Stats.DamagePerRound);
                        }

                        var pushable = hit.rigidbody.GetComponent<Pushable>();
                        if (pushable != null)
                        {
                            pushable.Push(hit.point, Stats.PushForce);
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
            
                if (currentAccuracy > 1 && currentAccuracy > Stats.MinAccuracy)
                {
                    currentAccuracy -= Stats.Recoil;
                }

                CurrentAmmo--;
                displayAmmoAction(CurrentAmmo, Stats.AmmoPerMag);
                fireSfx.Play();
                DisplayMuzzle();
                StartCoroutine(CycleBullet());
            }
        }

        void Update()
        {
            if (!isCycling && currentAccuracy < Stats.Accuracy)
            {
                currentAccuracy += Stats.AimRecovery;
            }

            if (currentState == WeaponState.Firing)
            {
                Shoot();
            }
        }

        IEnumerator CycleBullet()
        {
            isCycling = true;
            yield return new WaitForSeconds(Stats.RateOfFire);
            isCycling = false;
        }

        Vector3 GetRandomArcPoint()
        {
            var randomPoint = Random.insideUnitSphere * GetComponentInParent<Actor>().Inaccuracy;
            var cam = Camera.main.transform;
            var result = (cam.forward * Stats.Range) + randomPoint;

            var ray = new Ray(cam.position, result);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Stats.Range))
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
    }
}
