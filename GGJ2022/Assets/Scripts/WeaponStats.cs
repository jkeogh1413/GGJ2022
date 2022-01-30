using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats.asset", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [System.Serializable]
    public class Profile
    {
        public float rateOfFire = 1;
        public float projectileSpeed = 1;
        public float projectileHoming = 0;
        public float areaOfEffect = 0;
        public float projectileCount = 1;
        public float size = 1;
    }

    public int currentProfile = 0;
    public List<Profile> profiles = new List<Profile>();

    public float RateOfFire => profiles[currentProfile].rateOfFire;
    public float ProjectileSpeed => profiles[currentProfile].projectileSpeed;
    public float ProjectileHoming => profiles[currentProfile].projectileHoming;
    public float AreaOfEffect => profiles[currentProfile].areaOfEffect;
    public float ProjectileCount => profiles[currentProfile].projectileCount;
    public float Size => profiles[currentProfile].size;
}
