using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Singleton;

namespace Core
{
    public class GameSession : Singleton<GameSession>
    {
        [SerializeField] private int score = 0;
        [SerializeField] private TextMeshProUGUI txtScore;

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
    }
}