using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public int              _nMaxTower;
    public GameObject[]     _arrTowerPrefab;

    private GameObject[]    _arrTower;
    private int             _pvtIndex;

    // Use this for initialization
    void Start()
    {
        float fAngle = 360.0f/_nMaxTower;

        _arrTower = new GameObject[_nMaxTower];

        for (int i = 0; i < _nMaxTower; ++i)
        {
            GameObject newTower = (GameObject)Instantiate(_arrTowerPrefab[i % _arrTowerPrefab.Length], transform.position, transform.rotation);

            float fHeight = 2.5f;
            //fHeight += arrTowerPrefab[i % arrTowerPrefab.Length].GetComponent<SpriteRenderer>().sprite.textureRect.height/2;

            newTower.transform.position += new Vector3(0, fHeight, 0);
            newTower.transform.RotateAround(transform.position, new Vector3(0, 0, 1), fAngle * i);

            //Planet의 상위 객체의 Child로 만들어주는 작업(이를 통해 Planet이 회전할때 Tower도 같이 회전한다)
            newTower.transform.parent = gameObject.transform;

            //Planet에서 관리하는 Tower List
            _arrTower[i] = newTower;
        }
        _pvtIndex = 0;
    }

    //// Update is called once per frame
    void Update()
    {
//        transform.Rotate(0, 0, 360 * Time.deltaTime);
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
        //_arrTower[_pvtIndex].transform.RotateAround(transform.position, new Vector3(0, 0, 1), fDegree / 100);

        //if (System.Single.IsNaN(_arrTower[_pvtIndex].transform.position.x))
        //{
        //    print("Shit!");
        //}

        transform.Rotate(0, 0, fDegree / 100);

    }

    GUIStyle style = new GUIStyle();
    void OnGUI()
    {
        //style.normal.textColor = Color.white;
        //style.fontSize = 100;
        //ToString();
        //GUI.Label(new Rect(0, 0, 1000, 100), _arrTower[_pvtIndex].transform.rotation.ToString(), style);
        //GUI.Label(new Rect(0, 100, 1000, 100), _arrTower[_pvtIndex].transform.position.ToString(), style);
    }
}
