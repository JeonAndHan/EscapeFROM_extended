using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "Axe", "Normal Axe.",
            new Dictionary<string, int>
            {
                { "Power", 20 }  // 수정
            }),

            new Item(2, "Gun", "Scar-L.",
            new Dictionary<string, int>
            {
                { "Power", 40 } // 수정
            }),

            new Item(3, "Bullet", "for Scar-L.",
            new Dictionary<string, int>
            {
                { "Value", 10 } // 수정(총알 개수)
            }),

        };

    }
}
