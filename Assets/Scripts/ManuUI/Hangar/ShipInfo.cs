using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuUI
{
    [CreateAssetMenu(fileName ="ShipConfig", menuName = "Add ship config")]
    public class ShipInfo : ScriptableObject
    {
        [SerializeField] private Sprite ship;
        [SerializeField] private List<Sprite> colorShipList;
        [SerializeField] private List<Sprite> damageList;

        public Sprite GetShipSprite() { return ship; }
        public List<Sprite> GetColorShipList() { return colorShipList; }
    }
}