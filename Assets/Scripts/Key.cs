using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int PresentX;
    public int PresentY;
    public string Sign;     //部分密码

    //public GameObject Door;
    public SnakeManager SnakeHead;
    public int m_Status = 0;    //判断蛇头是否与自身位置重叠
    // Start is called before the first frame update
    void Start()
    {
        SnakeHead = GameObject.Find("SnakeHead").GetComponent<SnakeManager>();
        PresentX = int.Parse(transform.position.x.ToString()) + 10;
        PresentY = int.Parse(transform.position.y.ToString()) + 5;
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
            GetComponentInParent<KeyManager>().m_Password += Sign;
            GetComponentInParent<KeyManager>().BoxNumber++;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Key>().enabled = false;
            m_Status = 1;
        }
    }
}
