using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSceneMG : MonoBehaviour {
    public Camera waitSceneCam;
    [Header("射线检测的层"), SerializeField]
    private LayerMask layermask;
    [Header("射线检测距离"), SerializeField]
    public float castDis;

    [Header("没选中时的material")]
    public Material[] noSelectMaterials;
    [Header("选中时的material")]
    public Material[] selectMaterials;
    [Header("角色对应的SelectEffet")]
    public SelectEffet[] RoleSelectEffetScript;
    [Header("确认按钮的ConfirmUI")]
    public ConfirmUI confirmPlane;
    [Header("选中角色的名字")]
    public Renderer nameRenderer;
    [Header("选中角色的信息")]
    public Renderer roleDataRenderer;

    //[Header("当前选中的ID"),SerializeField]
    private int currSelectRoleID;
   // [Header("之前选中的ID"), SerializeField]
    private int oldSelectRoleID;
    private bool leaveConfirmPlane;

    #region 固定字符串
    const string Role_1_Name = "Role_1";
    const string Role_2_Name = "Role_2";
    const string Role_3_Name = "Role_3";
    const string Role_4_Name = "Role_4";
    const string Role_5_Name = "Role_5";
    const string Role_6_Name = "Role_6";
    const string Role_7_Name = "Role_7";
    const string Role_8_Name = "Role_8";
    const string ConfirmUIName = "Plane (1)";
    #endregion

    #region 人物属性
    [Header("-----------人物属性------------")]
    public RoleAttribute[] roleAttribute;
    private Dictionary<int, RoleAttribute> roleAttributeDis = new Dictionary<int, RoleAttribute>();

    public AttributeUI attributeUI;
    #endregion

    void Start () {
        currSelectRoleID = 1;
        oldSelectRoleID = 1;
        leaveConfirmPlane = false;
        if (RoleSelectEffetScript[currSelectRoleID - 1] != null)
        {
            RoleSelectEffetScript[currSelectRoleID - 1].TransformChange(true);
            nameRenderer.material.SetFloat("_weizhi", currSelectRoleID);
            roleDataRenderer.material.SetFloat("_weizhi", currSelectRoleID);
        }
    }
	
	void Update () {
        CursorBehavior();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }

    /// <summary>
    /// 准心行为
    /// </summary>
    private void CursorBehavior()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        RaycastHit hit;
        Ray ray = waitSceneCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, castDis, layermask))
        {

            if (hit.transform != null)
            {
             //   Debug.Log(hit.transform.name);
                switch (hit.transform.name)
                {
                    case Role_1_Name:
                        currSelectRoleID = 1;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_2_Name:
                        currSelectRoleID = 2;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_3_Name:
                        currSelectRoleID = 3;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_4_Name:
                        currSelectRoleID = 4;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_5_Name:
                        currSelectRoleID = 5;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_6_Name:
                        currSelectRoleID = 6;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_7_Name:
                        currSelectRoleID = 7;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    case Role_8_Name:
                        currSelectRoleID = 8;
                        SelectRole();
                        LeaveConfirmUI();
                        break;
                    //case ConfirmUIName:
                       // Confirm();
                       // break;

                    default:
                        break;
                }

            }

            // }
        }
        else
        {
            //LeaveConfirmUI();
        }
    }

    /// <summary>
    /// 选中角色UI 行为
    /// </summary>
    private void SelectRole() {
        if (currSelectRoleID == oldSelectRoleID)
            return;
        if (RoleSelectEffetScript[currSelectRoleID - 1]!=null)
        {
            RoleSelectEffetScript[oldSelectRoleID - 1].TransformChange(false);
            RoleSelectEffetScript[oldSelectRoleID - 1].ChangeMaterial(false);
        }
        if (RoleSelectEffetScript[currSelectRoleID - 1] != null)
        {
          
            RoleSelectEffetScript[currSelectRoleID - 1].TransformChange(true);
            RoleSelectEffetScript[currSelectRoleID - 1].ChangeMaterial(true);
            nameRenderer.material.SetFloat("_weizhi", currSelectRoleID);
            roleDataRenderer.material.SetFloat("_weizhi", currSelectRoleID);
        }
      
        oldSelectRoleID= currSelectRoleID;
    }

    /// <summary>
    /// 确定(弃用)
    /// </summary>
    private void Confirm() {
     
        if (!leaveConfirmPlane)
        {
            if (confirmPlane != null)
            {
                confirmPlane.IsStayOn(true);
            }
        }

        leaveConfirmPlane = true;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           // Debug.Log("射击");
            if (confirmPlane!=null)
            {
                RoleSelectEffetScript[currSelectRoleID - 1].ChangeMaterial(true);
              
               // confirmPlane.ClickConfirm();
            }
        }
    }

    /// <summary>
    /// 离开确认按键（弃用）
    /// </summary>
    private void LeaveConfirmUI() {
        if (leaveConfirmPlane)
        {
            leaveConfirmPlane = false;
            if (confirmPlane!=null)
            {
                confirmPlane.IsStayOn(false);
            }
         
        }
    }
    /// <summary>
    /// 设置人物对应的属性
    /// </summary>
    private void SetRoleAttribute(int _roleID) {
        if (roleAttributeDis.ContainsKey(_roleID))
        {
            attributeUI.SetValue(roleAttributeDis[_roleID]);
        }
        
        //roleAttribute[0].attribute[0].
    }
}
