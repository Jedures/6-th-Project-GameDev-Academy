using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager _instance = null;
    public List<GameObject> snakeParts = new List<GameObject>();
    public Text text;
    public GameObject apple;

    [Header("Borders")]
    public GameObject lBorder;
    public GameObject rBorder;
    public GameObject uBorder;
    public GameObject dBorder;

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

    public void Move()
    {
        if (snakeParts.Count > 1)
        {
            for (int i = 1; i < snakeParts.Count; i++)
                snakeParts[i].transform.position = snakeParts[i - 1].GetComponent<Tail>().oldPos;
            foreach (GameObject n in snakeParts) n.GetComponent<Tail>().oldPos = n.transform.position;

            GameObject gm = null;
            for (int i = 1; i < snakeParts.Count; i++)
                if (snakeParts[0].transform.position == snakeParts[i].transform.position) gm = snakeParts[i];

            if (gm != null)
            {
                int index = GameManager._instance.snakeParts.IndexOf(gm);
                Debug.Log(snakeParts.Count + " " + index);
               
                for (int i = GameManager._instance.snakeParts.Count-1; i >= index-1; i--)
                {
                    Destroy(GameManager._instance.snakeParts[i]); GameManager._instance.snakeParts.Remove(GameManager._instance.snakeParts[i]);
                }

                TextShow();
            }
        }
    }

    public void TextShow()
    {
        text.text = "Довжина: " + snakeParts.Count;
    }

    public void Spawn()
    {
        Instantiate(apple, new Vector3(Random.Range(lBorder.transform.position.x + 0.1f, rBorder.transform.position.x - 0.1f), Random.Range(dBorder.transform.position.y + 0.1f, uBorder.transform.position.y - 0.1f)), Quaternion.identity);
    }
}
