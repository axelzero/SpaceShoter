using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace LevelManager
{
    public class BtnController : MonoBehaviour
    {
        [SerializeField] private List<Button> btnMainMenu;


        private IEnumerator Start()
        {
            var global = GlobalFields.Instans;
            var manager = global.GetLevelManager();
            while (manager == null)
            {
                yield return null;
            }

            foreach (var btn in btnMainMenu)
            {
                btn.onClick.AddListener(global.GetLevelManager().LoadMainMenu);
            }
        }
    }
}