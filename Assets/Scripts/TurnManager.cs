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
    private TextMeshProUGUI _textPopup;//displayed when changing team

    [SerializeField] private int _teamId = 0;
    [SerializeField] private int _characterId = 0;
    private int _now;//time at the start of the turn

    public int timerDuration = 15;// duration of a turn
    //[Range(0, popupDurationMax)]
    public float popupDurationMax = 3;
    private float _popupDuration;//time On Screen for the popup
    /*
    public List<int> characterTeam1 = new List<int>();
    public List<int> characterTeam2 = new List<int>();
    */
    public List<Character> TeamA = new List<Character>();
    public List<Character> TeamB = new List<Character>();
    public List<List<Character>> characterTeam = new List<List<Character>>();

    // Start is called before the first frame update
    void Start()
    {
        _now = (int)Time.time;
        ShowTeamNumber();
        _popupDuration = popupDurationMax;
        characterTeam.Add(TeamA);
        characterTeam.Add(TeamB);
    }

    private void ShowTeamNumber()
    {
        _textTeam.text = $"TEAM {_teamId + 1}";
        _textPopup.text = $"TEAM {_teamId + 1}'s TURN!";
    }

    private void ShowTeamTimer()
    {
        _textTimers[_teamId].text = $"0:{_now + timerDuration - (int)Time.time}";
        _textTimers[(_teamId+1)%2].text = "";
    }
    private void StopPopup()
    {
        if(_popupDuration <= 0)
        {
            _textPopup.text = "";
        }
        _popupDuration -= Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        ShowTeamTimer();
        //if (_teamId == 1)//popup
        //{
        //    _textTimer1.text = $"0:{_now + timer_duration - (int)Time.time}";
        //    _textTimer2.text = "";
        //    if (_now + timeOnScreen - (int)Time.time == 0 && _textPopup.text != "")
        //    {
        //        _textPopup.text = "";
        //    }
        //}
        //else
        //{
        //    _textTimer1.text = "";
        //    _textTimer2.text = $"0:{_now + timer_duration - (int)Time.time}";
        //    if (_now + timeOnScreen - (int)Time.time == 0)
        //    {
        //        _textPopup.text = "";
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
            _popupDuration = popupDurationMax;
            if (_teamId == 0)
            {
                _characterId = (_characterId + 1) % 4;// on passe de 0 à 1 puis 2 puis 3 puis 0 etc.
            }
            ShowTeamNumber();
            Character.Current = characterTeam[_teamId][_characterId];
            _now = (int)Time.time;//restart timer
        }
        StopPopup();
    }
}
