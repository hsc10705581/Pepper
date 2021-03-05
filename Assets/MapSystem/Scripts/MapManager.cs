using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MapManager : MonoBehaviour
// {
//     public int[,] EasyMap = new int[21, 11];    //简易地图管理器，即二维数组，之后简称EM
//     public Transform[] Blocks;                  //障碍物位置
//                                                 //之后可以修改二维数组的元素来记录地图中不同的道具类型
//     // Start is called before the first frame update
//     void Start()                                
//     {
//         for (int i = 0; i < 21; i++)        //中心点（0，0，0），在EM中为（10，5），其他点以此类推
//         {
//             for (int j = 0; j < 11; j++)
//             {
//                 if (i == 0 || i == 20 || j == 0 || j == 10)
//                     EasyMap[i, j] = 1;
//                 else
//                     EasyMap[i, j] = 0;
//             }
//         }
//         EasyMap[10, 5] = 1; //游戏开始时蛇头位置
//         for (int i = 0; i < Blocks.Length; i++) //记录游戏中障碍的位置
//         {
//             int tempX = int.Parse(Blocks[i].position.x.ToString()) + 10;
//             int tempY = int.Parse(Blocks[i].position.y.ToString()) + 5;
//             EasyMap[tempX, tempY] = 1;
//         }
//     }
// }

public class MapManager : MonoBehaviour
{
    public enum Direction
    {
        Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight
    };
    public static MapManager instance;  // 单例模式
    public static Cell[,] world;  // 保存所有地图单元格

    public static int col, row;  // 地图长、宽

    #region Init
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    public static void Init(int col, int row)  // 初始化地图
    {
        MapManager.col = col;
        MapManager.row = row;
        world = new Cell[col, row];
        // 新建所有cell
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                world[x, y] = new Cell(Position2ID(x, y), new Vector3(x, y));
            }
        }
    }
    #endregion

    #region ID & position
    public static Vector2Int ID2Position(int id)
    {
        //return new Vector2Int(id / instance.size, id % instance.size);
        return new Vector2Int(id % col, id / col);
    }
    public static int Position2ID(int x, int y)
    {
        x = Mathf.Clamp(x, 0, col - 1);
        y = Mathf.Clamp(y, 0, row - 1);
        //return x * instance.size + y;
        return y * col + x;
    }
    public static int Position2ID(Vector2Int vector2)
    {
        return Position2ID(vector2.x, vector2.y);
    }
    public static bool IDValid(int id)
    {
        return id >= 0 && id < col * row;
    }
    #endregion

    #region SafeGetCell
    public static Cell SafeGetCell(Vector2Int vector2)
    {
        return SafeGetCell(vector2.x, vector2.y);
    }
    public static Cell SafeGetCell(int x, int y)
    {
        if (x < 0 || x >= col || y < 0 || y >= row)
            return null;
        return world[x, y];
    }
    public static Cell SafeGetCell(int id)
    {
        return SafeGetCell(ID2Position(id));
    }
    #endregion

    #region AddObject & RemoveObject
    public static void AddObject(Cell cell, Cell.CellObjectType type)
    {
        if (cell != null) cell.AddObject(type);
    }
    public static void AddObject(Vector2Int vector2, Cell.CellObjectType type)
    {
        AddObject(SafeGetCell(vector2), type);
    }
    public static void AddObject(int x, int y, Cell.CellObjectType type)
    {
        AddObject(SafeGetCell(x, y), type);
    }
    public static void AddObject(int id, Cell.CellObjectType type)
    {
        AddObject(SafeGetCell(id), type);
    }
    public static void RemoveObject(Cell cell)
    {
        if (cell != null) cell.RemoveObject();
    }
    public static void RemoveObject(Vector2Int vector2)
    {
        RemoveObject(SafeGetCell(vector2));
    }
    public static void RemoveObject(int x, int y)
    {
        RemoveObject(SafeGetCell(x, y));
    }
    public static void RemoveObject(int id)
    {
        RemoveObject(SafeGetCell(id));
    }
    #endregion

    #region CanMoveOn
    public static bool CanMoveOn(Cell cell)
    {
        if (cell != null)
            return cell.CanMoveOn();
        return false;
    }
    public static bool CanMoveOn(Vector2Int vector2)
    {
        return CanMoveOn(SafeGetCell(vector2));
    }
    public static bool CanMoveOn(int x, int y)
    {
        return CanMoveOn(SafeGetCell(x, y));
    }
    public static bool CanMoveOn(int id)
    {
        return CanMoveOn(SafeGetCell(id));
    }
    #endregion
}
