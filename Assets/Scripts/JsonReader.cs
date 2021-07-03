using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset textJson;

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
    public class IndexList
    {
        public Index[] cookIndex;
    }

    public IndexList myIndexList = new IndexList();


    // Start is called before the first frame update
    void Start()
    {
        myIndexList = JsonUtility.FromJson<IndexList>(textJson.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
