using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScenceManager : RobotSceneManager
{
    public override void playerTapped(GameObject player)
    {

    }

    public override void robotTapped(GameObject robot)
    {
        List<GameObject> list = new List<GameObject>();

        if(Random.Range(0, 10) < 8)
        {
            SceneTransitionManager.Instance.GoToScene(RobotConstants.SCENE_BATTLE, list);
        }
        else
        {
            SceneTransitionManager.Instance.GoToScene(RobotConstants.SCENE_BOSS_BATTLE, list);
        }

        
    }

    public void ToMainGameScene()
    {
        SceneManager.LoadScene("OpenWorld");
    }

    public void LoadThatScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
