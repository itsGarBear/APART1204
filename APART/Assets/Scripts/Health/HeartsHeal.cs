using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsHeal : MonoBehaviour
{

    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
