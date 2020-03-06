﻿﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSignIn : MonoBehaviour
{
    [SerializeField] private InputField emailInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private Text status;

    public UserList user = new UserList();

    private bool emailFilled;
    private bool passwordFilled;

    static PlayerSignIn instance;

    //Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        //When signed in, assign user info from sign in array and then detroy itself
        if(SceneManager.GetActiveScene().name == "OpenWorld")
        {
            GameManager.Instance.CurrentPlayer.InitLevelData(user.UserInfo[0].username,
                                                             user.UserInfo[0].xp,
                                                             user.UserInfo[0].level,
                                                             user.UserInfo[0].coin,
                                                             user.UserInfo[0].ammo);

            Destroy(gameObject);
        }
    }

    public void SignIn()
    {
        //Create wwwForm to send to database
        WWWForm userF = new WWWForm();

        //Initialize player data entry
        userF.AddField("semail", emailInput.text);
        userF.AddField("spassword", passwordInput.text);

        //DB url
        string path = "http://thecodekite.com/game/signinF.php";

        //Create unity webrequest to post wwwform
        UnityWebRequest webRequest = UnityWebRequest.Post(path, userF);

        status.text = "Loading...";

        //Call webrequest when all inputs are filled
        if (emailFilled && passwordFilled)
        {
            StartCoroutine(GetRequest(webRequest));
        }
        else
        {
            status.text = "Missing Username or Password!";
        }
    }

    //Sign in webrequest
    IEnumerator GetRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        //Determine if sign in is successful
        if (webRequest.isNetworkError)
        {
            Debug.Log("Connection Failed!");
            status.text = "Connection Failed!";
        }
        else
        {
            Debug.Log("Connection Succeeded!");
            Debug.Log("DB Returned: " + webRequest.downloadHandler.text);

            if (webRequest.downloadHandler.text == "\"failed\"")
            {
                Debug.Log("Sign In Failed!");
                status.text = "Incorrect Username or Password!";
            }
            else
            {
                Debug.Log("Sign In Sucessful!");

                //Storing database json into an a list 
                string dbContent = "{\"UserInfo\": " + webRequest.downloadHandler.text + "}";

                user = JsonUtility.FromJson<UserList>(dbContent);

                SceneManager.LoadScene("OpenWorld");
            }
            
        }
    }
    //---------------------------------------------------------------------------------------------

    //Set email as filled
    public void EmailF()
    {
        if (emailInput.text != "")
        {
            emailFilled = true;
        }
    }
    //---------------------------------------------------------------------------------------------

    //Set email as filled
    public void PasswordF()
    {
        if (passwordInput.text != "")
        {
            passwordFilled = true;
        }
    }
    //---------------------------------------------------------------------------------------------
}
