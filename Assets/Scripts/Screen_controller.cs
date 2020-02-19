using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_controller : MonoBehaviour
{
    public static Screen_controller instance;

    [SerializeField] private List<Screen> pantallas_prefab;
    private Dictionary<ScreenType, Screen> screenIndex = new Dictionary<ScreenType, Screen>();
    private Screen currentScreen;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Init();
        
        ChangeScreen(ScreenType.MainMenu);
    }

    public void ChangeScreen(ScreenType screenType)
    {
        if (currentScreen != null)
        {
            currentScreen.gameObject.SetActive(false);    
        }
        
        Screen nextScreen = screenIndex[screenType];
        currentScreen = nextScreen;
        nextScreen.gameObject.SetActive(true);
        nextScreen.Init();
    }

    private void Init()
    {
        foreach (Screen sc in pantallas_prefab)
        {
            if(screenIndex.ContainsKey(sc.screenType))
                return;
            
            Screen newSc = Instantiate<Screen>(sc, canvas.transform);
            screenIndex.Add(sc.screenType, newSc);
            newSc.gameObject.SetActive(false);
        }
    }
    
}
