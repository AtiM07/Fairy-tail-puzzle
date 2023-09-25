using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PersonController : MonoBehaviour
{
    public Dictionary<string, List<string>> persons = new Dictionary<string, List<string>>()
    {
        {
            "Русалки", new List<string>()
            {
                "Перламутровое радужное сияние",
                "Мокрые следы",
                "Холодный огонь"
            }
        },
        {
            "Мышь и ряба", new List<string>()
            {
                "Холодный огонь",
                "Перламутровое радужное сияние",
                "Мороз"
            }
        },
        {
            "Мавки-навки", new List<string>()
            {
                "Мокрые следы",
                "Холодный огонь",
                "Мороз"
            }
        },
        {
            "Елена Премудрая", new List<string>()
            {
                "Холодный огонь",
                "Змеиные шкуры",
                "Кокошник"
            }
        },
        {
            "Волколак", new List<string>()
            {
                "Змеиные шкуры",
                "Холодный огонь",
                "Мороз"
            }
        },
    };

    [SerializeField] public TMP_InputField inputField;

    private string[] _attributes = Array.Empty<string>();

    private void Update()
    {
        var massive = inputField.text.Split(',');

        if (!_attributes.SequenceEqual(massive))
        {
            _attributes = massive;
            Debug.Log(GetPerson());
        }
    }

    private string GetPerson()
    {
        var i = persons.Where(x =>
            {
                foreach (var attr in _attributes)
                {
                    if (!x.Value.Contains(attr))
                        return false;
                }

                return true;
            }
        );
        var str = new StringBuilder();
        i = i.OrderBy(x => x.Key);

        foreach (var item in i)
        {
            if (!string.IsNullOrEmpty(str.ToString()))
                str.Append(",");
            str.Append(item.Key);
        }

        if (string.IsNullOrEmpty(str.ToString()))
            str.Append("Неизвестно");

        return str.ToString();
    }
}