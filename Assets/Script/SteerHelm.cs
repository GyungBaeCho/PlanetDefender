using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SteerHelm : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image           _bgImg;
    private Vector2         _prePos = Vector2.zero;
    private bool            _bFirstTouch = true;
    private bool            _bBeingTouched = false;
    private float           _fDegree = 0;
    private float           _fRotatingPower = 0;

    public float            _fFriction;
    public float            _fTouchFriction;
    public Planet           _planet;

    // Use this for initialization
    void Start () {
        _bgImg = GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            if (_bFirstTouch)
            {
               _bFirstTouch = false;
            }
            else
            {
                Vector2 vCenter = RectTransformUtility.WorldToScreenPoint(ped.pressEventCamera, transform.position);
                Vector2 vNew = (ped.position - vCenter).normalized;
                Vector2 vPre = (_prePos - vCenter).normalized;

                //두 벡터 사이각도를 구하기 위함
                float fDot = Vector2.Dot(vNew, vPre);
                _fDegree = Mathf.Acos(fDot) * Mathf.Rad2Deg;

                //외적을 통한 Z값 추출(회전 방향)
                if (((vNew.x * vPre.y) - (vNew.y * vPre.x)) > 0) {
                    _fDegree = -_fDegree;
                }
                
                transform.Rotate(0, 0, _fDegree);
            }
            _prePos = ped.position;
            
            //Planet이 현재 조종하는 Tower를 회전시킵니다.
            _planet.RevoluteTower(_fDegree);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        _bBeingTouched = true;
    }

    //터치를 중지했을때 firstThouch 초기화
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _bFirstTouch = true;
        _bBeingTouched = false;
        if (_fRotatingPower == 0)
        {
            _fRotatingPower = _fDegree * 20;
        }
        _fDegree = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (0 < Mathf.Abs(_fRotatingPower))
        {
            float sign = Mathf.Sign(_fRotatingPower);
            float fFrictionPower = -sign * Time.deltaTime;
            if (_bBeingTouched)
            {
                fFrictionPower *= _fTouchFriction;
            }
            else
            {
                fFrictionPower *= _fFriction;
            }

            _fRotatingPower += fFrictionPower;
            if (sign < 0)
            {
                if (0 < _fRotatingPower)
                {
                    _fRotatingPower = 0;
                }
            }
            else
            {
                if (_fRotatingPower < 0)
                {
                    _fRotatingPower = 0;
                }
            }

            _planet.RevoluteTower(_fRotatingPower/10);
            transform.Rotate(0, 0, _fRotatingPower * Time.deltaTime);   
        }
    }

    public float GetDegree()
    {
        return _fDegree;
    }
}




/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SteerHelm : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image           bgImg;
    private Vector2         prePos;
    private bool            firstTouch;
    private float           fDegree;

    public Planet           planet;

    // Use this for initialization
    void Start () {
        bgImg = GetComponent<Image>();
        firstTouch = true;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            if (firstTouch)
            {
               firstTouch = false;
            }
            else
            {
                Vector2 vCenter = RectTransformUtility.WorldToScreenPoint(ped.pressEventCamera, transform.position);
                Vector2 vNew = (ped.position - vCenter).normalized;
                Vector2 vPre = (prePos - vCenter).normalized;

                //두 벡터 사이각도를 구하기 위함
                float fDot = Vector2.Dot(vNew, vPre);
                fDegree = Mathf.Acos(fDot) * Mathf.Rad2Deg;

                //외적을 통한 Z값 추출(회전 방향)
                if (((vNew.x * vPre.y) - (vNew.y * vPre.x)) > 0) {
                    fDegree = -fDegree;
                }
                
                transform.Rotate(0, 0, fDegree);
            }
            prePos = ped.position;
            
            //Planet이 현재 조종하는 Tower를 회전시킵니다.
            planet.RevoluteTower(fDegree);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    //터치를 중지했을때 firstThouch 초기화
    public virtual void OnPointerUp(PointerEventData ped)
    {
        firstTouch = true;
        fDegree = 0;
    }

    public float GetDegree()
    {
        return fDegree;
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
}
 
*/
