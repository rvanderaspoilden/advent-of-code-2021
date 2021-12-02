using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DayTwo : AbstractAdventOfCodeBehaviour {
    [SerializeField]
    private SubmarineController submarine;

    protected override void Execute() {
        List<Command> commands = this.fileLines.Select(line => {
            string[] split = line.Split(' ');
            return new Command((Direction) Enum.Parse(typeof(Direction), split[0].ToUpper()), int.Parse(split[1]));
        }).ToList();

        this.submarine.Init(commands);
        this.submarine.StartEngine();
    }

    protected override void RenderResult() {
        Debug.Log(this.submarine.transform.position.x * this.submarine.transform.position.y);
    }
}

public class Command {
    public Direction direction;
    public int value;

    public Command(Direction direction, int value) {
        this.direction = direction;
        this.value = value;
    }

    public void Execute(SubmarineController submarine) {
        switch (direction) {
            case Direction.UP:
                submarine.aim -= this.value;
                break;

            case Direction.FORWARD:
                Vector2 dir = new Vector2(value, submarine.aim * value);
                submarine.transform.Translate(dir);
                break;

            case Direction.DOWN:
                submarine.aim += this.value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum Direction {
    FORWARD,
    DOWN,
    UP
}