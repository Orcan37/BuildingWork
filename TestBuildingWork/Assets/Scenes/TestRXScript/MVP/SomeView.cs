using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class SomeView : MonoBehaviour
{
    public Text someText;
    public Button someButton;

    public void RenderCount(int count)
    { // отображаем данные count
        someText.text = count.ToString();
    }

    public void AnimateButton()
    { // анимируем кнопку
        someButton.transform
            .DOShakeScale(0.5F, 0.3F) // анимируем кнопку
            .OnComplete(() => { // по окончании анимации возвращаем прежнии масштаб
                someButton.transform.localScale = Vector3.one;
            });
    }
}
