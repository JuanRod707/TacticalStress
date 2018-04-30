using UnityEngine;

public class TPSController : MonoBehaviour
{
    public float Speed;
    public float Sensitivity;
    public float VertSensitivity;
    public Rifle Weapon;
    public float MaxElevation;
    public float MinElevation;
    public Transform AimPoint;

    private Vector3 previousMousePos;

    void Update()
    {
        Look();
        Move();
        Attack();
    }

    void Look()
    {
        var mouse = Input.mousePosition;
        var mouseDelta = mouse - previousMousePos;

        transform.Rotate(Vector3.up * mouseDelta.x * Sensitivity);
        AimPoint.Translate(new Vector3(0f, mouseDelta.y * VertSensitivity, 0f));

        var elevation = AimPoint.localPosition;
        if (elevation.y < MinElevation)
        {
            elevation.y = MinElevation;
            AimPoint.localPosition = elevation;
        }
        else if (elevation.y > MaxElevation)
        {
            elevation.y = MaxElevation;
            AimPoint.localPosition = elevation;
        }

        previousMousePos = mouse;
    }

    void Move()
    {
        var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(moveVector * Speed);
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            Weapon.Shoot();
        }
    }
}
