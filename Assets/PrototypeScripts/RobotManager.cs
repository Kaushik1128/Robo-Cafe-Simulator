using UnityEngine;
using System.Collections.Generic;


public class RobotManager : MonoBehaviour
{
    public GameObject[] robotPrefabs; // List of robot prefabs
    public Transform[] spawnPoints;  // Spawn points for robots
    public Transform orderSpot;      // Where robots move to order
    private Queue<GameObject> robotQueue = new Queue<GameObject>();
    
    public void SpawnRobots()
    {
        foreach (var point in spawnPoints)
        {
            GameObject robot = Instantiate(robotPrefabs[Random.Range(0, robotPrefabs.Length)], point.position, Quaternion.identity);
            robotQueue.Enqueue(robot);
        }

        MoveNextRobot();
    }

    public void MoveNextRobot()
    {
        if (robotQueue.Count > 0)
        {
            GameObject nextRobot = robotQueue.Dequeue();
            nextRobot.GetComponent<RobotController>().MoveTo(orderSpot.position);
        }
    }
}
