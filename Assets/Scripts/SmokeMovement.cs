using System.Collections;
using UnityEngine;
using PlayerMovement.Base;

public class SmokeMovement : BaseMovement
{
    [SerializeField] private float staminaTotal = 5f;
    [SerializeField] private float staminaDepletionRate = 3f;
    [SerializeField] private float staminaRechargeRate = 1f; 
    [SerializeField] private float floatingSpeed = 2f;
    private bool isFlying = false;
    private float currentStamina;
    private float rechargeTimer = 0;

    void Start()
    {
        currentStamina = staminaTotal;
        Debug.Log("Initial stamina: " + currentStamina);
    }

    void Update()
    {
        base.Update();
        SmokeFloating();
        StaminaRecharge();
    }

    private void SmokeFloating()
    {
        if (Input.GetKey(KeyCode.F) && currentStamina > 0)
        {
            StartFloating();
        }
        else
        {
            StopFloating();

        }

        if (isFlying)
        {
          
            currentStamina -= staminaDepletionRate * Time.deltaTime;
            Debug.Log("Flying. Current stamina: " + currentStamina);

            if (currentStamina <= 0)
            {
                currentStamina = 0;
                StopFloating(); 
                Debug.Log("Stamina depleted. Stopped flying.");
            }
        }
    }

    private void StartFloating()
    {
        if (!isFlying)
        {
            isFlying = true;
            body.gravityScale = 0; 
            Debug.Log("Started flying.");
        }
        body.velocity = new Vector2(body.velocity.x, floatingSpeed);
    }

    private void StopFloating()
    {
        if (isFlying)
        {
            isFlying = false;
            body.gravityScale = 1; // Re-enable gravity
            Debug.Log("Flying stopped.");
        }
    }

    private void StaminaRecharge()
    {
        if (!isFlying & touchingGround)
        {
            currentStamina += staminaRechargeRate * Time.deltaTime; 
        }
    }

}






