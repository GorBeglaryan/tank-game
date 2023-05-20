using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class GameView : AbstractView
{
    [SerializeField]private Button stopButton;
    [SerializeField]private TextMeshProUGUI currentScore;

    public UnityEvent onStop { get; } = new UnityEvent();

    public override void Init()
    {
        //set score using Update
        //or
        //change score on every killed enemy 
    }    

    protected override void OnEnable(){
        base.OnEnable();
        stopButton.onClick.AddListener(OnStopButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        stopButton.onClick.RemoveListener(OnStopButtonClicked);
    }

    private void OnStopButtonClicked(){
        onStop?.Invoke();
    }

}
