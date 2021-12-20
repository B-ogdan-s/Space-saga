using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    /*
     * хранит важные данные 
     */
    public GameObject menuTouch, cam, panelInfo, menuText, hpText, atkText, maxSpeedText, panelImprovement,
                        ButtonUP, ButtonStart, ButtonExit;
    public SpaceshipInfo[] spaceship;
    public Image HP, ATK;
    public int numOfSpacecraft, numSpac;
    public float maxHP = 0, maxATK = 0;
    public float interval, returnSpeed, speed, speedJ, speedR;

    void Start()
    {
        spaceship = FindObjectsOfType(typeof(SpaceshipInfo)) as SpaceshipInfo[];

        foreach (SpaceshipInfo i in spaceship)
        {
            if((float)i.hp + i.upHp * 10f > maxHP)
            {
                maxHP = (float)i.hp + i.upHp * 10f;
            }
            if(((float)i.attack + i.upAttack * 10f) * i.numberOfGuns > maxATK)
            {
                maxATK = ((float)i.attack + i.upAttack * 10f) * i.numberOfGuns;
            }
        }
    }
}
