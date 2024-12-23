using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float hungerRestoreAmount = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HungerSystem hungerSystem = collision.GetComponent<HungerSystem>();
        if (hungerSystem != null)
        {
            hungerSystem.EatFood(hungerRestoreAmount);
            Destroy(gameObject);
        }
    }
}
