using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectManager : MonoBehaviour
{
    public static CollectManager instance;
    public Text collect;
    int collects = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {  
        collect.text = collects.ToString() + "/3"; 
    }
    public void addCollect()
    {
        if (collects == 2)
        {
            collect.color = new Color(0.1395805f, 0.8867924f, 0);
        }
        collects += 1;
        collect.text = collects.ToString() + "/3";
    }
}
