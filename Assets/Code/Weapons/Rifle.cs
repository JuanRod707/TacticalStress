using System.Collections;
using Assets.Code.Action;
using Assets.Code.BodyParts;
using Assets.Code.Enums;
using Assets.Code.Generators.Weapons;
using UnityEngine;

namespace Assets.Code.Weapons
{
    public class Rifle : MonoBehaviour, Weapon
    {
        public RifleStats Stats;

        public Transform MuzzleSpot;
        public GameObject ShotLinePf;
        public GameObject HitParticleWall;
        public GameObject HitParticleCharacter;
        public ParticleSystem MuzzleEffect;
        public AdvancedCrosshair AdvCrosshair;

        private AudioSource fireSfx;
        private bool isCycling;
        float currentAccuracy;

        private float Inaccuracy
        {
            get { return 1 - (100f / currentAccuracy); }
        }

        void Start()
        {
            fireSfx = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!isCycling && currentAccuracy < Stats.Accuracy)
            {
                currentAccuracy += Stats.AimRecovery;
            }

            AdvCrosshair.UpdateDimension(Inaccuracy);       
        }

        public void Shoot()
        {
            if (!isCycling)
            {
                var aimPoint = GetRandomArcPoint();
                var firePosition = MuzzleSpot.position;
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
                            DisplayHit(hit.point, HitParticleCharacter);
                        }
                    }
                    else
                    {
                        DisplayHit(hit.point, HitParticleWall);
                    }


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

        public void LoadStats(RifleStats stats)
        {
            Stats = stats;
            currentAccuracy = Stats.Accuracy;
        }

        public void LoadParts(Transform body, Transform barrel, Transform stock, Transform mag)
        {
            body.GetComponent<RifleAssembly>().Assemble(barrel, stock, mag);
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
            var shotLine = Instantiate(ShotLinePf).GetComponent<LineRenderer>();
            shotLine.SetPositions(new [] { MuzzleSpot.position, hitPoint });
        }

        void DisplayHit(Vector3 hitPoint, GameObject hitParticle)
        {
            Instantiate(hitParticle, hitPoint, Quaternion.identity);
        }

        void DisplayMuzzle()
        {
            MuzzleEffect.Emit(1);
        }
    }
}
