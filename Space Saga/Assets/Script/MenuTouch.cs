using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTouch : MonoBehaviour
{
    public Data data;
    public Save save;

    static Vector2 startTouch, finishTouch;
    static GameObject menuTouch, cam, menuText, panelInfo;
    public GameObject loadingFon;
    static int numOfSpacecraft;
    public int top=1, noTop=0;
    static float speed, returnSpeed, newCoordinat, interval;

    /*
     * первоначальные настройки главного меню 
     */
    void Start()
    {
        loadingFon.transform.localPosition = new Vector3(0f, 0f, 0f);
        loadingFon.transform.localPosition -= new Vector3(0f, 3000f, 0f);
        loadingFon.transform.localScale = new Vector3(Screen.width / 2960f + 0.1f, Screen.height / 1440f + 0.1f, 1f);
        menuTouch = data.menuTouch;
        cam = data.cam;
        menuText = data.menuText;
        numOfSpacecraft = data.numOfSpacecraft;
        panelInfo = data.panelInfo;

        panelInfo.transform.localScale = new Vector3(Screen.width / 2960f + 0.1f, Screen.height / 1440f + 0.1f, 1f);


        speed = data.speed;
        returnSpeed = data.returnSpeed;
        interval = data.interval;
        NewCoordinat();

    }

    void Update()
    {
        /*
         * проверка на нажатие
         */
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // проверка на касание
            if (touch.phase == TouchPhase.Began)
            {
                NewCoordinat();
                startTouch = Input.GetTouch(0).position;

                if(top==1)
                {
                    menuText.transform.localPosition -= new Vector3(0f, 2000f, 0f);

                    panelInfo.transform.localPosition += new Vector3(2000f, 0, 0f);

                    top = 0;
                    noTop = 1;
                }
            }

            // проверка на удерживание
            if (touch.phase == TouchPhase.Moved)
            {
                finishTouch = Input.GetTouch(0).position;
                Shift(finishTouch.x - startTouch.x);
            }

            // проверка на отпуск
            if (touch.phase == TouchPhase.Ended)
            {
                startTouch.x = 0f;
                finishTouch.x = 0f;
            }
        }
        /*
         * если нет нажатия
         */
        else
        {
            if(cam.transform.position.x % interval == 0 )
            {
                foreach(SpaceshipInfo i in data.spaceship)
                {
                    if(i.num == cam.transform.position.x / interval)
                    {
                        menuText.GetComponent<Text>().text = i.spaceshipName;

                        data.hpText.GetComponent<Text>().text = "HP: " + i.hp;
                        if(i.numberOfGuns > 1)
                            data.atkText.GetComponent<Text>().text = "ATK: " + i.attack + " x" + i.numberOfGuns;
                        else
                            data.atkText.GetComponent<Text>().text = "ATK: " + i.attack;

                        data.maxSpeedText.GetComponent<Text>().text = "MAX скорость: " + i.speed;

                        data.HP.fillAmount = (float)i.hp / data.maxHP;
                        data.ATK.fillAmount = ((float)i.attack * (float)i.numberOfGuns) / data.maxATK;
                    }
                }

                if(noTop==1)
                {
                    menuText.transform.localPosition += new Vector3(0f, 2000f, 0f);

                    panelInfo.transform.localPosition -= new Vector3(2000f, 0, 0f);

                    noTop = 0;
                    top = 1;
                }
            }

            if (cam.transform.position.x % interval != 0)
            {
                returnCam();
            }
        }
    }

    /*
     * сдвиг для оцентровки камеры на определённом объекте
     */
    void Shift(float shift)
    {
        cam.transform.position = new Vector3(shift / speed + newCoordinat, 0f, 0f);
    }

    /*
     * устанвливает новые координаты камеры
     */
    void NewCoordinat()
    {
        newCoordinat = cam.transform.position.x;
    }


    /*
     * взврат камеры
     */
    void returnCam()
    {
        data.numSpac = 0;
        while(data.numSpac != numOfSpacecraft-1)
        {
            if(cam.transform.position.x <= data.numSpac * interval + interval/2f)
            {
                break;
            }
            data.numSpac++;
        }

        if(cam.transform.position.x < data.numSpac * interval)
        {
            cam.transform.position += new Vector3(Time.deltaTime * returnSpeed, 0, 0);
        }
        else if(cam.transform.position.x > data.numSpac * interval)
        {
            cam.transform.position -= new Vector3(Time.deltaTime * returnSpeed, 0, 0);
        }

        if(cam.transform.position.x > data.numSpac * interval - 0.4f && cam.transform.position.x < data.numSpac * interval + 0.4f)
        {
            cam.transform.position = new Vector3(data.numSpac * interval, 0, 0);
        }
    }
}
