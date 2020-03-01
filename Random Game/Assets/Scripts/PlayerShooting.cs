using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    public WeaponBase CurrentWeapon;

    public Transform ShootPoint;

    private void Start()
    {
        if (PlayerShooting.instance == null)
            PlayerShooting.instance = this;
    }

    private void Update()
    {
        if (CurrentWeapon.Automatic) if (Input.GetKey(KeyCode.Mouse0)) Shoot();
        if (!CurrentWeapon.Automatic) if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R) && !CurrentWeapon.Reloading) StartCoroutine(Reload());
    }

    void Shoot(){
        if (CurrentWeapon.Reloading){
            Debug.Log("Can't shoot. (Reloading)");
            return;
        }

        if (CurrentWeapon.Projectile){
            Debug.Log("Can't shoot. (Projectile not implemented)");
            return;
        }

        if (CurrentWeapon.nextFire < Time.time){
            CurrentWeapon.nextFire = CurrentWeapon.FireRate + Time.time;
            Debug.Log("Can shoot. (Firerate)");
            if (CurrentWeapon.CurrentLoadedAmmo > 0){
                CurrentWeapon.CurrentLoadedAmmo--;

                RaycastHit hit;
                if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit, CurrentWeapon.Range)){
                    if (hit.transform.tag == "Enemy"){
                        Debug.Log("Hit enemy!");
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(CurrentWeapon.Damage);
                    }
                }

                Debug.Log("Can shoot. (Ammo)");
            } else {
                Debug.Log("Can't shoot. (Ammo)");
            }
        } else {
            Debug.Log("Can't shoot. (Firerate)");
        }
    }

    IEnumerator Reload(){
        if (CurrentWeapon.CurrentAmmo > 0){
            Debug.Log("Can reload.");
            CurrentWeapon.Reloading = true;
            float temp = CurrentWeapon.CurrentAmmo + CurrentWeapon.CurrentLoadedAmmo;
            CurrentWeapon.CurrentLoadedAmmo = 0;
            yield return new WaitForSeconds(CurrentWeapon.ReloadTime);
            if (temp > CurrentWeapon.MaxAmmo){
                CurrentWeapon.CurrentLoadedAmmo = CurrentWeapon.MaxAmmo;
                CurrentWeapon.CurrentAmmo = temp - CurrentWeapon.MaxAmmo;
            } else {
                CurrentWeapon.CurrentLoadedAmmo = temp;
                CurrentWeapon.CurrentAmmo = 0;
            }
            CurrentWeapon.Reloading = false;
        } else {
            Debug.Log("Can't reload");
        }
        yield return null;
    }
}
