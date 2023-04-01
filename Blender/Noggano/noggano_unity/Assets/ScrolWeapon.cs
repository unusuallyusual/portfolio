using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolWeapon : MonoBehaviour
{
    public int weaponScroll = 0;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int currentWeapon = weaponScroll;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponScroll >= transform.childCount - 1)
                weaponScroll = 0;
            else
                weaponScroll++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponScroll <= 0)
                weaponScroll = transform.childCount - 1;
            else
                weaponScroll--;
        }

        if (currentWeapon != weaponScroll)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == weaponScroll)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
