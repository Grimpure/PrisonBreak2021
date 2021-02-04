using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    private string riddle;
    private string answer;
    private bool solved = false;

    public PuzzleItem(string name, float weight, string riddle, string answer) : base(name, weight)
    {
        this.riddle = riddle;
        this.answer = answer;
    }

    public string GetRiddle()
    {
        return riddle;
    }

    public string GetAnswer()
    {
        return answer;
    }

    public bool CheckRiddleSolved(string m_givenAnswer)
    {
        if(answer == m_givenAnswer)
        {
            solved = true;
        }
        return solved;
    }
}
