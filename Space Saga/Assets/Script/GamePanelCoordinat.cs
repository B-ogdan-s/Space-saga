using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelCoordinat : MonoBehaviour
{
    public GameObject controlFonLeft, controlLeft, controlFonRight, controlRight, pause, settings, over, loadingFon, cursor;
    public Vector3 controlFonCoordinatLeft, controlCoordinatLeft;
    public Vector3 startTouchLeft, momrntTouchLeft, startTouchRight, momrntTouchRight;

    public bool speedTrafCheck = false;

    void Start()
    {
        /*
         * указываю первоначальные координаты и размеры UI объектов
         */
        loadingFon.transform.localPosition = new Vector3(0f, 0f, 0f);
        pause.transform.localPosition = new Vector3(0f, 0f, 0f);
        settings.transform.localPosition = new Vector3(0f, 0f, 0f);
        over.transform.localPosition = new Vector3(0f, 0f, 0f);

        pause.transform.localPosition += new Vector3(0f, 2000f, 0f);
        pause.transform.localScale = new Vector3(Screen.width / 2960f, Screen.height / 1440f, 1f);

        settings.transform.localPosition -= new Vector3(0f, 2000f, 0f);
        settings.transform.localScale = new Vector3(Screen.width / 2960f, Screen.height / 1440f, 1f);

        over.transform.localPosition -= new Vector3(0f, 2000f, 0f);
        over.transform.localScale = new Vector3(Screen.width / 2960f, Screen.height / 1440f, 1f);

        loadingFon.transform.localPosition -= new Vector3(0f, 3000f, 0f);
        loadingFon.transform.localScale = new Vector3(Screen.width / 2960f + 0.1f, Screen.height / 1440f + 0.1f, 1f);

        controlFonLeft.transform.localScale = new Vector3(Screen.width / 2960f, Screen.width / 2960f, 1f);
        controlFonLeft.transform.localPosition = new Vector3(-Screen.width / 2960f * 1100f, 
                                                            -Screen.height / 1440f * 340f, 0f);

        controlFonRight.transform.localScale = new Vector3(Screen.width / 2960f, Screen.width / 2960f, 1f);
        controlFonRight.transform.localPosition = new Vector3(Screen.width / 2960f * 1250f,
                                                            Screen.height / 1440f * -340f, 0f);


        controlFonCoordinatLeft = controlFonLeft.transform.localPosition;
        controlCoordinatLeft = controlLeft.transform.localPosition;
    }

    void FixedUpdate()
    {
        /*
         * проверяю на косание по экрану и узнаю их количество
        */
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                TouchInut(Input.touches[i]);
            }
        }
        else
        {
            controlCoordinatLeft = new Vector3(0f, 0f, 0f);

            controlLeft.transform.localPosition = controlCoordinatLeft;
            controlFonLeft.transform.localPosition = controlFonCoordinatLeft;
        }
    }

    public void TouchInut(Touch touch)
    {
        Vector3 rightPol = controlFonRight.transform.localPosition;

        // проверка на касание
        if (touch.phase == TouchPhase.Began)
        {
            /* 
             * проверка на касание в левой половине экрана
             */
            if (touch.position.x < Screen.width / 2f )
            {
                startTouchLeft = touch.position;
                controlFonLeft.transform.localPosition = new Vector3(startTouchLeft.x - Screen.width / 2f,
                                                                 startTouchLeft.y - Screen.height / 2f, startTouchLeft.z);
            }
            /*
             * проверка на касание в зоне правого курсора
             */
            else if (touch.position.x < (rightPol.x + 120f) + Screen.width / 2f &&
                    touch.position.x > (rightPol.x - 120f) + Screen.width / 2f &&
                    touch.position.y < (rightPol.y + 300f) + Screen.height / 2f &&
                    touch.position.y > (rightPol.y - 300f) + Screen.height / 2f)
            {
                startTouchRight = touch.position;

                speedTrafCheck = true;
            }
            else
            {
                // для правой половины
            }
        }

        // проверка на удерживание
        if (touch.phase == TouchPhase.Moved)
        {

            if (touch.position.x < Screen.width / 2f)
            {
                momrntTouchLeft = touch.position;
                Vector3 mTouch = momrntTouchLeft - startTouchLeft;

                if ((mTouch.x * mTouch.x) + (mTouch.y * mTouch.y) <= (300f * 300f))
                {
                    controlLeft.transform.localPosition = new Vector3(mTouch.x, mTouch.y, mTouch.z);
                }
                else
                {
                    controlLeft.transform.localPosition = Match(mTouch);
                }

                controlCoordinatLeft = controlLeft.transform.localPosition;
            }
            else if (touch.position.x < (rightPol.x + 120f) + Screen.width / 2f &&
                    touch.position.x > (rightPol.x - 120f) + Screen.width / 2f && speedTrafCheck == true )
            {
                controlRight.transform.localPosition += new Vector3(0f, (touch.position.y - startTouchRight.y), 0f);
                startTouchRight = touch.position;

                if(controlRight.transform.localPosition.y > 250f)
                {
                    controlRight.transform.localPosition = new Vector3(controlRight.transform.localPosition.x, 250f,0f);
                }
                else if(controlRight.transform.localPosition.y < -250f)
                {
                    controlRight.transform.localPosition = new Vector3(controlRight.transform.localPosition.x, -250f, 0f);
                }
            }
            else
            {
                // для правой половины
            }
        }

        // проверка на отпуск
        if (touch.phase == TouchPhase.Ended)
        {
            if (touch.position.x < Screen.width / 2f )
            {
                controlCoordinatLeft = new Vector3(0f, 0f, 0f);

                controlLeft.transform.localPosition = controlCoordinatLeft;
                controlFonLeft.transform.localPosition = controlFonCoordinatLeft;
            }
            else if (touch.position.x < (rightPol.x + 120f) + Screen.width / 2f &&
                    touch.position.x > (rightPol.x - 120f) + Screen.width / 2f)
            {
                speedTrafCheck = false;
            }
        }
    }

    public Vector3 Match(Vector3 mTouch)
    {
        float sin = mTouch.y / Mathf.Sqrt((mTouch.x * mTouch.x) + (mTouch.y * mTouch.y));
        float cos = mTouch.x / Mathf.Sqrt((mTouch.x * mTouch.x) + (mTouch.y * mTouch.y));

        float y = sin * 300;
        float x = cos * 300;

        Vector3 ret = new Vector3(0f, 0f, 0f);

        ret.x = x;
        ret.y = y;

        return ret;
    }
}
