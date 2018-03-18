using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInstance : MonoBehaviour {
    public GameObject[] _collisionPerfabs;

    private List<GameObject> _lstInstance = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        foreach (GameObject pvtPrefab in _collisionPerfabs)
        {
            GameObject newObject = Instantiate(pvtPrefab, transform.position, transform.rotation);
            //newObject.transform.parent = transform;
            newObject.transform.SetParent(transform, true);

            _lstInstance.Add(newObject); ;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        foreach (GameObject pvtObject in _lstInstance)
        {
            Destroy(pvtObject);
        }

    }
}
