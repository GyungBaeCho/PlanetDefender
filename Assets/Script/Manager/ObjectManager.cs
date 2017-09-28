using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public GameObject[]         _enmeyPerfab;

    private List<GameObject>    _lstEnemy;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //float plusAlpha = 100;
        //Screen.width + plusAlpha <= bulletScreenPos.x || bulletScreenPos.x <= -plusAlpha || Screen.height + plusAlpha <= bulletScreenPos.y || bulletScreenPos.y <= -plusAlpha;

        float x = Random.Range(0, 1.0f);
        float y = Random.Range(0, 1.0f);

        //_lstEnemy.Add((GameObject)Instantiate(_enmeyPerfab[0], new Vector3(100, 100), Quaternion.identity));


    }
}
