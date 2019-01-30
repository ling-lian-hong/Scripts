using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttributeUI : MonoBehaviour {
    public Dictionary<int, float> IdValue = new Dictionary<int, float>();
    [System.Serializable]
   public struct AttributeAndText {
        public Text valueText;
        public string name;
    }
    //  public AttributeAndText[] attributeAndText;

    public List<AttributeAndText> attributeAndText;
    public void SetValue(RoleAttribute _roleAttribute)
    {
        for (int i = 0; i < _roleAttribute.attribute.Length; i++)
        {

        }

    }

    [ContextMenu("角色属性总览")]
    public void Init(RoleAttribute _roleAttribute) {      
        //for (int i = 0; i < _roleAttribute.attribute.Length; i++)
        //{
        //    AttributeAndText AttributeAndText1 = new AttributeAndText();
        //    AttributeAndText1.name = _roleAttribute.attribute[i].attributeName;
        //    attributeAndText.Add(AttributeAndText1);
        //}
    }
}
