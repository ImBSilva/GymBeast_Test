using UnityEngine;
using System.Collections.Generic;

public class StackManager : MonoBehaviour
{
    public Transform stackPosition;
    public float stackSpacing = 1.5f;
    public float followSpeed = 5f;
    public int maxStackCapacity;

    private List<EnemyController> stack = new List<EnemyController>();

    public void StackEnemy(EnemyController enemyController)
    {
        if (stack.Count >= maxStackCapacity) return;

        enemyController.Stack();
        stack.Add(enemyController);
        UpdateStackPositions();
    }

    public void UnstackEnemy(EnemyController enemyController)
    {
        enemyController.Unstack();
        stack.Remove(enemyController);
        UpdateStackPositions();
    }

    public void UpdateStackInertia(Vector3 movementInput)
    {
        if (stack.Count == 0) return; 

        Vector3 previousVelocity = movementInput;

        for (int i = 0; i < stack.Count; i++)
        {
            Transform enemy = stack[i].transform;
            Vector3 targetPosition = stackPosition.position + Vector3.up * (i * stackSpacing);

            enemy.position = Vector3.Lerp(enemy.position, targetPosition + previousVelocity * Time.deltaTime, Time.deltaTime * followSpeed);

            previousVelocity = (enemy.position - targetPosition) / Time.deltaTime;
        }
    }

    public void SetMaxStackCapacity(int capacity)
    {
        maxStackCapacity = capacity;
    }

    public void ClearStack()
    {
        foreach (EnemyController enemy in stack)
        {
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
            }
        }

        stack.Clear();
    }

    public void ResetStack()
    {

        ClearStack();
        UpdateStackPositions();
    }

    private void UpdateStackPositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            Transform stackedObject = stack[i].transform;
            stackedObject.position = stackPosition.position + new Vector3(0, i * stackSpacing, 0);
        }
    }

    public int GetStackSize()
    {
        return stack.Count;
    }
}
