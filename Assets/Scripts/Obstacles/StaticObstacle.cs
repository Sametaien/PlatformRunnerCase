#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class StaticObstacle : MonoBehaviour
    {
        public Vector3 startPos = new Vector3(0, 0.005f, -0.55f);
        public GameObject player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player.transform.position = startPos;
                Debug.Log("Player hit obstacles");
            }
            if (other.CompareTag("Enemy"))
            {
                other.transform.position = startPos;
                Debug.Log("Enemy hit obstacles");
            }
        }
        
    }
}