#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class RotatorScript : MonoBehaviour
    {
        public float rotatorSpeed = 0.5f;

        private void Update()
        {
            transform.Rotate(0, rotatorSpeed * Time.deltaTime, 0);
        }
    }
}