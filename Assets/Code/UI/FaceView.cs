using UnityEngine;

namespace Code.UI
{
    public class FaceView : MonoBehaviour
    {
        void Update()
        {
            var view = Camera.main.transform;

            var rotation = transform.eulerAngles;
            rotation.z = 0f;
            rotation.y = view.rotation.eulerAngles.y;
            rotation.x = view.rotation.eulerAngles.x;

            transform.eulerAngles = rotation;
        }

    }
}
