using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyTemplate : MonoBehaviour
{
    public int ID { get; private set; }
    [SerializeField] private Text partyName;
    public List<CharIDandAmount> members { get; private set; }
    private Button _thisButton;

    public bool isSelected { get; private set; }
    [SerializeField] private Image selectedFrame;

    private void Start()
    {
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(PressedPartyButton);
    }
    
    private void PressedPartyButton()
    {
        isSelected = !isSelected;
    }

    public void SetData(List<CharIDandAmount> partyMembers, string partyName)
    {
        this.partyName.text = partyName;
        members = partyMembers;
    }

    private void Update()
    {
        selectedFrame.gameObject.SetActive(isSelected);
    }
}
