using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
    {
        private static T instace;
        public static T Instace 
        {
            get 
            {
                if (!instace) 
                {
                    instace = FindObjectOfType<T>();

                    if (!instace) 
                    {
                        var singleton = new GameObject(typeof(T).ToString());
                        instace = singleton.AddComponent<T>();
                    }
                }
                return instace;
            }
        }
    }
}