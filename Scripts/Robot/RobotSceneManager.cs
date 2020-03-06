using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotSceneManager : MonoBehaviour
{
    public abstract void playerTapped(GameObject player);
    public abstract void robotTapped(GameObject robot);
}
