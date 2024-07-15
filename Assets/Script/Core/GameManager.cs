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
            Debug.LogError("PlayerController não atribuído no GameManager!");
            return;
        }

        if (moneyText == null || stackCapacityText == null)
        {
            Debug.LogError("Referências de UI não atribuídas no GameManager!");
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
