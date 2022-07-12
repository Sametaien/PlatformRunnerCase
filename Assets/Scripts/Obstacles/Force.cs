#region

using UnityEngine;

#endregion

namespace Obstacles
{
    public class Force : MonoBehaviour
    {
        private readonly float force = 2.5f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            if (collision.gameObject.CompareTag("Enemy"))
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}