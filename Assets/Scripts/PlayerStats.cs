using System.Collections;
using PlayerMovement.Base;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    // Array to host all of the forms (Scriptable Objects)
    public FormStats[] forms; 
    private int currentFormIndex = 0;

   // Gets the player sprite and the base movement script
    private SpriteRenderer spriteRenderer;
    private BaseMovement baseMovement;

    // Refers to the image from the scriptable object
    public Image formSprite;

    // Calls on the scriptable objects
    public FormStats form;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMovement = GetComponent<BaseMovement>();
        ApplyForm(forms[currentFormIndex]);


    }

    void Update()
    {
        // Checks for Mouse1 input (Formerly C input) before starting the Switch Form function
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SwitchForm();
        }
    }

    // Switches forms in the form array (Scriptable objects with pre-determined stats)
    void SwitchForm()
    {
        // Cycle to the next form
        currentFormIndex = (currentFormIndex + 1) % forms.Length;
        ApplyForm(forms[currentFormIndex]);
        
    }

    // Adjusts the sprite and statistics based on the form selected
    void ApplyForm(FormStats form)
    {
        spriteRenderer.sprite = form.sprite;
        baseMovement.SetMovementStats(form.speed, form.jumpForce);
        formSprite.sprite = form.cardSprite;
    }


}

