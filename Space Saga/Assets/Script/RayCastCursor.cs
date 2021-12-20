using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCursor : MonoBehaviour
{
    public Camera cam;
    public GameObject goal, centre;

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if (Physics.Raycast(ray, out hit))
        {
            if (Mathf.Pow(hit.transform.localPosition.x - centre.transform.position.x, 2) +
               Mathf.Pow(hit.transform.localPosition.y - centre.transform.position.y, 2) +
               Mathf.Pow(hit.transform.localPosition.z - centre.transform.position.z, 2) >= Mathf.Pow(100, 2))
            {
                goal.transform.position = hit.transform.localPosition;
            }
            else
            {
                goal.transform.localPosition = new Vector3(0f, 0.7f, 500f);
            }
        }
        else
        {
            goal.transform.localPosition = new Vector3(0f, 0.7f, 500f);
        }
    }
}
