using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundPlayMusic : Singleton<BackgroundPlayMusic>
    {
        [SerializeField] private MusicList musicList;
        [SerializeField, Range(0f, 1f)] private float volume = 0.25f;
        private int trackId;
        private AudioSource audioSource;

        private void Awake()
        {
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private IEnumerator Start()
        {
            audioSource = GetComponent<AudioSource>();
            var list = musicList.GetAudioList();
            trackId = Random.Range(0, list.Count);
            audioSource.clip = list[trackId];
            audioSource.volume = volume;
            while (true)
            {
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
                audioSource.clip = musicList.GetNextClip(ref trackId);
            }
        }
        private void OnValidate()
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
    }
}