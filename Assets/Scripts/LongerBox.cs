using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongerBox : MonoBehaviour      //直接修改蛇的MaxLength
{
    public SnakeManager SnakeHead;

    public int PresentX;
    public int PresentY;
    // Start is called before the first frame update
    void Start()
    {
        SnakeHead = GameObject.Find("SnakeHead").GetComponent<SnakeManager>();

    }
    private void Awake()
    {
        // PresentX = int.Parse(transform.position.x.ToString()) + 10;
        // PresentY = int.Parse(transform.position.y.ToString()) + 5;
        PresentX = int.Parse(transform.position.x.ToString());
        PresentY = int.Parse(transform.position.y.ToString());
        MapManager.AddObject(PresentX, PresentY, Cell.CellObjectType.LongerBox);  // 单元格添加物体
    }

    // Update is called once per frame
    void Update()
    {
        DestroySelf();
    }
    private void DestroySelf()
    {
        if (SnakeHead.PresentX == PresentX && SnakeHead.PresentY == PresentY) 
        {
            SnakeHead.m_MaxLength += 2;
            MapManager.RemoveObject(PresentX, PresentY);
            Destroy(gameObject);
        }
    }
}
