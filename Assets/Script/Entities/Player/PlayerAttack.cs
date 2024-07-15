using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private StackManager stackManager;
    public float punchRange = 2f;
    public LayerMask enemyLayer;

    void Start()
    {
        stackManager = GetComponent<StackManager>();
    }

     public void Punch()
     {
         RaycastHit hit;
         if (Physics.Raycast(transform.position, transform.forward, out hit, punchRange, enemyLayer))
         {
             EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
             if (enemyController != null)
             {
                 Debug.Log("Enemy hit!");
                 stackManager.StackEnemy(enemyController);
             }
         }
     }
}
