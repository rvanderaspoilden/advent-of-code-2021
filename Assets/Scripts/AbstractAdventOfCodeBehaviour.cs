using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAdventOfCodeBehaviour : MonoBehaviour {

    [SerializeField] protected TextAsset inputFile;
    
    protected long result = 0;
    protected List<string> fileLines;
    
    private void Awake() {
        this.RetrieveInputFile();
    }

    private void Start() {
        Execute();
        RenderResult();
    }

    protected abstract void Execute();

    protected virtual void RetrieveInputFile() {
        this.fileLines = Utils.TextAssetToList(inputFile);
    }

    protected virtual void RenderResult() {
        Debug.Log(this.result);
    }
}