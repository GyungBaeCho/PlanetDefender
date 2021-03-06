﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

namespace GlobalVar
{
    class GlobalVariable
    {
        //Prefab Dictionary
        public static Dictionary<string, GameObject> _dicPrefabs = new Dictionary<string, GameObject>();
        public static BoxCollider2D _worldCollider;

        public static float _minZoom;
        public static float _maxZoom;
        //public static string str = "PublicVariable";    // 정적필드에 대한 참조시 전역변수로 호출시 #1
        //public string str = "PublicVariable";    // 동적필드에 대한 참조시 인스턴스로 호출시 #2

        public static void Initialize()
        {
            _dicPrefabs.Clear();
        }

        public static bool IsInZone(Vector2 targetPosition)
        {
            if (!_worldCollider)
            {
                return false;
            }
            
            Vector2 worldSize = _worldCollider.size / 2;
            if (worldSize.x <= targetPosition.x || targetPosition.x <= -worldSize.x || worldSize.y <= targetPosition.y || targetPosition.y <= -worldSize.y)
            {
                return true;
            }
            return false;
        }
    }
}

public class PlayScene : MonoBehaviour
{
    // Use this for initialization
    void Start () {
        //화면 꺼짐 방지
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        GlobalVariable.Initialize();
        GlobalVariable._worldCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

    }
}
