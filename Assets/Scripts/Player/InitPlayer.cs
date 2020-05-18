using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace PlayerSpace
{
    public class InitPlayer : MonoBehaviour
    {
        private Player player;
        private string shipConfig;
        private void Awake()
        {
            player = FindObjectOfType<Player>();
            shipConfig = PlayerPrefs.GetString("ShipConfig");

            if (shipConfig == "") 
            {
                shipConfig = "0:0";
            }

            string[] words = shipConfig.Split(':');

            int idShip = 0;
            int.TryParse(words[0], out idShip);
            int idColor = 0;
            int.TryParse(words[1], out idColor);


            var global = GlobalFields.Instans;
            var listShipConfig = global.GetShipInfoList();

            Sprite sprite = listShipConfig[idShip].GetColorShip(idColor);

            player.SetShip(sprite);
        }
    }
}

//string text = "kek:kek2cheburek";

//string[] words = text.Split(new char[] { ':' });
//// new char[] - массив символов-разделителей. Как меня поправили в 
//// комментариях, в данном случае достаточно написать text.Split(':')

//string first = words[0];
//string second = words[1];

//Console.WriteLine(first);
//Console.WriteLine(second);