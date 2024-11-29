using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormChangeCardUI : MonoBehaviour
{
    //Variables for each of the components in my scriptable objects

    public FormStats form;

    public TMP_Text formName;
    public TMP_Text formAbility;

    public Image formSprite;

    public TMP_Text formHealth;

    // Start is called before the first frame update
    void Start()
    {
        // sets all of the components from scriptable objects into selected UI elements 

        formName.text = form.formName;
        formAbility.text = form.abilityDescription;

        formSprite.sprite = form.cardSprite;

        formHealth.text = form.health.ToString();
    }
}
