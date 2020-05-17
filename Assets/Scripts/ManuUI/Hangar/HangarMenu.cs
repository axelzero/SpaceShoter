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
        [SerializeField] private List<Jun_TweenRuntime> backColorTween = new List<Jun_TweenRuntime>();
        [SerializeField] private Image imgShip;
        [SerializeField] private int idShip = 0;
        [SerializeField] private int idColor = 0;

        [Header("Save Config")]
        [SerializeField] private string shipConfig = "0:0";

        private void Start()
        {
            GetTweens();
            imgShip.sprite = shipInfoList[idShip].GetShipSprite();
            BtnSetColor(idColor);
            SetBackColor();
        }

        private void GetTweens()
        {
            int count = backColor.Count;
            for (int i = 0; i < count; i++)
            {
                backColorTween.Add(backColor[i].gameObject.GetComponent<Jun_TweenRuntime>());
            }
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
            SetBackColor();
            SaveShip();
            ChangeTween();
        }

        private void ChangeTween()
        {
            int count = backColorTween.Count;
            for (int i = 0; i < count; i++)
            {
                backColorTween[i].enablePlay = false;
                backColorTween[i].playType = Jun_TweenRuntime.PlayType.One;
                backColorTween[i].StopPlay();
            }
            backColorTween[idColor].playType = Jun_TweenRuntime.PlayType.Loop;
            backColorTween[idColor].enablePlay = true;
            backColorTween[idColor].Play();
        }

        private void SetBackColor() 
        {
            for (int i = 0; i < backColor.Count; i++)
            {
                backColor[i].enabled = false;
            }
            backColor[idColor].enabled = true;
        }
        private void SaveShip() 
        {
            shipConfig = idShip + ":" + idColor;
            PlayerPrefs.SetString("ShipConfig", shipConfig);
        }
    }
}