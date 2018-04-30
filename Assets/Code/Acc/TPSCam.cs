using UnityEngine;

public class TPSCam : MonoBehaviour
{
    public Transform TargetView;
    public Transform TargetPos;

    public float LookSpeed;
    public float Elasticity;

    void FixedUpdate()
    {
        if (TargetPos != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, TargetPos.position, Elasticity);
        }

        if (TargetView != null)
        {
            this.transform.LookAt(TargetView);
        }

        var eul = this.transform.eulerAngles;
        eul.z = 0f;
        this.transform.eulerAngles = eul;
    }
}
