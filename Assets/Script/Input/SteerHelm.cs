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

    private int             _idxDegree;
    private float[]         _arrDegree;

    private float           _fDegree = 0;

    private float           _fRotatingPower = 0;

    public float            _fMinAlpha = 0.1f;
    public float            _fMaxAlpha = 0.7f;
    public float            _fAlphaDurationTime = 0.5f;

    public float            _fFriction;
    public float            _fTouchFriction;
    public Planet           _planet;


    // Use this for initialization
    void Start ()
    {
        _bgImg = GetComponent<Image>();
        _arrDegree = new float[1];
        _idxDegree = 0;
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
                _fDegree = CalculateDegree(vCenter, vNew, vPre);

                _arrDegree[_idxDegree++] = _fDegree;
                if (_arrDegree.Length == _idxDegree)
                {
                    _idxDegree = 0;
                }

                if (_fDegree != 0 && Mathf.Abs(_fRotatingPower) < 5)
                {
                    transform.Rotate(0, 0, _fDegree);
                }
            }

            _prePos = ped.position;

            //Planet이 현재 조종하는 Tower를 회전시킵니다.
            if (_fRotatingPower == 0) {
                _planet.RevoluteTower(_fDegree);
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        _bBeingTouched = true;

        //터치시 UI Alpha 최대 불투명
        _bgImg.CrossFadeAlpha(_fMaxAlpha, _fAlphaDurationTime, true);
    }

    //터치를 중지했을때 firstThouch 초기화
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _bFirstTouch = true;
        _bBeingTouched = false;

        float fAvgDegree = 0;
        for (int i=0; i<_arrDegree.Length ; ++i)
        {
            fAvgDegree += _arrDegree[i];
            _arrDegree[i] = 0;
        }
        fAvgDegree /= _arrDegree.Length;

        if (_fRotatingPower == 0) {
            _fRotatingPower = fAvgDegree * 15;
        }
        else if (Mathf.Sign(_fRotatingPower) == Mathf.Sign(fAvgDegree))
        {
            if (Mathf.Abs(_fRotatingPower) < Mathf.Abs(fAvgDegree)*15)
            {
                _fRotatingPower = fAvgDegree * 15;
            }
        }
        //else
        //{
        //    if (Mathf.Abs(_fRotatingPower) < Mathf.Abs(_fDegree))
        //    {
        //    //    _fRotatingPower += _fDegree * 15;
        //    }
        //}
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

            _planet.RevoluteTower(_fRotatingPower/15);
            transform.Rotate(0, 0, _fRotatingPower * Time.deltaTime);   
        }

        //비터치시, RotatingPower Zero시 UI Alpha 투명화
        if (!_bBeingTouched && _fRotatingPower == 0 && _bgImg.color.a == 1)
        {
            _bgImg.CrossFadeAlpha(_fMinAlpha, _fAlphaDurationTime, true);
        }
    }

    private float CalculateDegree(Vector2 vCenter, Vector2 vNew, Vector2 vPre)
    {
        //두 벡터 사이각도를 구하기 위함
        float fDot = Vector2.Dot(vNew, vPre);
        float fDegree = Mathf.Acos(fDot) * Mathf.Rad2Deg;

        //외적을 통한 Z값 추출(회전 방향)
        if (((vNew.x * vPre.y) - (vNew.y * vPre.x)) > 0)
        {
            fDegree = -fDegree;
        }
        return fDegree;
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
