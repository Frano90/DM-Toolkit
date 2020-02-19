using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRoosterTemplate : MonoBehaviour
{
   public string characterName { get; private set; }
   public Image portrait { get; private set; }
   public int ID { get; private set; }

   [SerializeField] private Text name_txt;
   [SerializeField] private GameObject selectedFrame;
   
   private Button _thisButton;

   public bool isSelected { get; private set; }

   private void Start()
   {
      _thisButton = GetComponent<Button>();
      _thisButton.onClick.AddListener(PresedPortrait);
      
   }

   public void SetData(string charName, int id)
   {
      characterName = charName;
      ID = id;

      name_txt.text = characterName;
   }
   
   private void PresedPortrait()
   {
      isSelected = !isSelected;
   }

   private void Update()
   {
      selectedFrame.SetActive(isSelected);
   }
}
