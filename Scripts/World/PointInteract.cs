using UnityEngine;
using UnityEngine.EventSystems;

public class PointInteract : MonoBehaviour
{
    [SerializeField] private GameObject infoBoard;

    private void OnMouseDown()
    {
        //For Demo Only! Take out of "if" when build
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Camera.main.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            infoBoard.SetActive(true);
            AudioManager.PlaySound("thump", 0.4f);
        }
    }

    public void TurnOffBlocker()
    {
        Camera.main.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
