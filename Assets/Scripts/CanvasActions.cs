using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasActions : MonoBehaviour {


    public GameObject CanvasHome;
    public GameObject CanvasPause;
    public GameObject CanvasGame;

    public GameObject PopUpQuit;


    public void SetHomeFalse()
    {
        CanvasHome.SetActive(false);
    }

    public void SetPauseOn()
    {
        CanvasPause.SetActive(true);
        CanvasHome.SetActive(false);
        CanvasGame.SetActive(false);
        PopUpQuit.SetActive(false);
    }

    public void SetPauseOff()
    {
        CanvasPause.SetActive(false);
        CanvasGame.SetActive(true);
    }

    public void DisplayPopUp ()
    {
        PopUpQuit.SetActive(true);
    }

    public void HidePopUp()
    {
        PopUpQuit.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SetPauseOn();
        }
    }

}
