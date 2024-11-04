using System.Collections;
using PlayerMovement.Base;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FormStats[] forms; 
    private int currentFormIndex = 0;
    private SpriteRenderer spriteRenderer;
    private BaseMovement baseMovement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMovement = GetComponent<BaseMovement>();
        ApplyForm(forms[currentFormIndex]);
    }

    void Update()
    {
        //Checks for C input prior to initiating SwitchForm function
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchForm();
        }
    }

    //Switches forms in the form array (Scriptable objects with pre-determined stats)
    void SwitchForm()
    {
        // Cycle to the next form
        currentFormIndex = (currentFormIndex + 1) % forms.Length;
        ApplyForm(forms[currentFormIndex]);
    }

    //Adjusts the sprite and statistics based on the form selected
    void ApplyForm(FormStats form)
    {
        spriteRenderer.sprite = form.sprite;
        baseMovement.SetMovementStats(form.speed, form.jumpForce);
    }
}

