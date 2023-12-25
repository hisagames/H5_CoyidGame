using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject treasure;
  
    public void showTreasure()
    {
        treasure.SetActive(true); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CollectManager.instance.addCollect();
            Destroy(gameObject);
        }

    }
}