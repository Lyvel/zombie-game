using UnityEngine;

[System.Serializable]
public class WeaponBase : MonoBehaviour {

    //Floats
    public float Damage;
    public float Range;
    public float FireRate;
    public float MaxAmmo;
    public float CurrentAmmo;
    public float CurrentLoadedAmmo;
    public float ReloadTime;

    //Bools
    public bool Automatic;
    public bool Reloading;
    public bool Projectile;

    //Hidden
    [HideInInspector]
    public float nextFire;
}