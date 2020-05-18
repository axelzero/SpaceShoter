using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MenuUI;

namespace Core
{
    [System.Serializable]
    public class Health
    {
        [SerializeField] private int health = 100;
        [SerializeField] private SpriteRenderer spriteDamage;
        [SerializeField] private float partOfHealth = 0; // Allways divided by 3 (-> 3 images)
                         private string shipConfig;
                         private ShipInfo shipInfo;

        public void Init() 
        {
            var global = GlobalFields.Instans;

            shipConfig = PlayerPrefs.GetString("ShipConfig");

            string[] words = shipConfig.Split(':');

            int idShip = 0;
            int.TryParse(words[0], out idShip);

            shipInfo = global.GetShipInfoList()[idShip]; // Get own ship info

            partOfHealth = (float)health / shipInfo.GetDamageList().Count;
        }
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
        public void SetDamage() 
        {
            if (health < partOfHealth * (shipInfo.GetDamageList().Count * 0.8f) && health > partOfHealth * (shipInfo.GetDamageList().Count * 0.5f))
            {
                this.spriteDamage.sprite = shipInfo.GetDamageList()[0];
            }
            else if (health < partOfHealth * (shipInfo.GetDamageList().Count * 0.5f) && health > partOfHealth * (shipInfo.GetDamageList().Count * 0.2f))
            {
                this.spriteDamage.sprite = shipInfo.GetDamageList()[1];
            }
            else if (health < partOfHealth * (shipInfo.GetDamageList().Count * 0.2f))
            {
                this.spriteDamage.sprite = shipInfo.GetDamageList()[2];
            }
        }
    }
}