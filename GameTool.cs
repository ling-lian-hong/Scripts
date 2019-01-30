/*********************************************************************
 *      作者：                                                       *
 *      主题：                                                       *
 *      功能：                                                       *
 *      修改：                                                       *  
 *      版本：                                                       *
 *********************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameTool : MonoBehaviour
{

    //获取指定范围内随机数
    public static int GetRandomInt(int num1, int num2)
    {
        if (num1 < num2)
        {
            return UnityEngine.Random.Range(num1, num2);
        }
        else
        {
            return UnityEngine.Random.Range(num2, num1);
        }
    }
    //清理内存(一般在切换场景的时候调用)
    public static void ClearMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }
    //根据分号来分割字符串
    public static string[] DivisionStr(string str)
    {
        return str.Split(';');
    }
    //封装PlayerPrefs
    public static bool HasKey(string keyName)
    {
        return PlayerPrefs.HasKey(keyName);
    }
    public static int GetInt(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }
    public static int GetInt(string keyName, int defaultValue)
    {
        return PlayerPrefs.GetInt(keyName, defaultValue);
    }
    public static void SetInt(string keyName, int valueInt)
    {
        PlayerPrefs.SetInt(keyName, valueInt);
    }
    public static float GetFloat(string keyName)
    {
        return PlayerPrefs.GetFloat(keyName);
    }
    public static float GetFloat(string keyName, float defaultValue)
    {
        return PlayerPrefs.GetFloat(keyName, defaultValue);
    }
    public static void SetFloat(string keyName, float valueFloat)
    {
        PlayerPrefs.SetFloat(keyName, valueFloat);
    }
    public static string GetString(string keyName)
    {
        return PlayerPrefs.GetString(keyName);
    }
    public static string GetString(string keyName, string defaultValue)
    {
        return PlayerPrefs.GetString(keyName, defaultValue);
    }
    public static void SetString(string keyName, string valueString)
    {
        PlayerPrefs.SetString(keyName, valueString);
    }
    public static void DeleteAllKey()
    {
        PlayerPrefs.DeleteAll();
    }
    public static void DeleteTheKey(string keyName)
    {
        PlayerPrefs.DeleteKey(keyName);
    }
    //设置物体的活跃状态
    public static void SetActive(GameObject go, bool value)
    {
        if (go == null)
            return;
        if (go.activeSelf != value)
        {
            go.SetActive(value);
        }
    }
    //查找物体
    public static Transform FindTheChild(GameObject goParent, string childName)
    {
        Transform searchTrans = goParent.transform.Find(childName);
        if (searchTrans == null)
        {
            foreach (Transform trans in goParent.transform)
            {
                searchTrans = FindTheChild(trans.gameObject, childName);
                if (searchTrans != null)
                {
                    return searchTrans;
                }
            }
        }
        return searchTrans;
    }
    //获取子物体的组件
    public static T GetTheChildComponent<T>(GameObject goParent, string childName) where T : Component
    {
        Transform searchTrans = FindTheChild(goParent, childName);
        if (searchTrans != null)
        {
            return searchTrans.gameObject.GetComponent<T>();
        }
        else
        {
            return null;
        }
    }
    private static List<T> GetComponentFormChild<T>(GameObject goParent)
    {
        Transform searchTrans = goParent.transform;
        List<T> list_t = new List<T>();
        foreach (Transform item in searchTrans)
        {
            if (item.GetComponent<T>() != null)
            {
                list_t.Add(item.GetComponent<T>());
                if (item.childCount != 0)
                {
                    List<T> new_List = GetComponentFormChild<T>(item.gameObject);
                    for (int i = 0; i < new_List.Count; i++)
                    {
                        list_t.Add(new_List[i]);
                    }
                }
            }
            else
            {
                if (item.childCount != 0)
                {
                    List<T> new_List = GetComponentFormChild<T>(item.gameObject);
                    for (int i = 0; i < new_List.Count; i++)
                    {
                        list_t.Add(new_List[i]);
                    }
                }
            }
        }
        return list_t;
    }
    //获取所有子物体拥有该类型的脚本
    public static T[] GetAllComponentFormChild<T>(GameObject goParent) where T : Component
    {
        List<T> list_t = new List<T>();
        list_t = GetComponentFormChild<T>(goParent);
        return list_t.ToArray();
    }
    //给子物体添加脚本
    public static T AddTheChildComponent<T>(GameObject goParent, string childName) where T : Component
    {
        Transform searchTrans = FindTheChild(goParent, childName);
        if (searchTrans != null)
        {
            T[] theComponentsArr = searchTrans.GetComponents<T>();
            for (int i = 0; i < theComponentsArr.Length; i++)
            {
                if (theComponentsArr[i] != null)
                {
                    Destroy(theComponentsArr[i]);
                }
            }
            return searchTrans.gameObject.AddComponent<T>();
        }
        else
        {
            return null;
        }
    }
    //添加子物体
    public static void AddChildToParent(Transform parentTrs, Transform childTrs)
    {
        childTrs.parent = parentTrs;
        childTrs.localPosition = Vector3.zero;
        childTrs.localScale = Vector3.one;
        childTrs.localEulerAngles = Vector3.zero;
    }
    public static IEnumerator DelayAction(float duration,Action action)
    {
        yield return new WaitForSeconds(duration);
        if(action!=null)
        {
            action();
        }
    }
    //加载场景的开关
    public static void OpenLoadSceneHelper()
    {
        //GameObject uiRoot = GameObject.Find("UI Root");
        GameObject uiRoot = GameObject.FindGameObjectWithTag("CanvasRoot");
        if (uiRoot != null)
        {
            GameObject helpGo = FindTheChild(uiRoot, "LoadSceneHelper").gameObject;
            if (helpGo.activeInHierarchy == false)
            {
                helpGo.SetActive(true);
            }
        }
    }
    //是否是第一次加载游戏,默认是
    public static bool isFirstLoad = true;
}