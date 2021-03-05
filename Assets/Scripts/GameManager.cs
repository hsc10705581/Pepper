using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        MapManager.Init(21, 11);
    }
    private void Start() {
    }
}
