using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyTemplate : MonoBehaviour
{
    public int ID { get; private set; }
    [SerializeField] private Text partyName_txt;
    public string partyName { get; private set; }
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

    public void SetData(List<CharIDandAmount> partyMembers, string nameOfParty)
    {
        partyName = nameOfParty;
        members = partyMembers;
    }

    private void Update()
    {
        partyName_txt.text = partyName;
        selectedFrame.gameObject.SetActive(isSelected);
    }
}
