using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObservableTimer : MonoBehaviour
{
    public CompositeDisposable disposables;

    void Start()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(3)) // создаем timer Observable
          .Repeat()    //     .Repeat() 1)) // создаем timer Observable
            .Subscribe(_ =>
            { // подписываемся
                Debug.Log("через 3 секунды");
            }).AddTo(disposables); // привязываем подписку к disposable

        Observable.Timer(System.TimeSpan.FromSeconds(1)) // создаем timer Observable
            .Repeat() // делает таймер циклическим
            .Subscribe(_ =>
            { // подписываемся
                Debug.Log("каждую 1 секунду");
            }).AddTo(disposables); // привязываем подписку к disposable
    }

    void OnEnable()
    { // создаем disposable
        disposables = new CompositeDisposable();
    }

    void OnDisable()
    { // уничтожаем подписки
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }
}
