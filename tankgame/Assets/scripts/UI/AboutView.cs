
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class AboutView : AbstractView
{
    [SerializeField]private TextMeshProUGUI aboutText;
    [SerializeField]private Button backButton;

    public UnityEvent onBack {get;} = new UnityEvent();
    public override void Init()
    {
        SetText();
    }

    protected override void OnEnable(){
        base.OnEnable();
        backButton.onClick.AddListener(OnBackButtonClicked);
    }
    protected override void OnDisable(){
        base.OnEnable();
        backButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked(){
        onBack?.Invoke();
    }

    private void SetText(){
        //TODO read text aboyt game from DB
        string text = "Text from db";
        aboutText.text = text;
    }
}
