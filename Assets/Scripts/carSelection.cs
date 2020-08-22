 using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class carSelection : MonoBehaviour
{
    //We create an empty list of gameobjects
    private GameObject[] carList;
    private int currentCar = 0;
    void Start()
    {
        carList = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; ++i)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject gameObj in carList)
        {
            gameObj.SetActive(false);
        }
        if (carList[0])
        {
            carList[0].SetActive(true);
            if (carList[0].name == "myLamboConvert")
            {
                carList[0].GetComponent<Animator>().SetTrigger("intro");
                GameObject cloudSystem = Instantiate(Resources.Load("cloudParticle")) as GameObject;
                ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
                cloudPuff.Play();
                cloudPuff.transform.position = new Vector3(22f, -0.5f, 0f);
                Destroy(cloudSystem, 2f);
            }
        }
    }

   public void toggleCars(string direction)
    {
        carList[currentCar].SetActive(false);

        if (direction == "Right")
        {
            currentCar++;
            if(currentCar > carList.Length - 1)
            {
                currentCar = 0;
            }
        }
        else if(direction=="Left")
        {
            currentCar--;
            if (currentCar < 0)
            {
                currentCar = carList.Length - 1;
            }
        }
        carList[currentCar].SetActive(true);
        if (carList[currentCar].name == "myLamboConvert")
        {
            carList[currentCar].GetComponent<Animator>().SetTrigger("intro");
        }
        gameController.currentSelectedCar = carList[currentCar].name;
        GameObject cloudSystem = Instantiate(Resources.Load("cloudParticle")) as GameObject;
        ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
        cloudPuff.Play();
        cloudPuff.transform.position = new Vector3(22f, -0.5f, 0f);
        Destroy(cloudSystem, 2f);
    }
}
