using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject player;
    public bool rightClick = false;

    void Awake()
    {
        player = GameObject.Find("Player");
        if(GameController.instance == null){
            GameController.instance = this;
        }else if (GameController.instance != this){
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 corresponds to the right mouse button
        {
            rightClick = true;
        }else if(Input.GetMouseButtonUp(1)){
            rightClick = false;
        }
    }

    void OnDestroy()
    {
        if(GameController.instance == this){
            GameController.instance = null;
        }
    }
}
