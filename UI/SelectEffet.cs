using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SelectEffet : MonoBehaviour {
   // [Header("自身的renderer"),SerializeField]
    private Renderer targetRenderer;

    [Header("选中之后的材质"),SerializeField]
    private Material selectedMaterial;

    [Header("未选中的材质"), SerializeField]
    private Material noSelectedMaterial;
    [Header("变大速度"),SerializeField]
    private float toBigTime;
    [Header("变小速度"), SerializeField]
    private float toSmallTime;
    [Header("要变化的物体")]
    public GameObject ChangeGO;
    [SerializeField,Header("原位置")]
    private Vector3 oldPos;
    [SerializeField,Header("需要偏移的量")]
    private Vector3 offsetPosValue;
    [SerializeField, Header("原大小")]
    private Vector3 oldScale;
    [SerializeField,Header("需要缩放的量")]
    private Vector3 offsetScale;
    private Vector3 targetPos;
    private Vector3 targetScale;

    private bool isInit=false;

    void Awake()
    {
        InitOldInfo();
    }
    void Start()
    {
        //selfRenderer = GetComponent<Renderer>();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void InitOldInfo()
    {
        if (ChangeGO != null)
        {
            isInit = true;
            oldPos = ChangeGO.transform.localPosition;
            oldScale = ChangeGO.transform.localScale;
            targetPos = oldPos + offsetPosValue;
            targetScale = oldScale + offsetScale;
            targetRenderer = ChangeGO.transform.GetComponent<Renderer>();
        }

    }
    /// <summary>
    /// 改变材质
    /// </summary>
    /// <param name="_IsSelect"></param>
    public void ChangeMaterial(bool _IsSelect) {
        if (targetRenderer == null)
        {
            if (ChangeGO == null)
                return;
            targetRenderer = ChangeGO.transform. GetComponent<Renderer>();
        }
        if (_IsSelect)
        {
            targetRenderer.material = selectedMaterial;
          //  TransformChange(_IsSelect);
        }
        else 
        {
            //  TransformChange(_IsSelect);
            targetRenderer.material = noSelectedMaterial;
        }


    }

    /// <summary>
    /// 改变Transform属性
    /// </summary>
    /// <param name="_isSelect"></param>
    public void TransformChange(bool _isSelect) {
        if (!isInit)
        {
            InitOldInfo();
            if (!isInit)
            {
                return;
            }
        }
        if (_isSelect)
        {
            ChangeGO.transform.DOScale(targetScale, toBigTime);
            ChangeGO.transform.DOLocalMove(targetPos, toBigTime);
        }
        else
        {
            ChangeGO.transform.DOScale(oldScale, toSmallTime);
            ChangeGO.transform.DOLocalMove(oldPos, toSmallTime);
        }
    }
}
