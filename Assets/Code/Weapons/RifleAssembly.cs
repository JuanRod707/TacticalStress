using UnityEngine;

namespace Code.Weapons
{
    public class RifleAssembly : MonoBehaviour
    {
        public Vector3 StockSpot;
        public Vector3 BarrelSpot;
        public Vector3 MagSpot;

        public void Assemble(Transform barrel, Transform stock, Transform mag)
        {
            barrel.SetParent(transform);
            stock.SetParent(transform);
            mag.SetParent(transform);

            barrel.transform.localPosition = BarrelSpot;
            stock.transform.localPosition = StockSpot;
            mag.transform.localPosition = MagSpot;

            barrel.localRotation = Quaternion.identity;
            stock.localRotation = Quaternion.identity;
            mag.localRotation = Quaternion.identity;

            barrel.localScale = Vector3.one;
            stock.localScale = Vector3.one;
            mag.localScale = Vector3.one;
        }
    }
}
