using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region vars

    public float speed = 0.1f;
    public float rotationSpeed = 25f;
    public GameObject parts;

    [HideInInspector]

    private float offset = 0.3f;
    #endregion

    #region UnityMethods

    void Start()
    {

        GameManager._instance.snakeParts.Add(gameObject);
    }


    void Update()
    {
        Move();
    }

    #endregion

    #region Controller

    private void Move()
    {
        Vector2 move = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.D)) { transform.position += new Vector3(0.3f, 0, 0); GameManager._instance.Move(); GetComponent<Tail>().oldPos = transform.position; }
        else if (Input.GetKeyDown(KeyCode.A)) { transform.position -= new Vector3(0.3f, 0, 0); GameManager._instance.Move(); GetComponent<Tail>().oldPos = transform.position; }
        else if (Input.GetKeyDown(KeyCode.W)) { transform.position += new Vector3(0, 0.3f, 0); GameManager._instance.Move(); GetComponent<Tail>().oldPos = transform.position;  }
        else if (Input.GetKeyDown(KeyCode.S)) { transform.position -= new Vector3(0, 0.3f, 0); GameManager._instance.Move(); GetComponent<Tail>().oldPos = transform.position; }
        
    }

    public void AddTail()
    {
        Vector3 loc = new Vector3(GameManager._instance.snakeParts[GameManager._instance.snakeParts.Count - 1].transform.position.x - offset, GameManager._instance.snakeParts[GameManager._instance.snakeParts.Count - 1].transform.position.y);
        GameManager._instance.snakeParts.Add(Instantiate(parts, loc, Quaternion.identity));
    }
    #endregion

}
