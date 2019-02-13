using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景开始管理类
/// scy/2019-02-13
/// </summary>
public class StartManager : MonoBehaviour
{

    #region //UI
    //移动的礼盒对象
    public GameObject gifBox;
    #endregion

    #region //字段、属性
    //礼盒移动的速度
    public float gifBoxSpeed = 1.0f;
    //移动方向
    private Vector3 direction_x = Vector3.zero;
    private Vector3 direction_y = Vector3.up;
    #endregion

    #region //unity回调函数

    private void Start()
    {
        Debug.Log(gifBox.GetComponent<RectTransform>().anchoredPosition);
    }

    private void Update()
    {
        GifBoxMove();
       
    }
    #endregion

    #region //辅助函数
    /// <summary>
    /// 礼盒移动
    /// </summary>
    private void GifBoxMove()
    {
        /*
         * 礼盒的移动，按四个中间点斜移动 A-->B-->C-->D-->A
         * A（-835,0,0）B(0,400,0) C(835,0,0) D(0,-400,0) 
         */
        var x = gifBox.GetComponent<RectTransform>().anchoredPosition.x;
        var y = gifBox.GetComponent<RectTransform>().anchoredPosition.y;
        if (x <= -835 )
        {
            direction_x = Vector3.right;
        }
        else if(x >= 835)
        {
            direction_x = Vector3.left;
        }
        if (y >= 400)
        {
            direction_y = Vector3.down;
        }
        else if (y <= -400)
        {
            direction_y = Vector3.up;
        }
        gifBox.transform.position += (direction_x*835/400 + direction_y) * Time.deltaTime * gifBoxSpeed;
    }

    #endregion

    #region //点击函数
    /// <summary>
    /// 场景跳转
    /// </summary>
    /// <param name="sceneBuildIndex"></param>
    public void StartGame(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
    #endregion


}
