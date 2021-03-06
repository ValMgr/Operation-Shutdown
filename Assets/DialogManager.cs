﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This struct represents one dialog page
// (text on the current page, and its color)
[System.Serializable]
public struct DialogPage
{
    public string text;
    public Color color;
}

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour {

    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;

    void Awake () {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
               m_renderText.text = "";
            }

            this.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
		if (m_dialogToDisplay.Count > 0)
        {
            m_renderText.text = m_dialogToDisplay[0].text;
             m_renderText.color = m_dialogToDisplay[0].color;
        } else
        {
            this.gameObject.SetActive(false);
        }

        // Remoeves the page when the player presses "space"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_dialogToDisplay.RemoveAt(0);
        }
	}

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }
}
