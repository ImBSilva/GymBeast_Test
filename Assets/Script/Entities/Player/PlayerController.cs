using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxStackCapacity = 5;
    public int money = 0;
    public event Action<int> OnMoneyChanged;
    public event Action<int> OnStackCapacityChanged;

    public Animator animator;

    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private StackManager stackManager;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        stackManager = GetComponent<StackManager>();

        if (animator == null) Debug.LogError("Animator não atribuído no PlayerController!");
        if (rb == null) Debug.LogError("Rigidbody não atribuído no PlayerController!");

        stackManager.SetMaxStackCapacity(maxStackCapacity);
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
        stackManager.UpdateStackInertia(rb.velocity);
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movementInput = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        playerMovement.Move(movementInput);
        UpdateAnimations(movementInput);
        UpdateRotation(movementInput);
    }

    #region Animations

    private void HandleAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAttack?.Punch();
            animator.SetTrigger("attack");
        }
    }

    private void UpdateAnimations(Vector3 movementInput)
    {
        animator.SetBool("isWalking", movementInput.magnitude > 0);
    }

    private void UpdateRotation(Vector3 movementInput)
    {
        if (movementInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    #endregion

    #region Sistems Manager

    public void ChangeMoney(int amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke(money);
    }

    public void ChangeStackCapacity(int amount)
    {
        maxStackCapacity += amount;
        OnStackCapacityChanged?.Invoke(maxStackCapacity);
        stackManager.SetMaxStackCapacity(maxStackCapacity);
    }

    #endregion
}
