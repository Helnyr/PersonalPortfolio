using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    public RectTransform mainPanel;
    public RectTransform playersPanel;
    static CanvasUI instance;

    void Awake() { instance = this; }
    public static void SetActive(bool active) { instance.mainPanel.gameObject.SetActive(active); }
    public static RectTransform GetPlayersPanel() => instance.playersPanel;
}
