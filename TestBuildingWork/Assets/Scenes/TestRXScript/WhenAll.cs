using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WhenAll : MonoBehaviour
{
    void Start() {
       // PrimA();
            PrimB();

    }


    void PrimB()
    {
        Observable.WhenAll( // метод WhenAll принимает в себя Observable потоки
          Observable.FromCoroutine(AsyncA), // здесь мы превращаем корутины в Observable
          Observable.FromCoroutine(AsyncB),
          Observable.FromCoroutine(AsyncC)
        ).Subscribe(_ =>
        { // подписываемся на этот поток который создал нам WhenAll
            Debug.Log("end");
        }).AddTo(this);
    }

    IEnumerator AsyncB()
    {
        Debug.Log("b start");
        yield return new WaitForFixedUpdate();
        Debug.Log("b end");
    }

    IEnumerator AsyncA()
    {
        Debug.Log("a start");
        yield return new WaitForSeconds(1);
        Debug.Log("a end");
    }


    IEnumerator AsyncC()
    {
        Debug.Log("c start");
        yield return new WaitForEndOfFrame();
        Debug.Log("c end");
}
    void PrimA()// последовательно все делать
    {
        Observable.FromCoroutine(AsyncA) // запускаем корутину AsyncA
    .SelectMany(AsyncB) // AsyncB запуститься только после окончания AsyncA
    .SelectMany(AsyncC) // И уже потом AsynC
    .Subscribe(_ => {
        Debug.Log("end");
    }).AddTo(this); 
    }
}
