#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class MovingStick : MonoBehaviour
    {
        private const float StickPosXOpened = -0.2f;
        public GameObject stick;
        [SerializeField] private bool stickIsOpened;
        [SerializeField] private float stickPosXClosed = 0.245f;
        private readonly bool stickIsClosed = true;

        private void Update()
        {
            var stickPosition = stick.transform.position;
            if (stickIsClosed)
                stick.transform.position =
                    new Vector3(StickPosXOpened, stickPosition.y, stickPosition.z);

            else
                stick.transform.position =
                    new Vector3(stickPosXClosed, stickPosition.y, stickPosition.z);
        }
    }
}