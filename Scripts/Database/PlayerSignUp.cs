using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSignUp : MonoBehaviour
{
    [SerializeField] private InputField confirmPassword;
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private InputField emailInput;
    [SerializeField] private GameObject errorText;
    [SerializeField] private GameObject signUpSuccess;
    [SerializeField] private GameObject signUpFailed;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject loadingText;
    [SerializeField] private Toggle agreement;
    [SerializeField] private Text signUpFailedText;


    private bool usernameFilled;
    private bool emailFilled;
    private bool passwordFilled;

    //Take in user input and send them to the user database to create an entry
    public void SignUp()
    {
        //Create wwwForm to send to database
        WWWForm userF = new WWWForm();

        //Initialize player data entry
        userF.AddField("username", usernameInput.text);
        userF.AddField("password", passwordInput.text);
        userF.AddField("email", emailInput.text);
        userF.AddField("xp", 0);
        userF.AddField("level", 1);
        userF.AddField("coin", 0);
        userF.AddField("ammo", 0);

        //DB url
        string path = "http://thecodekite.com/test/gameSignupC.php";

        //Create unity webrequest to post wwwform
        UnityWebRequest webRequest = UnityWebRequest.Post(path, userF);

        //Call webrequest when all inputs are filled
        if(usernameFilled && emailFilled && passwordFilled && agreement.isOn)
        {
            StartCoroutine(GetRequest(webRequest));
        }
        else
        {
            signUpFailed.SetActive(true);
            backButton.SetActive(true);
            signUpFailed.transform.GetChild(0).gameObject.SetActive(true);
            loadingText.SetActive(false);
        }
    }
    //---------------------------------------------------------------------------------------------

    //Sign up webrequest
    IEnumerator GetRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        //Determine if sign up is successful
        if (webRequest.isNetworkError)
        {
            Debug.Log("Connection Failed!");
            signUpFailed.SetActive(true);
            signUpFailedText.text = "Connection Failed!";

            backButton.SetActive(true);
            loadingText.SetActive(false);
        }
        else
        {
            Debug.Log("Connection Succeeded!");
            Debug.Log("DB returned: " + webRequest.downloadHandler.text);

            if (webRequest.downloadHandler.text  == "true")
            {
                Debug.Log("Sign Up Sucessful!");
                signUpSuccess.SetActive(true);
                backButton.SetActive(true);
                loadingText.SetActive(false);
            }
            else
            {
                Debug.Log("Sign Up Failed!");
                signUpFailed.SetActive(true);
                backButton.SetActive(true);

                signUpFailed.transform.GetChild(1).gameObject.SetActive(true);

                loadingText.SetActive(false);
            } 
        }
    }
    //---------------------------------------------------------------------------------------------

    //Determine if the password match with confirm password
    public void PasswordMatch()
    {
        if (passwordInput.text != confirmPassword.text)
        {
            errorText.SetActive(true);
            passwordFilled = false;
        }
        else
        {
            errorText.SetActive(false);
            passwordFilled = true;
        }
    }
    //---------------------------------------------------------------------------------------------

    //Set username as filled
    public void UsernameF()
    {
        if(usernameInput.text != "")
        {
            usernameFilled = true;
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
}
