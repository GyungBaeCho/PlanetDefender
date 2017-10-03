using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class ObjectManager : MonoBehaviour {

    public GameObject[]         _arrEnemyPrefab;

    private List<GameObject>    _lstEnemy;
    private float               _fTimeCount = 0;
    private Vector2             _worldSize;

    // Use this for initialization
    void Start ()
    {
        _lstEnemy = new List<GameObject>();
        _worldSize = GlobalVariable._worldCollider.size / 2;
    }

    void CreateEnemy()
    {

        float fTime = 1;

        if (15 < _lstEnemy.Count)
        {
            return;
        }

        _fTimeCount += Time.deltaTime;

        if (fTime <= _fTimeCount)
        {
            _fTimeCount -= fTime;

            Vector2 newPosition = Vector2.zero;

            if (Random.Range(0, 2) == 0)
            {
                newPosition.x = _worldSize.x;
                if (Random.Range(0, 2) == 0)
                {
                    newPosition.x *= -1;
                }
                newPosition.y = Random.Range(0, _worldSize.y);
                if (Random.Range(0, 2) == 0)
                {
                    newPosition.y *= -1;
                }
            }
            else
            {
                newPosition.y = _worldSize.y;
                if (Random.Range(0, 2) == 0)
                {
                    newPosition.y *= -1;
                }
                newPosition.x = Random.Range(0, _worldSize.x);
                if (Random.Range(0, 2) == 0)
                {
                    newPosition.x *= -1;
                }
            }

            _lstEnemy.Add(Instantiate(_arrEnemyPrefab[0], newPosition, Quaternion.identity));
        }
    }

	// Update is called once per frame
	void Update ()
    {
        CreateEnemy();

        for (int i = 0; i < _lstEnemy.Count; ++i)
        {
            if (_lstEnemy[i] == null)
            {
                _lstEnemy.RemoveAt(i);
            }
        }

    }
}
