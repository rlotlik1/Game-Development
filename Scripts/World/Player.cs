using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    public UserList user = new UserList();

    private string path;
    private int requiredXp = 2000;
    private int levelBase = 1000;
    private string username = "sample";
    private float xp = 500;
    private int level = 2;
    private int coin = 1200;
    private int ammo = 15;

    //Get function
    public float GetXp { get { return xp; } }

    public int GetLvl { get { return level; } }

    public int GetCoin { get { return coin; } }

    public int GetAmmo { get { return ammo; } }

    public int GetRequiredXp { get { return requiredXp; } }

    public int GetLevelBase { get { return levelBase; } }

    public string GetUsername { get { return username; } }

    //Send an update request to user DB
    public void UpdateDB(int xpAdd, int levelAdd, int coinAdd, int ammoAdd)
    {
        WWWForm userF = new WWWForm();
        userF.AddField("username", username);
        userF.AddField("xp", xpAdd);
        userF.AddField("level", levelAdd);
        userF.AddField("coin", coinAdd);
        userF.AddField("ammo", ammoAdd);

        path = "http://thecodekite.com/game/update.php";
        UnityWebRequest webRequest = UnityWebRequest.Post(path, userF);

        StartCoroutine(GetRequest(webRequest));
    }

    //Initialize user info using user DB data
    public void InitLevelData(string usernameDB, int xpDB, int levelDB, int coinDB, int ammoDB)
    {
        username = usernameDB;
        xp = xpDB;
        level = levelDB;
        coin = coinDB;
        ammo = ammoDB;
        requiredXp = levelBase * level;
    }

    //Add input variables to user database
    public void AddVar(int exp, int coins, int ammos)
    {
        this.xp += Mathf.Max(0, exp);
        coin += coins;
        ammo += ammos;

        //Level Up
        if (xp >= requiredXp)
        {
            UpdateDB((Mathf.RoundToInt(xp) - requiredXp), 1, coins, ammos);

            AudioManager.PlaySound("levelUp", 0.7f);
        }
        else
        {
            UpdateDB(Mathf.RoundToInt(xp), 0, coins, ammos);
        }
    }

    //Web request
    IEnumerator GetRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log("User Database Failed!");
        }
        else
        {
            string dbContent = "{\"UserInfo\": " + webRequest.downloadHandler.text + "}";

            user = JsonUtility.FromJson<UserList>(dbContent);

            xp = user.UserInfo[0].xp;
            level = user.UserInfo[0].level;
            coin = user.UserInfo[0].coin;
            ammo = user.UserInfo[0].ammo;
            requiredXp = levelBase * level;

            Debug.Log("User Database Loaded!");
        }
    }
}
