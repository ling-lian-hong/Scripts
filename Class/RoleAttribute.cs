using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public  class RoleAttribute  {
    [Header("角色名字")]
    public string RoleName;
    [System.Serializable]
    public struct Attribute
    {
        [Header("属性名字")]
        public string attributeName;
        [Header("属性值")]
        public float attributeValue;
    }
    [Header("属性")]
    public Attribute[] attribute;
    [Header("角色对应的ID (不可重复)")]
    public int RoleID;
}
