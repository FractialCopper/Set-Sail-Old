using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEvent 
{
    public Penalty penalty;
    public Prize prize;
    public Test test;
    Game game = GameObject.Find("Controller").GetComponent<Game>();
    public string flavour_text;
    public string option_one;
    public string option_two;
    public bool solved = false;


    public TriggeredEvent(string flavour_text, string option_one, string option_two,Penalty penalty,Prize prize) {
        this.penalty = penalty;
        this.prize = prize;
        this.flavour_text = flavour_text;
        this.option_one = option_one;
        this.option_two = option_two;
        test = new Test();
    }
    public TriggeredEvent(string flavour_text, string option_one, string option_two, Penalty penalty, Prize prize,Test test)
    {
        this.test = test;
        this.penalty = penalty;
        this.prize = prize;
        this.flavour_text = flavour_text;
        this.option_one = option_one;
        this.option_two = option_two;
    }

    public bool Test(double stat) {
        solved = true;
        //if (test.Solve(Mathf.Abs(100 * Mathf.Sin((float)(0.01f * stat)))))
        if (test.Solve(100 / (Mathf.Exp((float)-stat / 100 * 2 + 1) + 1)))
                return true;
        else
            return false;
    }

    public float ShowChance(double stat) {
        return  100 / (Mathf.Exp((float)-stat/100 * 2 + 1) + 1);
        //return Mathf.Abs(100 * Mathf.Sin((float)(0.01f * stat)));
        //return Mathf.Log((float)stat, (float)1.3f); 

    }


    public void OnSuccess() {
        game.ReceivePrize(prize);
    }

    public void OnFail() {
        game.ReceivePenalty(penalty);
    }

}
