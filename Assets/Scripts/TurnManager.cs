using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textTeam;//display name of the team
    [SerializeField]
    private TextMeshProUGUI[] _textTimers;//display timer for the teams
    //[SerializeField]
    //private TextMeshProUGUI _textTimer2;//display timer for the team 2
    [SerializeField]
    private TextMeshProUGUI _textTeamChange;//displayed when changing team

    [SerializeField] private int _teamId = 0;
    [SerializeField] private int _characterId = 0;
    private int _now;//time at the start of the turn

    public int timerDuration = 15;// duration of a turn
    public int popupDuration = 3;//time On Screen for text in the middle of the screen
    /*
    public List<int> characterTeam1 = new List<int>();
    public List<int> characterTeam2 = new List<int>();
    */
    public LinkedList<int> characterTeam1 = new LinkedList<int>();
    public LinkedList<int> characterTeam2 = new LinkedList<int>();

    // Start is called before the first frame update
    void Start()
    {
        _now = (int)Time.time;
        ShowTeamNumber();

    }

    private void ShowTeamNumber()
    {
        _textTeam.text = $"TEAM {_teamId + 1}";
        _textTeamChange.text = $"TEAM {_teamId + 1} TURN!";
    }

    private void ShowTeamTimer()
    {
        _textTimers[_teamId].text = $"0:{_now + timerDuration - (int)Time.time}";
        _textTimers[(_teamId+1)%2].text = "";
    }
    // Update is called once per frame
    void Update()
    {
        ShowTeamTimer();
        //if (_teamId == 1)//popup
        //{
        //    _textTimer1.text = $"0:{_now + timer_duration - (int)Time.time}";
        //    _textTimer2.text = "";
        //    if (_now + timeOnScreen - (int)Time.time == 0 && _textTeamChange.text != "")
        //    {
        //        _textTeamChange.text = "";
        //    }
        //}
        //else
        //{
        //    _textTimer1.text = "";
        //    _textTimer2.text = $"0:{_now + timer_duration - (int)Time.time}";
        //    if (_now + timeOnScreen - (int)Time.time == 0)
        //    {
        //        _textTeamChange.text = "";
        //    }
        //}
        //_timer -= Time.deltaTime;
        //if (_timer <= 0)
        //{
        //    _timer = timer_duration;
        //}
        if (_now < Time.time - timerDuration)
        {
            _teamId = (_teamId + 1) % 2; // on passe de 0 à 1 puis de 1 à 0
            if (_teamId == 0)
            {
                _characterId = (_characterId + 1) % 4;// on passe de 0 à 1 puis 2 puis 3 puis 0 etc.
            }
            ShowTeamNumber();
            _now = (int)Time.time;//restart timer
        }
    }
}
