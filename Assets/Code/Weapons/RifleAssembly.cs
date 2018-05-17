using UnityEngine;

namespace Assets.Code.Weapons
{
    public class RifleAssembly : MonoBehaviour
    {
        public Vector3 StockSpot;
        public Vector3 BarrelSpot;
        public Vector3 MagSpot;

        public void Assemble(GameObject barrel, GameObject stock, GameObject mag)
        {
            barrel.transform.localPosition = BarrelSpot;
            stock.transform.localPosition = StockSpot;
            mag.transform.localPosition = MagSpot;
        }
    }
}
