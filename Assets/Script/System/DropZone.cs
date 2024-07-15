using UnityEngine;

public class DropZone : MonoBehaviour
{
    public int rewardAmount = 100;
    public PlayerController playerController;
    public StackManager stackManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            int stackSize = stackManager.GetStackSize();
            int totalReward = stackSize * rewardAmount;

            playerController.ChangeMoney(totalReward);

            stackManager.ClearStack();
            stackManager.ResetStack();

            Destroy(other.gameObject);
        }
    }
}
