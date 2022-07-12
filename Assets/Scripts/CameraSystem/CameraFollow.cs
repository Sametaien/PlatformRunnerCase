#region

using UnityEngine;

#endregion

namespace CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        public Camera cam;
        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector3 offset = new Vector3(1, 0.5f, 0);


        private void LateUpdate()
        {
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}