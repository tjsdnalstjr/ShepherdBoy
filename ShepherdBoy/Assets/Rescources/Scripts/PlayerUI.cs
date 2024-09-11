using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text sheepCount;

    public void SetPlayerUI(string name, int sheep)
    {
        nameText.text = name;
        sheepCount.text = "¾ç:" + sheep;
    }

    public void SetSheepCount(int sheep)
    {
        sheepCount.text = "¾ç:" + sheep;
    }
}
