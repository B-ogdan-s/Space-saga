using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public LevelCreating LevCreat;
    public int money;

    void Update()
    {
        for (int i = 0; i < LevCreat.numberOfAsteroids; i++)
        {
            if(LevCreat.asterod[i].hP<=0 && LevCreat.asterod[i].destroy == false)
            {
                AddMoney(LevCreat.asterod[i].price);
                LevCreat.asterod[i].DestroyAsteroid();
            }
        }
    }

    /*
     * изменение количества игровой валюты
     */
    public void AddMoney(int add)
    {
        money += add;
    }
}
