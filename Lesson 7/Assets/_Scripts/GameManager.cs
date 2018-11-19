using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject _apple;
    public Text UItext;

    public static GameManager _instance = null;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Spawn();
        TextShow();
    }

    public void Spawn()
    {
        Instantiate(_apple, new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0f), Quaternion.identity);
    }

    public void TextShow()
    {
        UItext.text = "Apples: " + Static.count;
    }
}
