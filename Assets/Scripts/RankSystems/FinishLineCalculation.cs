#region

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

#endregion

namespace RankSystems
{
    public class FinishLineCalculation : MonoBehaviour
    {
        public GameObject[] enemies;
        public Text finishLineText;

        [FormerlySerializedAs("PlayerPositionText")]
        public Text playerPositionText;

        private GameObject player;


        private void Update()
        {
            //display the distance to the finish line in the UI
            finishLineText.text = "Distance:" + DistanceToFinishLinePlayer().ToString("#.00") + "m";
            playerPositionText.text = "Your position: " + RankingPlayer() + " / " + 11;
        }


        private double DistanceToFinishLinePlayer()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            double distance = Vector3.Distance(player.transform.position, transform.position);
            return distance;
        }


        private double DistanceToFinishLine(GameObject enemy)
        {
            double distance = Vector3.Distance(enemy.transform.position, transform.position);
            return distance;
        }

        /* Works but not used anymore
     private GameObject WhoIsClosestToFinishLine()
    {
        var distance = DistanceToFinishLinePlayer();
        var closest = player;
        foreach (var enemy in enemies)
        {
            var enemyDistance = DistanceToFinishLine(enemy);
            if (enemyDistance < distance)
            {
                distance = enemyDistance;
                closest = enemy;
            }
        }

        return closest;
    }
    */

        private int RankingPlayer()
        {
            var ranking = 1;
            var distance = DistanceToFinishLinePlayer();
            foreach (var enemy in enemies)
            {
                var enemyDistance = DistanceToFinishLine(enemy);
                if (enemyDistance < distance) ranking++;
            }
            return ranking;
        }
    }
}