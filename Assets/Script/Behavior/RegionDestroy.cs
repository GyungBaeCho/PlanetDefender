using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class RegionDestroy : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (RemovalCheck())
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        TailEmission tail = GetComponent<TailEmission>();
        if (tail)
        {
            tail.DestroyTail();
        }
        Destroy(transform.root.gameObject);
    }


    private bool RemovalCheck()
    {
        Vector2 bulletPosition = transform.position;
        Vector2 worldSize = GlobalVariable._worldCollider.size / 2;
        if (worldSize.x <= bulletPosition.x || bulletPosition.x <= -worldSize.x || worldSize.y <= bulletPosition.y || bulletPosition.y <= -worldSize.y)
        {
            return true;
        }
        return false;
    }
}
