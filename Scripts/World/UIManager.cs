using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text ammoText;
    [SerializeField] private Text username;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject blocker;
    [SerializeField] private GameObject levelUp;
    [SerializeField] private Slider xpBar;
    
    private void Awake()
    {
        Assert.IsNotNull(xpText);
        Assert.IsNotNull(levelText);
        Assert.IsNotNull(menu);
    }

    private void Update()
    {
        UpdateUsername();
        UpdateLevel();
        UpdateXP();
        UpdateCoins();
        UpdateAmmo();
    }

    private void UpdateUsername()
    {
        username.text = GameManager.Instance.CurrentPlayer.GetUsername;
    }

    private void UpdateLevel()
    {
        levelText.text = GameManager.Instance.CurrentPlayer.GetLvl.ToString();
    }

    public void UpdateXP()
    {
        xpText.text = GameManager.Instance.CurrentPlayer.GetXp
           + " / " + GameManager.Instance.CurrentPlayer.GetRequiredXp;

        xpBar.value = GameManager.Instance.CurrentPlayer.GetXp
                    / GameManager.Instance.CurrentPlayer.GetRequiredXp;

        if(GameManager.Instance.CurrentPlayer.GetXp
          >= GameManager.Instance.CurrentPlayer.GetRequiredXp)
        {
            xpBar.value = 0;
            levelUp.SetActive(true);
            blocker.SetActive(true);
            Camera.main.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void UpdateCoins()
    {
        coinText.text = GameManager.Instance.CurrentPlayer.GetCoin.ToString();
    }

    private void UpdateAmmo()
    {
        ammoText.text = GameManager.Instance.CurrentPlayer.GetAmmo.ToString();
    }

    public void UIBlock(bool onOff)
    {
        blocker.SetActive(onOff);
    }
}
