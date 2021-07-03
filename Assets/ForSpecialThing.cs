using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForSpecialThing : MonoBehaviour
{
    public GameObject[] specialObject;
    GameObject nowActive = null;

    public void ChangeSpecialObject(int index)
    {
        for (int i=0; i< specialObject.Length; i++)
        {
            specialObject[i].SetActive(false);
        }
        specialObject[index].SetActive(true);

    }

}
