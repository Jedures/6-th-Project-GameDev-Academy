using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
             Static.count++;
             GameManager._instance.Spawn();
             Destroy(gameObject);
             GameManager._instance.TextShow();
        }
    }
}
