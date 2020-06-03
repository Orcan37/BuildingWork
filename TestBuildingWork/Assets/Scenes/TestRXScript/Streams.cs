using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Streams : MonoBehaviour
{
    void rStart()
    {
       // Thread(); // не работает зависает все
        Observable.EveryUpdate() // поток update
          .Where(_ => Input.anyKeyDown) // фильтруем на нажатие любой клавиши
          .Select(_ => Input.inputString) // выбираем нажатую клавишу
          .Subscribe(x => { // подписываемся
        OnKeyDown(x); // вызываем метод OnKeyDown c параметром нажатой клавиши
    }).AddTo(this); // привязываем подписку к gameobject-у
    }
    private void OnKeyDown(string keyCode)
    {
        switch (keyCode)
        {
            case "w":
                Debug.Log("keyCode: W");
                break;
            default:
                Debug.Log("keyCode: " + keyCode);
                break;
        }
    }

  //  public void Thread()
  //  {
  //      Observable.Start(() => { // создаем Observable из thread
  //          int n = 100000000;
  //          int res = Fibonacci(n); // выполняем тяжелую операцию
  //          return res; // возвращаем результат
  //      }).ObserveOnMainThread() // наблюдаем за результатом в main thread-е
  //.Subscribe(xs => { // подписываемся
  //    Debug.Log("res: " + xs); // получаем результат уже в main thread-е
  //}).AddTo(this);
  //  }

  //  private int Fibonacci(int n)
  //  {
  //      return n > 1 ? Fibonacci(n - 1) + Fibonacci(n - 2) : n;
  //  }
}
