using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LanguageData", menuName = "Localization/LanguageData")]
public class LanguageData : ScriptableObject
{
    public string title;
    public string howToPlay;
    public string mechanics;
    public string developer;
}
