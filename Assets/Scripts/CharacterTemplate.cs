using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTemplate : MonoBehaviour
{
    public int ID { get; private set; }
    public int amount { get; private set; }
    public Image portrait;
    [SerializeField] private Image selectedBorder;
    [SerializeField] private GameObject amountSelector;

    [SerializeField] private Text name_txt;
    [SerializeField] private Text amount_txt;

    private Button _thisButton;

    [SerializeField] private Button add_btt;
    [SerializeField] private Button minus_btt;

    public bool isSelected { get; private set; }

    private void Start()
    {
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(PresedPortrait);
        add_btt.onClick.AddListener(AddAmount);
        minus_btt.onClick.AddListener(MinusAmount);

        amount = 1;
    }

    private void Update()
    {
        selectedBorder.gameObject.SetActive(isSelected);
        amountSelector.SetActive(isSelected);

        amount_txt.text = amount.ToString();
    }

    private void PresedPortrait()
    {
        isSelected = !isSelected;
    }
    
    public void SetData(string name, int id)
    {
        name_txt.text = name;
        this.ID = id;
    }

    private void AddAmount()
    {
        amount++;
    }
    
    private void MinusAmount()
    {
        amount--;
    }
}
