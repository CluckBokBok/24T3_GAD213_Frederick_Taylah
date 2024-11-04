using UnityEngine;

[CreateAssetMenu(fileName = "New Form", menuName = "Form")]
public class FormStats : ScriptableObject
{
    //Hosts all of the following information for each form type: 
    public string formName;
    public Sprite sprite;
    public float speed;
    public float jumpForce;  
    public int attackPower;
    public int health;
}

