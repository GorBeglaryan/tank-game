using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class FinishView : AbstractView
{
    [SerializeField]private Button nextLevelButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button quitButton;
    [SerializeField]private Button optionButton;

    public UnityEvent onNextLevel {get;} = new UnityEvent();
    public UnityEvent onRestart {get;} = new UnityEvent();
    public UnityEvent onQuit {get;} = new UnityEvent();
    public UnityEvent onOption {get;} = new UnityEvent();

    public override void Init()
    {
        // TODO something
    }

    protected override void OnEnable(){
        base.OnEnable();
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);
        optionButton.onClick.RemoveListener(OnOptionButtonClicked);
    }

    private void OnNextLevelButtonClicked(){
        onNextLevel?.Invoke();
    }
    private void OnRestartButtonClicked(){
        onRestart?.Invoke();
    }
    private void OnQuitButtonClicked(){
        onQuit?.Invoke();
    }
    private void OnOptionButtonClicked(){
        onOption?.Invoke();
    }
}
