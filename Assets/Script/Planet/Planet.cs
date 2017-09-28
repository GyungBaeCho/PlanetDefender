using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public int              _nMaxTower;
    public GameObject[]     _arrTowerPrefab;

    private BoxCollider2D   _boxCollider;
    private GameObject[]    _arrTower;
    private int             _pvtIndex;

    // Use this for initialization
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();

        float fAngle = 360.0f/_nMaxTower;

        _arrTower = new GameObject[_nMaxTower];

        for (int i = 0; i<_nMaxTower ;++i) {
            _arrTower[i] = (GameObject)Instantiate(_arrTowerPrefab[i%_arrTowerPrefab.Length], transform.position, transform.rotation);

            float fHeight = 170;
            //fHeight += arrTowerPrefab[i % arrTowerPrefab.Length].GetComponent<SpriteRenderer>().sprite.textureRect.height/2;
            _arrTower[i].transform.position += new Vector3(0, fHeight, 0);
            _arrTower[i].transform.RotateAround(transform.position, new Vector3(0, 0, 1), fAngle * i);
        }

        _pvtIndex = 0;
    }

    //// Update is called once per frame
    void Update()
    {

    }

    public void SwitchTower()
    {
        _pvtIndex++;
        if (_arrTower.Length - 1 < _pvtIndex)
        {
            _pvtIndex = 0;
        }
    }

    public void RevoluteTower(float fDegree)
    {
        _arrTower[_pvtIndex].transform.RotateAround(transform.position, new Vector3(0, 0, 1), fDegree / 100);
    }

    GUIStyle style = new GUIStyle();
    void OnGUI()
    {
        style.normal.textColor = Color.white;
        style.fontSize = 100;
        ToString();
        GUI.Label(new Rect(0, 0, 1000, 100), _arrTower[_pvtIndex].transform.rotation.ToString(), style);
        GUI.Label(new Rect(0, 100, 1000, 100), _arrTower[_pvtIndex].transform.position.ToString(), style);
    }
}
