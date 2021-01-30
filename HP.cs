using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public GameOverManager gm;
    public Image currentHealthBar;
    public Text ratioText;

    public float currentHealth;
    public float maxHealth = 100;

    void Start()
    {
        currentHealth = 100;
        Debug.Log(currentHealth);
    }

    private void UpdateHealthBar()
    {
        float ratio = currentHealth / maxHealth;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";       
    }

    public void TakeDamage(float kamikazeDamage)
    {   
        currentHealth -= kamikazeDamage;
        if(currentHealth < 0)
        {
            currentHealth = 0;           
            gm.GameEnded();
            Debug.Log("YOU'RE DEAD");
            
        }

        UpdateHealthBar();
    }
    
    public void HPSupply()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
}
