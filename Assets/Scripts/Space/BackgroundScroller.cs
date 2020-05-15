using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Space
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 0.001f;
        [SerializeField] private Vector2 offSet = new Vector2();
                         private Material material;

        private IEnumerator Start()
        {
            material = gameObject.GetComponent<Renderer>().material;
            offSet = new Vector2(0f, scrollSpeed);
            while (true)
            {
                
                material.mainTextureOffset += offSet * Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}