using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class SomePresenter : MonoBehaviour
{
    public SomeView someView; // view к которому имеем прямой доступ
    public SomeModel someModel = new SomeModel(); // model 

    void Start()
    {
        someModel.count // ReactiveProperty count
            .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
            .Subscribe(xs => { // подписываемся
                someView.RenderCount(xs); // вызываем метод отображения данных
            }).AddTo(this);

        someView.someButton // кнопка
            .OnClickAsObservable() // превращаем клик в Observable поток
            .Subscribe(_ => OnClick(someView.someButton.GetInstanceID()))
            .AddTo(this);
    }

    private void OnClick(int buttonId)
    {
        if (buttonId == someView.someButton.GetInstanceID())
        {
            someModel.count.Value++;
            someView.AnimateButton();
        }
    }
}
