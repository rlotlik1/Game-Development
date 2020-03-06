using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RobotFactory : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private Robots[] availableRobots;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingRobots = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Robots> liveRobots = new List<Robots>();
    private Robots selectedRobot;

    public List<Robots> GetLiveRobots { get { return liveRobots; } }

    public Robots GetSelectedRobot { get { return selectedRobot; } }

    private void Awake()
    {
        Assert.IsNotNull(availableRobots);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startingRobots; i++)
        {
            InstantiateRobot();
        }

        StartCoroutine(GenerateRobots());
    }

    public void RobotWasSelected(Robots robot)
    {
        selectedRobot = robot;
    }

    private IEnumerator GenerateRobots()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(waitTime, waitTime + 1));
            InstantiateRobot();
        }
    }

    private void InstantiateRobot()
    {
        int index = Random.Range(0, availableRobots.Length);
        float x = spawnPoint.transform.position.x + GenerateRange();
        float y = spawnPoint.transform.position.y;
        float z = spawnPoint.transform.position.z + GenerateRange();
        liveRobots.Add(Instantiate(availableRobots[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }

    

}
