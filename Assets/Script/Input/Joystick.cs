using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image       _bgImg;
    private Image       _joystickImg;
    private Vector3     _inputVector;
    private float       _fMinAlpha = 0.1f;

    // Use this for initialization
    void Start() {
        _bgImg = GetComponent<Image>();
        _joystickImg = transform.GetChild(0).GetComponent<Image>();

        //투명화
        _bgImg.CrossFadeAlpha(_fMinAlpha, 0.5f, true);
        _joystickImg.CrossFadeAlpha(_fMinAlpha, 0.5f, true);
    }

    /*
        ScreenPointToLocalPointInRectangle : pos <- 터치된 로컬좌표값 할당
    */
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
            // bgImg 내부 로컬 좌표를 bgImg Size로 나눔으로써
            // x는 0 ~ -1, y는 0 ~ 1로 변환한다.
            pos.x = (pos.x / _bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgImg.rectTransform.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            //터치된 지점으로 Joystick Img 이동
            _joystickImg.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (_bgImg.rectTransform.sizeDelta.x / 3),
                                                                     _inputVector.y * (_bgImg.rectTransform.sizeDelta.y / 3));
        }
    }

    //터치 중에 Ondrag() 실행
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);

        //불투명화
        _bgImg.CrossFadeAlpha(1, 0.5f, true);
        _joystickImg.CrossFadeAlpha(1, 0.5f, true);
    }

    //터치를 중지했을때, inputVector와 Joystick 초기화.
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector3.zero;
        _joystickImg.rectTransform.anchoredPosition = Vector3.zero;

        //투명화
        _bgImg.CrossFadeAlpha(_fMinAlpha, 0.5f, true);
        _joystickImg.CrossFadeAlpha(_fMinAlpha, 0.5f, true);
    }

    public float GetHorizontalValue()
    {
        return _inputVector.x;
    }

    public float GetVerticalValue()
    {
        return _inputVector.y;
    }

    // Update is called once per frame
    void Update () {

	}
}
