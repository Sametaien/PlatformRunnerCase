#region

using UnityEngine;
using UnityEngine.AI;

#endregion

namespace AiSystem
{
    public class EnemyAi : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animatorEnemy;
        private Vector3 finishLine;

        private void Awake()
        {
            finishLine = GameObject.Find("FinishLine").transform.position;
            agent = GetComponent<NavMeshAgent>();
            animatorEnemy = GetComponent<Animator>();
            animatorEnemy.Play("Run");
        }

        private void Update()
        {
            agent.CalculatePath(finishLine, new NavMeshPath());
            agent.SetDestination(finishLine);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("FinishLine")) gameObject.SetActive(false);
        }
    }
}