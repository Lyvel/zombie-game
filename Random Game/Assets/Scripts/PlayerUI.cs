using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;

    private void Update()
    {
        AmmoText.text = PlayerShooting.instance.CurrentWeapon.CurrentLoadedAmmo + " / " + PlayerShooting.instance.CurrentWeapon.CurrentAmmo;
    }
}
