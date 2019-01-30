using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorUI : MonoBehaviour
{
    public Camera mainCam;
    [SerializeField]
    private Image cursorImage;

    private float screenProportionx;
    private float screenProportiony;
    private float screenWidthOffset;
    private float screenHeightOffser;
    [SerializeField]
    private int size;  //大小
      void Awake()
    {
        cursorImage = GetComponent<Image>();
        screenWidthOffset = 1920 / 2;
        screenHeightOffser = 1080 / 2;
        screenProportionx = 1920 / mainCam.pixelRect.width;
        screenProportiony = 1080 / mainCam.pixelRect.height;
    }

     void Update()
    {

        //设置鼠标的位置
        Vector2 mousePos = new Vector2(Input.mousePosition.x * screenProportionx - screenWidthOffset, Input.mousePosition.y * screenProportiony - screenHeightOffser);
        cursorImage.rectTransform.anchoredPosition = mousePos;
        cursorImage.rectTransform.sizeDelta = new Vector2(size, size);
    }
}
