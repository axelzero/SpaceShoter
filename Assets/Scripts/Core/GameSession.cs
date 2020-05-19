using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Singleton;
using System;

namespace Core
{
    public class GameSession : Singleton<GameSession>
    {
        [SerializeField] private int score = 0;
        [SerializeField] private TextMeshProUGUI txtScore;

        [Header("Win Config")]
        [SerializeField] private float timeBeforeInitUI = 1.5f;

        public void UpdateScore() 
        {
            txtScore.text = score.ToString();
        }
        public void AddToScore(int score) 
        {
            this.score += score;
            UpdateScore();
        }
        public int GetScore() 
        {
            return score;
        }
        public void WinGame() 
        {
            StartCoroutine(WinCor());
        }

        private IEnumerator WinCor()
        {
            GlobalFields.Instans.SetIsWin();
            yield return new WaitForSeconds(timeBeforeInitUI);
            GlobalFields.Instans.GetWinUI().SetActive(true);
        }
    }
}