using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioList", menuName = "Add Audio List")]
    public class MusicList : ScriptableObject
    {
        [SerializeField] private List<AudioClip> clips;
        public List<AudioClip> GetAudioList() 
        {
            return clips;
        }
        public AudioClip GetNextClip(ref int currentClip) 
        {
            if (currentClip >= clips.Count - 1)
            {
                currentClip = 0;
            }
            else 
            {
                currentClip++;
            }
            return clips[currentClip];
        }
    }
}