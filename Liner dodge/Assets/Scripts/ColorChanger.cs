﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] m_Colors;
    private Color currentColour;
    private int colorIndex = 0;
    public GameObject[] changableC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changableC = GameObject.FindGameObjectsWithTag("Changable");
        foreach(GameObject x in changableC)
        {
            x.GetComponent<SpriteRenderer>().color = currentColour;
            
        }

        for (int i = 0; i < m_Colors.Length; i++)
        {
            // Get the currentColor in the Array
            if (currentColour == m_Colors[i])
            {
                colorIndex = i + 1 == m_Colors.Length ? 0 : i + 1;
            }
        }
        Color nextColor = m_Colors[colorIndex];
        // Lerp Color _>
        currentColour = Color.Lerp(currentColour, nextColor, 0.008f);
        Camera.main.backgroundColor = currentColour;
    }
}
