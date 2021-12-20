using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject player;
    public GameObject centre;
    public GameObject text;
    public GameObject overPanel;
    public Over over;
    public int test;

    void Start()
    {
        text.transform.localPosition = new Vector3(0f, Screen.height / 2f - 170f, 0f);
        text.transform.localPosition += new Vector3(0f, 1000f, 0f);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, centre.transform.position) > 1800f)
        {
            text.transform.localPosition += new Vector3(0f, 1000f, 0f);
            over.GameOver();
            enabled = false;
        }
        else if (Vector3.Distance(player.transform.position, centre.transform.position) > 1000f && test == 0)
        {
            text.transform.localPosition -= new Vector3(0f, 1000f, 0f);
            test++;
        }
        else if (Vector3.Distance(player.transform.position, centre.transform.position) <= 1000f && test == 1)
        {
            text.transform.localPosition += new Vector3(0f, 1000f, 0f);
            test--;
        }
    }
}
