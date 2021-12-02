using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SubmarineController : MonoBehaviour {
    public float aim;
    public List<Command> commands;

    public void Init(List<Command> commands) {
        this.commands = commands;
    }

    public void StartEngine() {
        this.aim = 0;
        this.transform.position = Vector2.zero;
        
        commands.ForEach(command => command.Execute(this));
    }
}