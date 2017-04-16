using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActions : MonoBehaviour {


    public GameObject CanvasHome;
    public GameObject CanvasPause;
    public GameObject CanvasGame;


    public void SetHomeFalse()
    {
        CanvasHome.SetActive(false);
    }

    public void SetPauseOn()
    {
        CanvasPause.SetActive(true);
        CanvasGame.SetActive(false);
    }

    public void SetPauseOff()
    {
        CanvasPause.SetActive(false);
        CanvasGame.SetActive(true);
    }
}
