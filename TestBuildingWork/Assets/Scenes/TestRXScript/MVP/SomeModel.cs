using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SomeModel : MonoBehaviour
{
    public ReactiveProperty<int> count { get; private set; }

    public SomeModel()
    {
        count = new ReactiveProperty<int>(0); // инициализируем ReactiveProperty c 0
        // ReactiveProperty в данном случае это int на стероидах на изменения которого мы можем подписаться и реагировать
    }
}
