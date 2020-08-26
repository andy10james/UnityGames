//using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

    public Text GuessText;

    private int _max;
    private int _min;
    private int _guess;
    private int _guessesRemaining = MAX_GUESSES;

    const int MAX_GUESSES = 10;

    // Use this for initialization
    private void Start () {
        this._max = 1001;
        this._min = 1;
        this._guessesRemaining = MAX_GUESSES;
        this.NextGuess();
    }

    // Update is called once per frame
    private void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.GuessHigher();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            this.GuessLower();
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Lose");
        }
    }

    public void GuessHigher () {
        this._min = this._guess;
        this.NextGuess();
    }

    public void GuessLower () {
        this._max = this._guess;
        this.NextGuess();
    }

    private void NextGuess () {
        var rangeNegate = (int) ((this._max - this._min) * 0.2);
        var widerRangeNegate = (int) ((this._max - this._min) * 0.4);
        var lowerBound = this._min + rangeNegate;
        var upperBound = this._max - rangeNegate;
        var widerLowerBound = this._min + widerRangeNegate;
        var widerUpperBound = this._max - widerRangeNegate;
        var guess1 = Random.Range(lowerBound, upperBound);
        var guess2 = Random.Range(widerLowerBound, widerUpperBound);
        var guess3 = Random.Range(this._min, this._max);
        var guessChoise = Random.Range(0, 3);
        switch (guessChoise) {
            case 0:
                this._guess = guess1;
                break;
            case 1:
                this._guess = guess2;
                break;
            case 2:
                this._guess = guess3;
                break;
        }
        if (--this._guessesRemaining <= 0) {
            SceneManager.LoadScene("Win");
            return;
        }
        this.GuessText.text = this._guess + "?";
    }

}