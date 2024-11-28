using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RobotManager robotManager; // Reference to the RobotManager
    public int score = 0;
    public int day = 1;
    public bool isDayActive = false;

    public void StartDay()
    {
        if (!isDayActive)
        {
            isDayActive = true;
            robotManager.SpawnRobots(); // Start spawning robots
            Debug.Log($"Day {day} started!");
        }
    }

    public void EndDay()
    {
        isDayActive = false;
        day++;
        Debug.Log($"Day {day} complete! Total Score: {score}");
    }
}
