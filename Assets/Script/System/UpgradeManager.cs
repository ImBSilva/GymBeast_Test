using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerController playerController;
    public int stackUpgradeCost = 100;
    public int colorChangeCost = 50;
    public Renderer playerRenderer;

    void Start()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController não atribuído no UpgradeManager!");
        }

        if (playerRenderer == null)
        {
            Debug.LogError("Renderer não atribuído no UpgradeManager!");
        }
    }

    public void UpgradeStackCapacity()
    {
        if (playerController.money >= stackUpgradeCost)
        {
            playerController.ChangeStackCapacity(1);
            playerController.ChangeMoney(-stackUpgradeCost);
        }
        else
        {
            Debug.Log("Dinheiro insuficiente para upgrade de capacidade.");
        }
    }

    public void ChangeColor(Color newColor)
    {
        if (playerController.money >= colorChangeCost)
        {
            playerRenderer.material.color = newColor;
            playerController.ChangeMoney(-colorChangeCost);
        }
        else
        {
            Debug.Log("Dinheiro insuficiente para mudança de cor.");
        }
    }

    public void ChangeColorRandom()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        ChangeColor(randomColor);
    }
}
