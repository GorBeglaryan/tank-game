using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class StopGameView : AbstractView
{
    [SerializeField]private Button continueButton;
    [SerializeField]private Button quitButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button optionButton;
    [SerializeField]private TextMeshProUGUI scoreText;

    public UnityEvent onContinue { get; } = new UnityEvent();
    public UnityEvent onQuit { get; } = new UnityEvent();
    public UnityEvent onRestart { get; } = new UnityEvent();
    public UnityEvent onOption { get; } = new UnityEvent();

    public override void Init()
    {
        SetCurrentScore();
    }

    
    protected override void OnEnable(){
        base.OnEnable();
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        optionButton.onClick.RemoveListener(OnOptionButtonClicked);
    }

    private void SetCurrentScore(){
        //set score
    }
    private void OnContinueButtonClicked(){
        onContinue?.Invoke();
    }
    private void OnQuitButtonClicked(){
        onQuit?.Invoke();
    }
    private void OnRestartButtonClicked(){
        onRestart?.Invoke();
    }
    private void OnOptionButtonClicked(){
        onOption?.Invoke();
    }
}
