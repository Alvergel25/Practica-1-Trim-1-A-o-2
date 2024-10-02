using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Es necesario para el texto

public class Score : MonoBehaviour
{
    private float points;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = points.ToString("0");
    }

    public void AddPoints(float addedP)
    {
        points += addedP;
    }
}
