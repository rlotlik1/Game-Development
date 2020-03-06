using UnityEngine;

public class Robots : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnMouseDown()
    {
        RobotSceneManager[] managers = FindObjectsOfType<RobotSceneManager>();

        AudioManager.PlaySound("robotRock", 0.5f);

        foreach (RobotSceneManager robotSManager in managers)
        {
            if(robotSManager.gameObject.activeSelf)
            {
                robotSManager.robotTapped(this.gameObject);
            }
        }

        Destroy(gameObject);
    }

}
