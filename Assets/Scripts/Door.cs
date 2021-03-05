using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int PresentX;        //记录EM位置
    public int PresentY;
    private void Start()
    {
        // PresentX = int.Parse(transform.position.x.ToString()) + 10;
        // PresentY = int.Parse(transform.position.y.ToString()) + 5;
        PresentX = int.Parse(transform.position.x.ToString());
        PresentY = int.Parse(transform.position.y.ToString());
        MapManager.AddObject(PresentX, PresentY, Cell.CellObjectType.Door);  // 单元格添加物体
    }
}
