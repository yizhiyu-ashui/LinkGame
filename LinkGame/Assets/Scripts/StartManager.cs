using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景开始管理类
/// scy/2019-02-13
/// </summary>
public class StartManager : MonoBehaviour {

    public void StartGame(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
