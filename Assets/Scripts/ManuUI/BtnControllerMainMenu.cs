using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManager;

namespace MenuUI
{
    public class BtnControllerMainMenu : MonoBehaviour
    {
        [SerializeField] private Button btnLoadLevel;
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject hangarUI;
                         private Manager manager;

        private void Start()
        {
            manager = FindObjectOfType<Manager>();
            btnLoadLevel.onClick.AddListener(manager.LoadFirstLevel);
        }
        public void BtnMainMenu() 
        {
            menuUI.SetActive(true);
            hangarUI.SetActive(false);
        } 
        public void BtnHangar() 
        {
            menuUI.SetActive(false);
            hangarUI.SetActive(true);
        }
        public void BtnGetShip() 
        {
            // TODO save ship
            BtnMainMenu();
        }
    }
}