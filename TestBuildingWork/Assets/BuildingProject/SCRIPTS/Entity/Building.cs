using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity // чем здания будут различаться от Юнитов??? - камерами?
{
   
    public List<GameObject> Improvements; // улучшения силы всех Юнитов кроме героев или зданий 

    // камера
    // склад ресурсов
    // улучшение трансформация покачто реализована в  Entity нужно будет новерно сюда перекидывать
    // какие нужны юниты для bulding в игре общий - по типу перейти в другой Век!


    public virtual void collectResources()
    {

    }


}
