using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    
    public List <gun> weapons;
    public int currentWeapon = 0;
    void Start()
    {
        weapons[DataSaver.weapon].gameObject.SetActive(true);

    }

}
