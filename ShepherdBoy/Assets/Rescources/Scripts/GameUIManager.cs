using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIManager : MonoBehaviour
{
    public List<PlayerUI> playerUIList;
    public Scrollbar timerBar;
    public Image reportUI;
    public TMP_Text reportText;

    public void SetTimerBar(float size)
    {
        timerBar.size = size;
    }

    public void OpenReportUI(string reportInfo)
    {
        reportUI.gameObject.SetActive(true);
        reportText.text = reportInfo;
    }
}
