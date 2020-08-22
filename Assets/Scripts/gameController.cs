using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public static string currentSelectedCar= "myLamboConvert";
    // Start is called before the first frame update
    void Start()
    {
        
    }



    //Add to GameController

    public void showNewCar(string nextCar)
    {
        GameObject.Find(colourSwitcher.instance.getCurrentTracked().name + "/activeItems/" + gameController.currentSelectedCar).SetActive(false);
        currentSelectedCar = nextCar;
        GameObject.Find(colourSwitcher.instance.getCurrentTracked().name + "/activeItems/" + gameController.currentSelectedCar).SetActive(true);
    }



    public void quit()
    {
        Application.Quit();
    }

    public void changeLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        print(currentSelectedCar);
    }
}
