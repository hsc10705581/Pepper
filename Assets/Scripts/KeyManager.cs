using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [HideInInspector]public string m_Password;  //通过踩key获得密码开门，此变量代表当前已经踩到的密码
    public string SetPassword;                  //设置密码
    public GameObject Door;                     
    public SnakeManager SnakeHead;
    public int BoxNumber = 0;                   //已经踩到的key的数量

    private bool FalseOpening = false;          //密码错误判定
    private int SpecialChild = -1;              //踩到的最近一个key（子对象）
    // Start is called before the first frame update
    void Start()
    {
        SnakeHead = GameObject.Find("SnakeHead").GetComponent<SnakeManager>();
        m_Password = "0";                       //初始化为“0”
    }

    // Update is called once per frame
    void Update()
    {
        OpentheDoor();
    }
    private void OpentheDoor()
    {
        SpecialChild = m_Password[BoxNumber] - '0';
        if (m_Password.Length == 4 && m_Password == SetPassword)
        {
            // SnakeHead.GetComponent<MapManager>().EasyMap[Door.GetComponent<Door>().PresentX, Door.GetComponent<Door>().PresentY] = 0;
            MapManager.RemoveObject(Door.GetComponent<Door>().PresentX, Door.GetComponent<Door>().PresentY);
            Destroy(Door);
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            Destroy(gameObject);
        }
        else if (m_Password.Length == 4)
        {
            FalseOpening = true;
        }
        if (FalseOpening || (Input.GetKeyUp(KeyCode.Space) && m_Password.Length > 1)) 
        {
            KeyReset();
        }
    }
    private void KeyReset()
    {
        GameObject temp = transform.GetChild(SpecialChild - 1).gameObject;
        if (temp.GetComponent<Key>().PresentX != SnakeHead.PresentX || temp.GetComponent<Key>().PresentY != SnakeHead.PresentY) 
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.GetChild(i).gameObject.GetComponent<Key>().enabled = true;
                transform.GetChild(i).gameObject.GetComponent<Key>().m_Status = 0;
            }
            FalseOpening = false;
            SpecialChild = -1;
            BoxNumber = 0;
            m_Password = "0";
        }
    }
}
