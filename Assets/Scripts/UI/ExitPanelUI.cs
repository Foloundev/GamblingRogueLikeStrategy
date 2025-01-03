using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject exitPanel;
    public void ClosePanel()
    {
        exitPanel.SetActive(false);
    }
}
