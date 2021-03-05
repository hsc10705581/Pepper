using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int[,] EasyMap = new int[21, 11];    //简易地图管理器，即二维数组，之后简称EM
    public Transform[] Blocks;                  //障碍物位置
                                                //之后可以修改二维数组的元素来记录地图中不同的道具类型
    // Start is called before the first frame update
    void Start()                                
    {
        for (int i = 0; i < 21; i++)        //中心点（0，0，0），在EM中为（10，5），其他点以此类推
        {
            for (int j = 0; j < 11; j++)
            {
                if (i == 0 || i == 20 || j == 0 || j == 10)
                    EasyMap[i, j] = 1;
                else
                    EasyMap[i, j] = 0;
            }
        }
        EasyMap[10, 5] = 1; //游戏开始时蛇头位置
        for (int i = 0; i < Blocks.Length; i++) //记录游戏中障碍的位置
        {
            int tempX = int.Parse(Blocks[i].position.x.ToString()) + 10;
            int tempY = int.Parse(Blocks[i].position.y.ToString()) + 5;
            EasyMap[tempX, tempY] = 1;
        }
    }
}
