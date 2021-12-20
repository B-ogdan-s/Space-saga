using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public Save save;
    public Money money;
    public MenuTouch menuToch;
    public GamePanelCoordinat GPC;
    public Data data;

    public GameObject pauseButton, loadingFon;
    public Slider slider;

    /*
     * переход на уровень с главного меню 
     */
    public void NewLevel()
    {
        menuToch.top = 1;
        menuToch.noTop = 0;
        save.InputInfoStartLevel();

        StartCoroutine(Load("TestLevel"));
    }

    /*
     * переход на уровень после проигриша
     */
    public void ReStartLevel()
    {
        save.InputMoney(money.money);

        StartCoroutine(Load("TestLevel"));
    }

    /*
     * выход с паузы
     */
    public void Proceed()
    {
        Time.timeScale = 1;
        pauseButton.transform.localPosition -= new Vector3(0f, 600f, 0f);
        GPC.pause.transform.localPosition += new Vector3(0f, 2000f, 0f);
        GPC.controlFonLeft.transform.localPosition += new Vector3(1000f, 0f, 0f);
        GPC.controlFonRight.transform.localPosition -= new Vector3(1000f, 0f, 0f);
        GPC.cursor.transform.localPosition -= new Vector3(0f, 1000f, 0f);
        GPC.enabled = true;
    }

    /*
     * переход на вкладку с настройками во время игры 
     */
    public void InputSetting()
    {
        GPC.pause.transform.localPosition += new Vector3(0f, 2000f, 0f);
        GPC.settings.transform.localPosition += new Vector3(0f, 2000f, 0f);
    }

    /*
     * выход с меню настроек во время игры 
     */
    public void OutputSetting()
    {
        GPC.pause.transform.localPosition -= new Vector3(0f, 2000f, 0f);
        GPC.settings.transform.localPosition -= new Vector3(0f, 2000f, 0f);
    }

    /*
     * ставит игру на пауза 
     */
    public void Pause()
    {
        pauseButton.transform.localPosition += new Vector3(0f, 600f, 0f);
        GPC.pause.transform.localPosition -= new Vector3(0f, 2000f, 0f);
        GPC.controlFonLeft.transform.localPosition -= new Vector3(1000f, 0f, 0f);
        GPC.controlFonRight.transform.localPosition += new Vector3(1000f, 0f, 0f);
        GPC.cursor.transform.localPosition += new Vector3(0f, 1000f, 0f);
        Time.timeScale = 0;
        GPC.enabled = false;
    }

    /*
     * выход из уровня и переход в главное меню
     */
    public void Exid()
    {
        save.InputMoney(money.money);
        Time.timeScale = 1;

        StartCoroutine(Load("Menu"));
    }

    /*
     * открыть окно магазина
     */
    public void OpenStore()
    {
        data.panelImprovement.transform.localPosition -= new Vector3(0f, 1500f, 0f);
        data.panelInfo.transform.localPosition += new Vector3(0f, 1000f, 0f);
        data.ButtonUP.transform.localPosition -= new Vector3(0f, 500f, 0f);
        data.ButtonStart.transform.localPosition -= new Vector3(0f, 500f, 0f);
        data.ButtonExit.transform.localPosition -= new Vector3(0f, 500f, 0f);
        data.menuText.transform.localPosition -= new Vector3(0f, 500f, 0f);
        menuToch.enabled = false;
    }

    /*
     * закрыть окно магазина
     */
    public void ClosedStore()
    {
        data.panelImprovement.transform.localPosition += new Vector3(0f, 1500f, 0f);
        data.panelInfo.transform.localPosition -= new Vector3(0f, 1000f, 0f);
        data.ButtonUP.transform.localPosition += new Vector3(0f, 500f, 0f);
        data.ButtonStart.transform.localPosition += new Vector3(0f, 500f, 0f);
        data.ButtonExit.transform.localPosition += new Vector3(0f, 500f, 0f);
        data.menuText.transform.localPosition += new Vector3(0f, 500f, 0f);
        menuToch.enabled = true;
    }

    /*
     * выход из игры
     */
    public void Quit()
    {
        Debug.Log("Yes");
        Application.Quit();
    }

    IEnumerator Load(string nameLevel)
    {
        loadingFon.transform.localPosition += new Vector3(0f, 3000f, 0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameLevel);

        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress;
            yield return null;
        }
    }
}
