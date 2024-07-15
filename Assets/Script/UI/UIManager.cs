using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public Text stackCapacityText;

    public void UpdateMoney(int amount)
    {
        moneyText.text = "Money: " + amount;
    }

    public void UpdateStackCapacity(int amount)
    {
        stackCapacityText.text = "Stack Capacity: " + amount;
    }
}
