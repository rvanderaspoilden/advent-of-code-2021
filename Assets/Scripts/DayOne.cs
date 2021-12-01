using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DayOne : AbstractAdventOfCodeBehaviour {
    [SerializeField] private TextMeshProUGUI resultTxt;

    protected override void Execute() {
        List<int> values = this.fileLines.Select(int.Parse).ToList();

        int increaseCounter = 0;

        long previousValue = values[2] + values[1] + values[0];
        for (int i = 3; i < values.Count; i++) {
            long currentValue = values[i - 2] + values[i - 1] + values[i];
            increaseCounter += (currentValue > previousValue) ? 1 : 0;
            previousValue = currentValue;
        }

        this.result = increaseCounter;
    }

    protected override void RenderResult() {
        base.RenderResult();
        this.resultTxt.text = $"Result is {this.result}";
    }
}