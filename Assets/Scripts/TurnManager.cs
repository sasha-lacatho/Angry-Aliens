using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnManager: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textTeam;//display name of the team
    [SerializeField]
    private TextMeshProUGUI _textTimer1;//display timer for the team 1
    [SerializeField]
    private TextMeshProUGUI _textTimer2;//display timer for the team 2
    [SerializeField]
    private TextMeshProUGUI _textTeamChange;//displayed when changing team
    private int _team = 1;
    private float _now;//time at the start of the turn
    private int _duration = 15;// duration of a turn
    private int _timeOnScreen = 3;//time On Screen for text in the middle of the screen
    // Start is called before the first frame update
    void Start()
    {
        _now = (int)Time.time;
        _textTeam.text = $"TEAM {_team}";
        _textTeamChange.text = $"TEAM {_team} TURN!";
    }

    // Update is called once per frame
    void Update()
    {

        if (_team == 1)//popup
        {
            _textTimer1.text = $"0:{_now + _duration - (int)Time.time}";
            _textTimer2.text = "";
            if (_now + _timeOnScreen - (int)Time.time == 0 && _textTeamChange.text != "")
            {
                _textTeamChange.text = "";
            }
        }
        else
        {
            _textTimer1.text = "";
            _textTimer2.text = $"0:{_now + _duration - (int)Time.time}";
            if (_now + _timeOnScreen - (int)Time.time == 0)
            {
                _textTeamChange.text = "";
            }
        }

        if (_now < Time.time - _duration)
        {
            if (_team == 1) //switch team
            {
                _team = 2;
                _textTeam.text = $"TEAM {_team}";
                _textTeamChange.text = $"TEAM {_team} TURN!";
            }
            else
            {
                _team = 1;
                _textTeam.text = $"TEAM {_team}";
                _textTeamChange.text = $"TEAM {_team} TURN!";
            }

            _now = (int)Time.time;//restart timer
        }
    }
}
