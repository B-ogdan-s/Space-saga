using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipInfo : MonoBehaviour
{
    public string spaceshipName;

    [TextArea(6, 50)]
    public string description;
    public int num, hp, attack, speed, numberOfGuns;
    public float upAccelerationSpeed, upAccelerationRotat, upAttack, upHp;
}
