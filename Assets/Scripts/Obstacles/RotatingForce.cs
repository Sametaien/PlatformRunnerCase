#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class RotatingForce : MonoBehaviour
    {
        private GameObject player;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerRigidbody = player.GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) playerRigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
        }
    }
}