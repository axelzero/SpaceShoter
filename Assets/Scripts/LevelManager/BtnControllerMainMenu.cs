using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManager
{
    public class BtnControllerMainMenu : MonoBehaviour
    {
        [SerializeField] private Button btnLoadLevel;
                         private Manager manager;

        private void Start()
        {
            manager = FindObjectOfType<Manager>();
            btnLoadLevel.onClick.AddListener(manager.LoadFirstLevel);
        }
    }
}