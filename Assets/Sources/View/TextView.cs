using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _format;

    public void Set(int text)
    {
        _text.SetText($"{text.ToString(_format)}");
    }
}