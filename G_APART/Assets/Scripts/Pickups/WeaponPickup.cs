using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    public float pickupRadius = 3f;
    private Player player;
    private Inventory inv;
    public int index;
    public List<TextMeshProUGUI> pickupText;
    private PlayerWeapon playerWeapon;

    private void Awake()
    {
        playerWeapon = FindObjectOfType<PlayerWeapon>();
        player = FindObjectOfType<Player>();
        inv = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < pickupRadius)
        {
            foreach (TextMeshProUGUI text in pickupText)
            {
                text.enabled = true;
            }
            
            if (Input.GetKeyDown("e"))
            {
                inv.DropItem();
                inv.UpdatePlayerEquipped(index, inv.currentSlot);
                playerWeapon.UpdateAmmoText();
                Destroy(this.gameObject);
            }
        }
        else
        {
            foreach (TextMeshProUGUI text in pickupText)
            {
                text.enabled = false;
            }
        }
    }
}
