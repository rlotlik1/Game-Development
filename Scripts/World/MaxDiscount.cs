using UnityEngine;
using UnityEngine.UI;

public class MaxDiscount : MonoBehaviour
{
    [SerializeField] private InputField amountText;

    private int amount;

    public void overLimit()
    {
        int.TryParse(amountText.text, out amount);

        if (amount > 1200)
        {
            amountText.text = "1200";
        }
    }
}
