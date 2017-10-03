using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GlobalVar;

public class SideBlind : MonoBehaviour {
    private SpriteRenderer  _spriteRenderer;
    private float           _initAlpah;

	// Use this for initialization
	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initAlpah = _spriteRenderer.color.a;
    }
	
	// Update is called once per frame
	void Update () {
        float newAlpha = _initAlpah * (Camera.main.orthographicSize - GlobalVariable._minZoom) / (GlobalVariable._maxZoom - GlobalVariable._minZoom);
        _spriteRenderer.color = new Color(1, 1, 1, newAlpha);
    }
}
