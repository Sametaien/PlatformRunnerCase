#region

using UnityEngine;
using UnityEngine.Serialization;

#endregion

namespace Obstacles
{
    public class HorizontalObstacle : MonoBehaviour
    {
        public Vector3 spawnPoint = new Vector3(0, 0.005f, -.55f);
        public float distance = 1f; 
        public bool isHorizontal = true;
        public float speed = 1f;
        public float offset; 
        public bool isMoving = true;
        [FormerlySerializedAs("Player")] public GameObject player;
        private Vector3 startPosition;

        private void Awake()
        {
            startPosition = transform.position;
            if (isHorizontal)
                transform.position += Vector3.right * offset;
            else
                transform.position += Vector3.forward * offset;
        }

        private void Update()
        {
            if (!isHorizontal) return;
            if (isMoving)
            {
                if (transform.position.x < startPosition.x + distance)
                    transform.position += Vector3.right * (speed * Time.deltaTime);
                else
                    isMoving = false;
            }
            else
            {
                if (transform.position.x > startPosition.x)
                    transform.position += Vector3.left * (speed * Time.deltaTime);
                else
                    isMoving = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player")) player.transform.position = spawnPoint;
            if (other.gameObject.CompareTag("Enemy")) other.gameObject.transform.position = spawnPoint;
        }
    }
}