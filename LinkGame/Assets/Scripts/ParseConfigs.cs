using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.UI;

/// <summary>
/// 解析配置文件
/// scy/2019-02-13
/// </summary>
public class ParseConfigs : MonoBehaviour {

    private Text dialogText;
    private JsonData jd;
    private int index = 0;

	// Use this for initialization
	void Start () {
        dialogText = GetComponent<Text>();
        StreamReader sr = File.OpenText("Assets/Resources/Configs/Dialog.txt");
        string strLine = sr.ReadToEnd();
        jd = JsonMapper.ToObject(strLine);
        dialogText.text = (string)jd[index]["dialogText"];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextDialog()
    {
        index++;
        string ob = (string)jd[index]["ID"];
        int id = int.Parse(ob);
        if (id > (GameManager.Instance.currDialog + 1) * 1000)
        {
            //当前对话结束
            return;
        }
        else
        {
            dialogText.text = (string)jd[index]["dialogText"];
        }
    }
}
