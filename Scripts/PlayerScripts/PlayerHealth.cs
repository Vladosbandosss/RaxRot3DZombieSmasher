using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthValue = 100;
    private Slider healthSlider;

    private GameObject UIholder;
    
    void Start()
    {
        healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthSlider.value = healthValue;

        UIholder = GameObject.Find("UIHolder");
    }

    public void ApplyDamage(int damageAmmount)
    {
        healthValue -= damageAmmount;

        if (healthValue < 0)
        {
            healthValue = 0;
        }

        healthSlider.value = healthValue;

        if (healthValue == 0)
        {
            UIholder.SetActive(false);
            GamePlayController.instance.GameOver();
        }
    }
}
