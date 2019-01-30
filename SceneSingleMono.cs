/*/////////////////////////////////////////////////////////////
 *           作者：Lin
 *           主题: 场景单例
 *           功能:  单例类
 *           修改:
///////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lin
{
    public class SceneSingleMono<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        protected virtual void Awake()
        {
            if (Instance != this)
            {
                Debug.LogWarning("重复调用单例" + typeof(T).Name);
                Destroy(gameObject);
            }
        }
    }
}
