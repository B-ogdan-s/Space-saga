using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public SpaceshipTraffic SpacesgipTraff;
    public GamePanelCoordinat GPC;
    public GameObject pause;
    public int i = 0;

    /*
     * проигрыш
     */
    public void GameOver()
    {
        pause.transform.localPosition += new Vector3(0f, 2000f, 0f);
        GPC.over.transform.localPosition += new Vector3(0f, 2000f, 0f);

        GPC.cursor.transform.localPosition -= new Vector3(0f, 1000f, 0f);
        GPC.controlFonLeft.transform.localPosition -= new Vector3(1000f, 0f, 0f);
        GPC.controlFonRight.transform.localPosition += new Vector3(1000f, 0f, 0f);

        GPC.enabled = false;
        Destroy(SpacesgipTraff.spa);

        SpacesgipTraff.enabled = false;
        i++;
    }
}
