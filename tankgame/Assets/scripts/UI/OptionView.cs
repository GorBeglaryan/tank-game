using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class OptionView : AbstractView
{
    [SerializeField]private Button backButton;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider soundSlider;

    public UnityEvent onBack {get;} = new UnityEvent();

    public override void Init()
    {
        //throw new System.NotImplementedException();
    }
    protected override void OnEnable(){
        base.OnEnable();
        backButton.onClick.AddListener(OnBackButtonClicked);
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
    }
    protected override void OnDisable(){
        base.OnEnable();
        backButton.onClick.RemoveListener(OnBackButtonClicked);
        musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
    }
    
    private void OnBackButtonClicked(){
        onBack?.Invoke();
    }
    private void OnMusicSliderValueChanged(float value){
        //TODO something
    }
    private void OnSoundSliderValueChanged(float value){
        //TODO something
    }
}
