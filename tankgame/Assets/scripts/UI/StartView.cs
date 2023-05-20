using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class StartView : AbstractView
{
    [SerializeField]private Button playButton;
    [SerializeField]private Button optionButton;
    [SerializeField]private Button quitButton;
    [SerializeField]private Button aboutButton;
    [SerializeField]private TextMeshProUGUI versionText;
    
    public UnityEvent OnPlay { get; } = new UnityEvent();
    public UnityEvent OnSettings { get; } = new UnityEvent();
    public UnityEvent OnAbout { get; } = new UnityEvent();
    public UnityEvent OnStore {get;} = new UnityEvent();
    public override void Init()
    {
        SetVersion();
    }

    private void SetVersion(){
        versionText.text = $"Dev. ver. {Application.version}";
    }
    protected override void OnEnable(){
        base.OnEnable();
        quitButton.onClick.AddListener(AppQuit);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
        aboutButton.onClick.AddListener(OnAboutButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        quitButton.onClick.RemoveListener(AppQuit);
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        optionButton.onClick.RemoveListener(OnOptionButtonClicked);
        aboutButton.onClick.RemoveListener(OnAboutButtonClicked);
    }
    private void OnStoreButtonClicked(){
        OnStore?.Invoke();
    }
    private void OnPlayButtonClicked()
    {
        OnPlay?.Invoke();
    }
    private void OnOptionButtonClicked()
    {   
        OnSettings?.Invoke();
    }
    private void OnAboutButtonClicked()
    {
        OnAbout?.Invoke();
    }
    private static void AppQuit(){
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
