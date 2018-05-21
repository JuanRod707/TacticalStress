using System.Collections;
using Code.BodyParts;
using Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Weapons
{
    public class Rifle : MonoBehaviour, Weapon
    {
        public RifleStats Stats;
        
        GameObject shotLine;
        GameObject hitParticle;
        GameObject bulletHole;
        ParticleSystem muzzleEffect;
        private AudioSource fireSfx;
        private bool isCycling;
        float currentAccuracy;

        public float Inaccuracy
        {
            get { return 1 - (100f / currentAccuracy); }
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
        }

        public void Shoot()
        {
            if (!isCycling)
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
        }

        IEnumerator CycleBullet()
        {
            isCycling = true;
            yield return new WaitForSeconds(Stats.RateOfFire);
            isCycling = false;
        }

        Vector3 GetRandomArcPoint()
        {
            var randomPoint = Random.insideUnitSphere * Inaccuracy;
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
    }
}
