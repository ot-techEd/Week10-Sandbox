using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShowPlatformControls : MonoBehaviour
{
    [SerializeField] private TMP_Text controlsTxt;
    [SerializeField] private Button toggleButton;
    // Start is called before the first frame update
    void Start()
    {
        toggleButton.onClick.AddListener(ToggleControlText); //MOBILE
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //PC
        {
            ToggleControlText();
        }
    }

    private void ToggleControlText()
    {
            controlsTxt.gameObject.SetActive(!controlsTxt.gameObject.activeSelf);
    }

}
