using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Singleton;

namespace LevelManager
{
    public class Manager : Singleton<Manager>
    {
        private float deley = 0.5f;
        private void Start()
        {
            var list = FindObjectsOfType<Manager>();
            if (list.Length > 1) 
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }
        public void GameOver(GameObject UI) 
        {
            StartCoroutine(Over(UI));
        }
        public void Quit()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        private IEnumerator Over(GameObject UI) 
        {
            yield return new WaitForSeconds(deley);
            UI.SetActive(true);
        }
    }
}