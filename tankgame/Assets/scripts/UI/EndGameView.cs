using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class EndGameView : AbstractView,IInit
{
    [SerializeField]private Button restartButton;
    [SerializeField]private Button optionButton;
    [SerializeField]private Button quitButton;
    [SerializeField]private Button buyLifeButton;
    [SerializeField]private TextMeshProUGUI scoreText;

    public UnityEvent onRestart {get;} = new UnityEvent();
    public UnityEvent onOption {get;} = new UnityEvent();
    public UnityEvent onQuit {get;} = new UnityEvent();
    public UnityEvent onBuyLife {get;} = new UnityEvent();
    public override void Init()
    {
        ShowScore();
    }
    protected override void OnEnable(){
        base.OnEnable();
        restartButton.onClick.AddListener(onRestartButtonClicked);
        optionButton.onClick.AddListener(onOptionButtonClicked);
        quitButton.onClick.AddListener(onQuitButtonClicked);
        buyLifeButton.onClick.AddListener(onBuyLifeButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        restartButton.onClick.RemoveListener(onRestartButtonClicked);
        optionButton.onClick.RemoveListener(onOptionButtonClicked);
        quitButton.onClick.RemoveListener(onQuitButtonClicked);
        buyLifeButton.onClick.RemoveListener(onBuyLifeButtonClicked);
    }
    
    private void ShowScore(){
        string score = "";// set score
        scoreText.text = score;
    }
    private void onRestartButtonClicked(){
        onRestart?.Invoke();
    }

    private void onOptionButtonClicked(){
        onOption?.Invoke();
    }

    private void onQuitButtonClicked(){
        onQuit?.Invoke();
    }

    private void onBuyLifeButtonClicked(){
        onBuyLife?.Invoke();
    }
}
