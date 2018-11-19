using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region vars

    public float speed = 5f;

    public GameObject parts;
    

    private Rigidbody2D rb;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        Static.LoadCount();   
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }

    #endregion

    #region Controller

    private void Move()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = move * speed * Time.deltaTime;
        CheckDistance();
    }

    private void CheckDistance()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x > 0.99 || viewPos.x < 0.01 || viewPos.y > 0.99 || viewPos.y < 0.01) Death();
    }

    public void Death()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    #endregion

    #region OtherFunctions
    private void OnApplicationQuit()
    {
        Static.SaveCount();
    }
    #endregion

}
