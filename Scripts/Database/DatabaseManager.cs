using System.Collections;
using Mapbox.Unity.Location;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{

    [SerializeField] private Text statusText;
    [SerializeField] private Text result;
    [SerializeField] private int parameter;
    [SerializeField] private float waitTime = 120.0f;

    private string dbContent;
    private string path;

    private AbstractLocationProvider localInfo = null;

    public BusinessList BusinessList = new BusinessList();

    

    private void Start()
    {
        if (null == localInfo)
        {
            localInfo = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }

        InvokeRepeating("ExtractData", 1f,waitTime);

        //Test this before run: http://thecodekite.com/coord/getcoo.php?lat=42.097&lng=-75.9143&peri=500

    }

    private void ExtractData()
    {
        Location currLoc = localInfo.CurrentLocation;

        path = "http://thecodekite.com/coord/getcoo.php?lat=" + currLoc.LatitudeLongitude.x + "&lng="
                                                              + currLoc.LatitudeLongitude.y + "&peri=" + parameter;

        UnityWebRequest webRequest = UnityWebRequest.Get(path);

        StartCoroutine(GetRequest(webRequest));

        Debug.Log("Bussiness DB Updated!");

        
    }

    IEnumerator GetRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();
        
        if (webRequest.isNetworkError)
        {
            statusText.text = "Database: Failed!";
        }
        else
        {
            dbContent = "{\"BusinessInfo\": " + webRequest.downloadHandler.text + "}";

            BusinessList = JsonUtility.FromJson<BusinessList>(dbContent);

            statusText.text = "Database: Connected!";
            result.text = BusinessList.BusinessInfo.Count + " Businesses Nearby!";
        }
    }
}

