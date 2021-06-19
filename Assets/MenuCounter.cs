using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCounter : MonoBehaviour
{
    public int thisMenuCode;
    public int counter = 0;
    public GameObject[] counterSprite;
    public int selectedMenuCode;


    public void thisClick(int code)
    {
        if (selectedMenuCode != code)
        {
            ResetCounter();
            selectedMenuCode = code;
            Count();
        }
        else
        {
            if (counter < 3)
                Count();
            else if (counter == 3)
            {
                ResetCounter();
            }
        }
    }

    public void Count()
    {
        counterSprite[counter].SetActive(true);
        counter++;
    }

    public void ResetCounter()
    {
        counter = 0;

        foreach (GameObject x in counterSprite)
        {
            x.SetActive(false);
        }

    }
}
