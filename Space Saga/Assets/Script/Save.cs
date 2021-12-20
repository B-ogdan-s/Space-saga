using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public Data data;

    public void InputInfoStartLevel()
    {
        PlayerPrefs.SetInt("SpeedSpaceship", data.spaceship[data.numSpac].speed);
        PlayerPrefs.SetInt("AttackSpaceship", data.spaceship[data.numSpac].attack);
        PlayerPrefs.SetInt("StartSpaceship", data.numSpac);
    }

    public int OutputInfoStartLevel()
    {
        return PlayerPrefs.GetInt("StartSpaceship");
    }

    public int SpeedSpac()
    {
        return PlayerPrefs.GetInt("SpeedSpaceship");
    }

    public int AttackSpac()
    {
        return PlayerPrefs.GetInt("AttackSpaceship");
    }

    public int OutputMoney()
    {
        if(!PlayerPrefs.HasKey("ManeyInfo"))
        {
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt("ManeyInfo");
        }
    }

    public void InputMoney(int add)
    {
        int startManey;
        startManey = OutputMoney();
        PlayerPrefs.SetInt("ManeyInfo", startManey + add);
    }
}