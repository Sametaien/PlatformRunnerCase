#region

using UnityEngine;

#endregion

namespace Player
{
    public class SpawnPoint : MonoBehaviour
    {
        private readonly Vector3 spawnPoint = new Vector3(0, 0.005f, -0.55f);
        private GameObject player;


        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player")) player.transform.position = spawnPoint;
            if (other.gameObject.CompareTag("Enemy")) other.gameObject.transform.position = spawnPoint;
        }
    }
}