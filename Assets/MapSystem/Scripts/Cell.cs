using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell  // 地图单元格类
{
    public enum CellObjectType  // 单元格上物体的类型
    {
        Empty, Key, SnakeBody, Door, LongerBox
    }
    public int id { get; protected set; }  // 单元格id. id = y * col + x
    public Vector3 position { get; protected set; }  // 单元格位置
    public CellObjectType cellObject { get; protected set; } = CellObjectType.Empty;  //单元格上的物体类型
    protected Cell up, down, left, right;  // 周围单元格指针

    public Cell()
    {
    }
    public Cell(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }

    public bool CanMoveOn()  // 判断单元格能否移动
    {
        if (cellObject == CellObjectType.Empty || 
            cellObject == CellObjectType.Key || 
            cellObject == CellObjectType.LongerBox)
        {
            return true;
        }
        return false;
    }

    public void AddObject(CellObjectType type)  // 添加物体
    {
        this.cellObject = type;
    }

    public void RemoveObject()  // 移除物体
    {
        this.cellObject = CellObjectType.Empty;
    }
}
