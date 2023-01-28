using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    private TextMeshPro cloneNumberText;
    [HideInInspector] public int cloneNumber;
    private void Awake()
    {
        cloneNumberText= GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        cloneNumber = Random.Range(5, 31);
        cloneNumberText.text = "+" + cloneNumber.ToString();
    }


}
