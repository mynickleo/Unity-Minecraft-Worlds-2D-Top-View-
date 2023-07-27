using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    //Ресурсы
    public List<Sprite> PlayerSprites;
    public List<Sprite> WeaponSprites;
    public List<int> WeaponPrices;
    public List<int> xpTable;

    //Ссылки
    public Player player;

    //Логика
    public int Gold;
    public int Experience;

    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += Gold.ToString() + "|";
        s += Experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState()
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;

            string[] data = PlayerPrefs.GetString("SaveString").Split('|');
            //Добавить сохранение скина в будущем
            Gold = int.Parse(data[1]);
            Experience = int.Parse(data[2]);
            //Добавить сохранение оружия в будущем
    }
}
