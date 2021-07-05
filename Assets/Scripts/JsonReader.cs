using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset textJson;
    public TextAsset ingredientsTextJson;

    [System.Serializable]
    public class Index
    {
        public int index;
        public string firstPage;
        public string secondPage;
        public int gold;
        public int specialcode;
    }

    [System.Serializable]
    public class IngredientText
    {
        public int index;
        public string textdata;
        public string scentdata;
    }

    [System.Serializable]
    public class IndexList
    {
        public Index[] cookIndex;
    }

    [System.Serializable]
    public class IngredientTestList
    {
        public IngredientText[] IngredientData;
    }

    public IndexList myIndexList = new IndexList();
    public IngredientTestList myingredientList = new IngredientTestList();

    void Start()
    {
        myIndexList = JsonUtility.FromJson<IndexList>(textJson.text);
        myingredientList = JsonUtility.FromJson<IngredientTestList>(ingredientsTextJson.text);
    }


}
