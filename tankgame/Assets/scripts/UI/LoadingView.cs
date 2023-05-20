using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingView : AbstractView
{
    [SerializeField]private Slider progressBarSlider;
    private byte waitSeconds = 5;
    private Coroutine myCoroutine;
    public UnityEvent onLoadingFinish {get;} = new UnityEvent();
    public override void Init(){}
    
    void Start(){
        myCoroutine = StartCoroutine("MyCoroutine");
    }
    
    void FixedUpdate(){
        progressBarSlider.value = Mathf.MoveTowards(progressBarSlider.value, 1, .2f * Time.deltaTime);
    }
    
    IEnumerator MyCoroutine(){
        yield return new WaitForSeconds(waitSeconds);
        onLoadingFinish?.Invoke();
    }
}
