#region

using System.Collections;
using AiSystem;
using CameraSystem;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

#endregion

namespace RankSystems
{
    public class FinishScript : MonoBehaviour
    {
        [FormerlySerializedAs("TeleportPoint")] public GameObject teleportPoint;
        [FormerlySerializedAs("PaintWall")] public GameObject paintWall;
        public GameObject PlayerTriangle;
        
        [SerializeField] private bool isFinished;
        private CameraFollow cameraFollow;
        private GameObject[] enemies;
        private FinishLineCalculation finishLineCalculation;
        private GameObject player;
        private Animator playerAnimator;
        


        private void Awake()
        {
            finishLineCalculation = GetComponent<FinishLineCalculation>();
            paintWall.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
            PlayerTriangle.SetActive(true);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isFinished = true;
                Debug.Log("Player won");
                paintWall.SetActive(true);
                finishLineCalculation.playerPositionText.enabled = false;
                finishLineCalculation.finishLineText.enabled = false;
                player.transform.position = teleportPoint.transform.position;
                cameraFollow.offset = new Vector3(0, 0.3f, -1.25f);
                player.GetComponent<SwerveInput>().enabled = false;
                player.GetComponent<SwerveMovement>().enabled = false;
                PlayerTriangle.SetActive(false);
                if (isFinished)
                {
                    //change animation to Idle
                    playerAnimator = player.GetComponent<Animator>();
                    playerAnimator.Play("Idle");
                    StartCoroutine(DanceTimer());
                }

                foreach (var enemy in enemies) enemy.GetComponent<EnemyAi>().enabled = false;
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyAi>().enabled = false;
            }
        }

        private IEnumerator DanceTimer()
        {
            yield return new WaitForSeconds(3);
            playerAnimator.Play("Dance");
            var rotation = player.transform.rotation;
            rotation = Quaternion.Euler(rotation.x, -160, rotation.z);
            player.transform.rotation = rotation;
        }
    }
}