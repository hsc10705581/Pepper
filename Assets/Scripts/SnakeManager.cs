using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{

    public Vector3 m_HeadPosition;  
    public int m_MaxLength = 9;     //最大长度
    public GameObject m_Body;
    public int m_PresentLength = 1;
    public int PresentX;    //记录当前在EM中x轴位置
    public int PresentY;    //同上

    private MapManager m_Map;
    private Vector3 UpMove = new Vector3(0, 1, 0);
    private Vector3 RightMove = new Vector3(1, 0, 0);
    private Quaternion ZeroQuaternion = new Quaternion(0, 0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        m_Map = GetComponent<MapManager>();
        // PresentX = int.Parse(transform.position.x.ToString()) + 10;
        // PresentY = int.Parse(transform.position.y.ToString()) + 5;
        PresentX = int.Parse(transform.position.x.ToString());
        PresentY = int.Parse(transform.position.y.ToString());
        m_HeadPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     if (Input.GetKeyDown(KeyCode.UpArrow) && m_PresentLength < m_MaxLength && m_Map.EasyMap[PresentX, PresentY + 1] == 0) 
        //     {
        //         PresentY++;
        //         m_PresentLength++;
        //         transform.position += UpMove;
        //         Instantiate(m_Body, m_HeadPosition, ZeroQuaternion);
        //         m_HeadPosition = transform.position;
        //         m_Map.EasyMap[PresentX, PresentY] = 1;
        //     }
        //     if (Input.GetKeyDown(KeyCode.DownArrow) && m_PresentLength < m_MaxLength && m_Map.EasyMap[PresentX, PresentY - 1] == 0)
        //     {
        //         PresentY--;
        //         m_PresentLength++;
        //         transform.position -= UpMove;
        //         Instantiate(m_Body, m_HeadPosition, ZeroQuaternion);
        //         m_HeadPosition = transform.position;
        //         m_Map.EasyMap[PresentX, PresentY] = 1;
        //     }
        //     if (Input.GetKeyDown(KeyCode.RightArrow) && m_PresentLength < m_MaxLength && m_Map.EasyMap[PresentX + 1, PresentY] == 0)
        //     {
        //         PresentX++;
        //         m_PresentLength++;
        //         transform.position += RightMove;
        //         Instantiate(m_Body, m_HeadPosition, ZeroQuaternion);
        //         m_HeadPosition = transform.position;
        //         m_Map.EasyMap[PresentX, PresentY] = 1;
        //     }
        //     if (Input.GetKeyDown(KeyCode.LeftArrow) && m_PresentLength < m_MaxLength && m_Map.EasyMap[PresentX - 1, PresentY] == 0)
        //     {
        //         PresentX--;
        //         m_PresentLength++;
        //         transform.position -= RightMove;
        //         Instantiate(m_Body, m_HeadPosition, ZeroQuaternion);
        //         m_HeadPosition = transform.position;
        //         m_Map.EasyMap[PresentX, PresentY] = 1;
        //     }
        // }
        if (Input.GetKey(KeyCode.Space) && m_PresentLength < m_MaxLength)
        {
            Vector3Int moveDir = Vector3Int.zero;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDir = new Vector3Int(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDir = new Vector3Int(0, -1, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDir = new Vector3Int(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDir = new Vector3Int(-1, 0, 0);
            }
            if (moveDir.magnitude == 0)
                return;
            if (MapManager.CanMoveOn(PresentX + moveDir.x, PresentY + moveDir.y))
            {
                PresentX += moveDir.x; PresentY += moveDir.y;
                m_PresentLength++;
                transform.position += moveDir;
                Instantiate(m_Body, m_HeadPosition, ZeroQuaternion);
                m_HeadPosition = transform.position;
                MapManager.AddObject(PresentX, PresentY, Cell.CellObjectType.SnakeBody);
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            m_PresentLength = 1;
        }
    }

    
}
