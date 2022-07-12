#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class RotatingObstacles : MonoBehaviour
    {
        public bool isRotating = true;
        public bool isRotatingRight;
        public bool isRotatingLeft;
        public float speed = .3f;
        public GameObject player;
        public bool isPlayerOnObstacle;
        public float rotatingSpeed;
        private Rigidbody playerRigidBody;
        private Rigidbody rotatingObstacleRigidBody;


        private void Start()
        {
            rotatingObstacleRigidBody = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerRigidBody = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!isRotating) return;
            if (isRotatingRight)
                transform.Rotate(0, 0, 1f * speed * Time.deltaTime);
            else if (isRotatingLeft) transform.Rotate(0, 0, 1f * -speed * Time.deltaTime);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && isRotatingRight)
            {
                var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
                isPlayerOnObstacle = true;
                var velocity = rigidBody.velocity;
                velocity.x = (Vector3.left * rotatingSpeed).x;
                rigidBody.velocity = velocity;
            }
            else if (collision.gameObject.CompareTag("Player") && isRotatingLeft)
            {
                var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
                isPlayerOnObstacle = true;
                var velocity = rigidBody.velocity;
                velocity.x = (Vector3.right * rotatingSpeed).x;
                rigidBody.velocity = velocity;
            }
        }

        //TODO: Check and delete these two methods
        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Player")) isPlayerOnObstacle = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (CompareTag("Player")) isPlayerOnObstacle = false;
        }
    }
}