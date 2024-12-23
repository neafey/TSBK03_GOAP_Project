using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public HungerSystem hungerSystem;
    public Image hungerFill;

    void Update()
    {
        if (hungerSystem != null && hungerFill != null)
        {
            hungerFill.fillAmount = hungerSystem.currentHunger / hungerSystem.maxHunger;
            //print(hungerSystem.currentHunger);

        }
    }
}
