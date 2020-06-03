using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;



namespace MessageBase {
public class SomeModel : MonoBehaviour
{
    public ReactiveProperty<int> count { get; private set; }

    public SomeModel()
    {
      var  count = new ReactiveProperty<int>(0); // инициализируем ReactiveProperty c 0
    }
}
}