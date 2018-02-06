using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyCounter : MonoBehaviour {

    // Use this for initialization
    const string display = "{0}";
    private Text m_Text;


    private void Start()
    {
        // m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
        m_Text = GetComponent<Text>();
    }


    private void Update()
    {
        // measure average frames per second
        //m_FpsAccumulator++;
        //if (Time.realtimeSinceStartup > m_FpsNextPeriod)
        //{
        //m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
        //m_FpsAccumulator = 0;
        // m_FpsNextPeriod += fpsMeasurePeriod;
        m_Text.text = string.Format(display, GameManager_Article.Instance.CalculateAccuracy());
        // }
    }
}
