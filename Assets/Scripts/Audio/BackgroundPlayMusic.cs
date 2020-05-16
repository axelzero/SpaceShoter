using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BackgroundPlayMusic : MonoBehaviour
    {
        [SerializeField] private MusicList musicList;
                         private int trackId;
                         private AudioSource audioSource;

        private IEnumerator Start()
        {
            audioSource = GetComponent<AudioSource>();
            var list = musicList.GetAudioList();
            trackId = Random.Range(0, list.Count);
            audioSource.clip = list[trackId];
            while (true) 
            {
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
                audioSource.clip = musicList.GetNextClip(ref trackId);
            }
        }
    }
}