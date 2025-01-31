using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI stackCapacityText;
    public PlayerController playerController;

    void Start()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController n�o atribu�do no GameManager!");
            return;
        }

        if (moneyText == null || stackCapacityText == null)
        {
            Debug.LogError("Refer�ncias de UI n�o atribu�das no GameManager!");
            return;
        }

        playerController.OnMoneyChanged += UpdateMoneyUI;
        playerController.OnStackCapacityChanged += UpdateStackCapacityUI;

        UpdateMoneyUI(playerController.money);
        UpdateStackCapacityUI(playerController.maxStackCapacity);
    }

    #region UI Update

    void UpdateMoneyUI(int newMoney)
    {
        moneyText.text = "Dinheiro: " + newMoney;
    }

    void UpdateStackCapacityUI(int newCapacity)
    {
        stackCapacityText.text = "Capacidade de Stack: " + newCapacity;
    }

    #endregion
}
