using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Utils {
    public static List<string> TextAssetToList(TextAsset ta)
    {
        string[] arrayString = ta.text.Split('\n');
        return arrayString.ToList();
    }
}
