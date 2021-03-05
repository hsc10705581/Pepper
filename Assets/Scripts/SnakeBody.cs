using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject SnakeHead;
    public int PresentX;
    public int PresentY;
    // Start is called before the first frame update
    void Start()
    {
        SnakeHead = GameObject.Find("SnakeHead");
        // PresentX = int.Parse(transform.position.x.ToString()) + 10;
        // PresentY = int.Parse(transform.position.y.ToString()) + 5;
        PresentX = int.Parse(transform.position.x.ToString());
        PresentY = int.Parse(transform.position.y.ToString());
        MapManager.AddObject(PresentX, PresentY, Cell.CellObjectType.SnakeBody);
    }

    // Update is called once per frame
    void Update()
    {
        DestroySelf();
    }
    void DestroySelf()
    {
        if (Input.GetKeyUp(KeyCode.Space))      //松开空格即缩短，即销毁自身
        {
            // SnakeHead.GetComponent<MapManager>().EasyMap[PresentX, PresentY] = 0;
            MapManager.RemoveObject(PresentX, PresentY);
            Destroy(gameObject);
        }
    }
}
