using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image Healthbar;
    public float HealthAmount = 100;
   
    
    void Start()
    {
    
        

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.P)) {

            TakeDamage(5);

        
        }
        if(Input.GetKey(KeyCode.O)) {

            Heal(5);


        }
    }
    public void TakeDamage(float damage) {

        HealthAmount -=damage;
        Healthbar.fillAmount = HealthAmount / 100f;
    
    
    
    }
    public void Heal(float HealAmount) {
    
     HealthAmount+= HealAmount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, 100);
        Healthbar.fillAmount = HealthAmount / 100f;
    }

}

