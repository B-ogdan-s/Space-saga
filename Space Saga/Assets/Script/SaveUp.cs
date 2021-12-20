using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUp : MonoBehaviour
{
    public Data data;
    public Save save;

    public void InputAccelerationSpeed(int accSpeed)
    {
        PlayerPrefs.SetInt(data.numSpac + "AccelerationSpeed", accSpeed);
    }

    public void InputAccelerationRotat(int accRot)
    {
        PlayerPrefs.SetInt(data.numSpac + "AccelerationRotat", accRot);
    }

    public void InputAttack(int attack)
    {
        PlayerPrefs.SetInt(data.numSpac + "Attack", attack);
    }

    public void InputHp(int hp)
    {
        PlayerPrefs.SetInt(data.numSpac + "Hp", hp);
    }



    public int OutputAccelerationSpeed()
    {
        if (data != null)
            return PlayerPrefs.GetInt(data.numSpac + "AccelerationSpeed");
        else
            return PlayerPrefs.GetInt(save.OutputInfoStartLevel() + "AccelerationSpeed");
    }

    public int OutputAccelerationRotat()
    {
        if (data != null)
            return PlayerPrefs.GetInt(data.numSpac + "AccelerationRotat");
        else
            return PlayerPrefs.GetInt(save.OutputInfoStartLevel() + "AccelerationRotat");
    }

    public int OutputAttack()
    {
        if (data != null)
            return PlayerPrefs.GetInt(data.numSpac + "Attack");
        else
            return PlayerPrefs.GetInt(save.OutputInfoStartLevel() + "Attack");
    }

    public int OutputHp()
    {
        if (data != null)
            return PlayerPrefs.GetInt(data.numSpac + "Hp");
        else
            return PlayerPrefs.GetInt(save.OutputInfoStartLevel() + "Hp");
    }
}
