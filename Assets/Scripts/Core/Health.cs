using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class Health
    {
        [SerializeField] private int health = 100;
        public int Healths
        {
            get 
            {
                return health;
            }
            set 
            {
                health = value;
            }
        }
    }
}