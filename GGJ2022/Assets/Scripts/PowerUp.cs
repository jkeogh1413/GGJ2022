using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject weaponToEnable;
    public WeaponStats weaponStatsToUpgrade;
    public SpriteRenderer iconRenderer;
    public float lifespan = 10f;
    public GameObject notification;

    private float birthtime;

    public void Start()
    {
        birthtime = Time.time;
    }

    public void Update()
    {
        if (Time.time - birthtime > lifespan)
        {
            Destroy(gameObject);
        }
    }

    public void Init(Sprite icon, GameObject weaponToEnable, WeaponStats weaponStatsToUpgrade, GameObject notification)
    {
        iconRenderer.sprite = icon;
        this.weaponToEnable = weaponToEnable;
        this.weaponStatsToUpgrade = weaponStatsToUpgrade;
        this.notification = notification;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            AudioManager.PowerUpPickedUp();
            if (weaponToEnable != null && !weaponToEnable.activeSelf)
            {
                weaponToEnable.SetActive(true);
            }
            else if (weaponStatsToUpgrade != null)
            {
                weaponStatsToUpgrade.Upgrade();
            }
            notification.SetActive(true);

            foreach (PowerUp power in GameObject.FindObjectsOfType<PowerUp>()) {
                if (power != this)
                    Destroy(power.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
