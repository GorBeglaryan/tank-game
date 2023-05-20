using System;
using UnityEngine;

public class NavigationFlow : MonoBehaviour
{
    [SerializeField]private ViewService viewService;

    private AbstractView _currentView, _lastView, _gameView;


    private void Start(){
        Run();
    }
    private void Run(){
        ShowLoadingView();
    }
    
    private void ShowStartView(){
        CloseGameView();
        StartView stratView = ShowView<StartView>();
        stratView.OnPlay.AddListener(ShowGameView);
        stratView.OnSettings.AddListener(ShowOptionView);
        stratView.OnAbout.AddListener(ShowAboutView);
        stratView.Init();
    }
    private void ShowOptionView(){
        OptionView optionView = ShowView<OptionView>();
        optionView.onBack.AddListener(ShowLastView);
        optionView.Init();
    }
    private void ShowLastView(){
        Debug.Log(_lastView);
        if(_lastView is null){
            ShowStartView();
            return;
        }
        switch(_lastView.GetType().Name){
            case "StopGameView":ShowStopGameView();break;
            case "FinishView":ShowFinishView();break;
            case "EndGameView":ShowEndGameView();break;
        }
        _lastView = null;
    }
    private void ShowLoadingView(){
        LoadingView loadingView = ShowView<LoadingView>();
        loadingView.onLoadingFinish.AddListener(ShowStartView);
    }
    private void ShowAboutView(){
        AboutView aboutView = ShowView<AboutView>();
        aboutView.onBack.AddListener(ShowStartView);
        aboutView.Init();
    }
    private void ShowGameView(){
        GameView gameView = ShowView<GameView>();
        _gameView = gameView;
        gameView.onStop.AddListener(ShowStopGameView);
        gameView.Init();
    }

    // TODO disable Stop button 
    // when one of the views bellow is open we can click on Stop button
    private void ShowStopGameView(){
        StopGameView stopGameView = ShowView<StopGameView>();
        stopGameView.onQuit.AddListener(ShowStartView);
        
        stopGameView.onOption.AddListener(SetLastView);
        stopGameView.onOption.AddListener(ShowOptionView);
        

        stopGameView.onContinue.AddListener(CloseCurrentView);
        stopGameView.onRestart.AddListener(CloseCurrentView);
        stopGameView.Init();
    }
    private void ShowFinishView(){
        FinishView finishView = ShowView<FinishView>();
        finishView.onNextLevel.AddListener(CloseCurrentView);
        finishView.onRestart.AddListener(CloseCurrentView);
        finishView.onOption.AddListener(ShowOptionView);
        finishView.onQuit.AddListener(ShowStartView);
        finishView.Init();
    }
    private void ShowEndGameView(){
        EndGameView endGameView = ShowView<EndGameView>();
        endGameView.onQuit.AddListener(ShowStartView);
        endGameView.onOption.AddListener(ShowOptionView);
        endGameView.onRestart.AddListener(CloseCurrentView);
        endGameView.onBuyLife.AddListener(CloseCurrentView);
    }
    

    private TView ShowView<TView>() where TView : AbstractView
    {
        if(_currentView != _gameView)
            CloseCurrentView();
        TView view = viewService.LoadView<TView>();
        _currentView = view;
        return view;
    }
    private void SetLastView(){
        _lastView = _currentView;
    }
    private void CloseCurrentView(){
        if(_currentView != null)
            Destroy(_currentView.gameObject);
    }
    private void CloseGameView(){
        if(_gameView != null)
            Destroy(_gameView.gameObject);
    }
}
