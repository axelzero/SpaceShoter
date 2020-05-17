using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuUI
{
    public class HangarMenu : MonoBehaviour
    {
        [SerializeField] private List<ShipInfo> shipInfoList;
        [SerializeField] private List<Image> backColor;
        [SerializeField] private Image imgShip;
        [SerializeField] private int idShip = 0;
        [SerializeField] private int idColor = 0;

        private void Start()
        {
            imgShip.sprite = shipInfoList[idShip].GetShipSprite();
            BtnSetColor(idColor);
            SetBackColor(idColor);
        }

        public void BtnLeftShip()
        {
            idShip--;
            int num = Mathf.Clamp(idShip, 0, shipInfoList.Count - 1);
            idShip = num;

            imgShip.sprite = shipInfoList[idShip].GetShipSprite();
            BtnSetColor(idColor);
        }
        public void BtnRighttShip()
        {
            idShip++;
            int num = Mathf.Clamp(idShip, 0, shipInfoList.Count - 1);
            idShip = num;
            imgShip.sprite = shipInfoList[idShip].GetShipSprite();
            BtnSetColor(idColor);
        }

        public void BtnSetColor(int numBtn) 
        {
            switch (numBtn)
            {
                case 0:
                    idColor = 0;
                    imgShip.sprite = shipInfoList[idShip].GetColorShipList()[0];
                    break;
                case 1:
                    idColor = 1;
                    imgShip.sprite = shipInfoList[idShip].GetColorShipList()[1];
                    break;
                case 2:
                    idColor = 2;
                    imgShip.sprite = shipInfoList[idShip].GetColorShipList()[2];
                    break;
                case 3:
                    idColor = 3;
                    imgShip.sprite = shipInfoList[idShip].GetColorShipList()[3];
                    break;
                default:
                    Debug.Log("Wrong num btn !!!");
                    break;
            }
            SetBackColor(idColor);
        }
        private void SetBackColor(int id) 
        {
            for (int i = 0; i < backColor.Count; i++)
            {
                backColor[i].enabled = false;
            }
            backColor[idColor].enabled = true;
        }
    }
}