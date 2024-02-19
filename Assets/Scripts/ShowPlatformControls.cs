using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowPlatformControls : MonoBehaviour
{
    [SerializeField] private TMP_Text controlsTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleControlText();
    }

    private void ToggleControlText()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            controlsTxt.gameObject.SetActive(!controlsTxt.gameObject.activeSelf);
        }
    }
}
