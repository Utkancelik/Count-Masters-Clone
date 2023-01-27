using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshPro doorText;

    [HideInInspector] public int randomCloneNumber;
    private void Awake()
    {
        doorText = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        randomCloneNumber = Random.Range(1, 21);
        doorText.text = "+" +randomCloneNumber.ToString(); 
    }


}
