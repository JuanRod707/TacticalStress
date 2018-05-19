using Assets.Code.Weapons;
using UnityEngine;

namespace Assets.Code.UI
{
    public class RiflePanel : MonoBehaviour
    {
        public DynamicText RifleName;
        public DynamicText Accuracy;
        public DynamicText Recoil;
        public DynamicText Damage;
        public DynamicText RateOfFire;
        public DynamicText Ammo;
        public DynamicText Range;

        public void FillRifleStats(RifleStats stats)
        {
            RifleName.SetDynamicText("Rifle", stats.Quality);
            Accuracy.SetDynamicText(stats.Accuracy.ToString("0"));
            Recoil.SetDynamicText(stats.Recoil.ToString("0.00"));
            Damage.SetDynamicText(stats.DamagePerRound.ToString("0.0"));
            RateOfFire.SetDynamicText((1f/stats.RateOfFire).ToString("0.00"));
            Ammo.SetDynamicText(stats.AmmoPerMag);
            Range.SetDynamicText(stats.Range.ToString("0.0"));
        }
    }
}
