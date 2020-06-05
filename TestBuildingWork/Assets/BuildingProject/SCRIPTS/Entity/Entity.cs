using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;

public partial class Entity : MonoBehaviour, ISelectedEntity
{
    [Header("ART")]

    public Sprite spriteU;

    public AudioClip soundsComplate;
    public string nameTitle;
    [TextArea(2, 2)]
    public string discriptionShort;
    [TextArea(2, 5)]
    public string discription;

    public Camera cameraU;
    public Animator anim;
    [Header("BUILDING")]
    //  public T requirements[]  // требование к постройке 
    public List<GameObject> ImproveToPref; // улучшиться до
    [HideInInspector] public bool consractBild = true;
    private GameObject ImproveToCurConstract;
    public GameObject animateConstractBild;
    //  public GameObject Improvements[]; // улучшения поддерживаетъ
    public int timeBuild;  // время строительства
   

    [Header("Ability")]
    // public List<GameObject> CanBuilding;
    public List<Skill> skills;
    public int damage; // нужно будет сделать через скилл и дистацию / а не через просто коллайдер
    public float couldownMax = 3; // пока что так потом нужно будет делать лист скилов который будет принимать в себя все переменные и уровни
    public float couldownCur = 0;
    public float speed = 0;
    [Header("RESURS")]
    public float needTree;
    public float needGold;
    [Header("Status")]
    public bool selected = false;
    public Owner owner = Owner.Player1;
    //public enum Owner : byte
    //{
    //    Player1,
    //    Player2,
    //    none,
    //}

    [Tooltip("PanelOpen ")]
    [SerializeField]

    public PanelOpen panelOpen = PanelOpen.none; // камеру всю переделывать??


    public GameObject openPanel;
    //public PanelClose panelClose = PanelClose.none;
    public enum PanelOpen : int
    {
        none = 0, DownPanel = 1, CenterPanel = 2, UPPanel = 3, SelectinonPanel = 4,
    };


    //public enum PanelClose : int
    //{
    //    none = 0, сenterDownPanel = 1, сenterCenterPanel = 2, сenterUPPanel = 3, сenterSelectinonPanel = 4, centerAll = 5
    //};

    [Header("Bars & Timer")]
    // Health //
    public UniversalBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Constract //
    public UniversalBar constructionTime;
    public int maxTimer = 100;
    public int currenTimer;

 
 

    public virtual void OpenPanel()
    {
        OnMouseDown(); //  пока так сделаем 
    }


    public virtual void OpenPanelF()
    {
        switch (panelOpen) // какую панель вместе с ним нужно закрыть или не надо
        {

            case PanelOpen.none:

                break;
            case PanelOpen.DownPanel:
              if (MS.uIM.DownPanel != null) openPanel = MS.uIM.DownPanel; OpenedPanel();
                break;
            case PanelOpen.CenterPanel:
                if (MS.uIM.CenterPanel != null) openPanel = MS.uIM.CenterPanel; OpenedPanel();
                break;
            case PanelOpen.UPPanel:
                if (MS.uIM.UPPanel != null) openPanel = MS.uIM.UPPanel; OpenedPanel();
                break;
            case PanelOpen.SelectinonPanel:
               if (MS.uIM.SelectinonPanel != null) openPanel = MS.uIM.SelectinonPanel; OpenedPanel();
                break;
            default: 
                break;
        }

    }




    private void OpenedPanel()
    {
        if (openPanel)
        {
            openPanel.SetActive(true);
        }

        EntityPanel PopenPanel = openPanel.GetComponent<EntityPanel>();
        PopenPanel.SelectObj(this.gameObject);
        PopenPanel.BuildingInShopPrefs.Clear();
        byte i = 0;
        foreach (GameObject g in ImproveToPref)
        {
            PopenPanel.BuildingInShopPrefs.Add(ImproveToPref[i]);
            i++;
        }

        //    PopenPanel.SpawnAll();



    }


    public virtual void ClosePanel() // например когда умрет
    {
        selected = false;
    }
    public virtual void OnMouseDown()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{


        //    MS.uIM.Selected(this.gameObject);
        //}
    }




    public void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (healthBar) healthBar.gameObject.SetActive(true);
            if (constructionTime) constructionTime.gameObject.SetActive(false);
        }
    }



    public void OnMouseExit()
    {
        //  if (!EventSystem.current.IsPointerOverGameObject())
        // {
        //  healthBar = this.transform.Find("Canvas/Healbar").gameObject.GetComponent<UniversalBar>();
        if (healthBar == true) healthBar.gameObject.SetActive(false);
        if (constructionTime && currenTimer > 0) constructionTime.gameObject.SetActive(true);
        //   }

    }
    public void Selected()
    {


        selected = true;
        if (panelOpen != PanelOpen.none && openPanel == null) { OpenPanelF(); return; }
        if (openPanel != null) OpenedPanel();
    }
    public void unSelected()
    {
        if (openPanel != null) openPanel.SetActive(false);
    }




    //начинаем улучшать персонажа
    public virtual void ImproveTo() // чисто стройка идет включается туман войны
    {

    }
    public virtual void ImproveToUnit() // заменяем EnvokeObject на другой из префабов
    {
        GameObject clone = Instantiate(ImproveToCurConstract, transform.position, transform.rotation);
        clone.GetComponent<Entity>().openPanel = openPanel;
       
        Destroy(this.gameObject, 0.1f);
        //clone.transform.SetParent(GridGenerator.transform);
    }





    /////  ---- Bar ---- ////
    public virtual void Start()
    {
        //   currentHealth = maxHealth;
        openPanel = null;
        healthBar = this.transform.Find("Canvas/Healbar").gameObject.GetComponent<UniversalBar>();
        if (healthBar) healthBar.SetValueEntity(currentHealth);

       // Invoke("PassiveSkill", 4);
        Observable.Timer(System.TimeSpan.FromSeconds(4)).Subscribe(_ => { PassiveSkill(); }).AddTo(this.gameObject);
        //  UniRx  Damage ///
        var clickStream = Observable.EveryUpdate()
         .Where(_ => Input.GetMouseButtonDown(0))
    
         .Where(_ => MS.uIM.selectedGO == this.gameObject);
        
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(150)))
         .Where(xs => xs.Count >= 2)
         .Subscribe(xs =>  Damage(xs.Count*3));
        //////
        ///
        if (speed > 0) { AIgo(); }
    }
    public virtual void Awake()
    {

    }

    //void Update() //тестоя  Update нельзя
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        TakeDamage(5);
    //    }
    //}

    public void Damage(int _damage)
    {
        TakeDamage(_damage);
    }




    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthBar) healthBar.SetValueEntity(currentHealth);
        if (currentHealth < 1)
        {
            OnDestroy(); 
        }
    }

    int seconds;
    int munutes;



    public virtual void StartImproveTo(GameObject pref)
    {
        Debug.Log("Тут");
        constructionTime = this.transform.Find("Canvas/ConstractBar").gameObject.GetComponent<UniversalBar>();
        ImproveToCurConstract = pref;
        Entity ImproveToCurConstractUnit = ImproveToCurConstract.GetComponent<Entity>();
        if (animateConstractBild) animateConstractBild.SetActive(true);
        constructionTime.gameObject.SetActive(true);
        StartCoroutine(StartImproveToTimer());
        // maxTimer>60:munutes = maxTimer / 60? munutes=0;
        int maxTimerpref = ImproveToCurConstractUnit.maxTimer;
        munutes = maxTimerpref > 60 ? munutes = maxTimerpref / 60 : munutes = 0;
        seconds = maxTimerpref % 60;
        if (healthBar == true) healthBar.gameObject.SetActive(false);
        if (constructionTime) constructionTime.SetMaxValueEntity(maxTimerpref);
        currenTimer = 0;
        consractBild = false;
        // Debug.Log(seconds);
        //StopAllCoroutines();
        //   StopCoroutine(StartImproveToTimer());
        //  Delegati(); // придумать куда встроить?
    }

    private IEnumerator StartImproveToTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currenTimer++;
            seconds--;
            if (munutes <= 0 && seconds <= 0)
            {
                currenTimer = 0;
                ImproveToUnit();
                Debug.Log("Здание Построилось!");
                consractBild = true;
                if (animateConstractBild) animateConstractBild.SetActive(false);
                constructionTime.gameObject.SetActive(false);
                break;
            }
            else
            {
                if (seconds <= -1)
                {

                    munutes--;
                    seconds = 59;
                }
            }
            constructionTime.textValue.text = munutes.ToString() + ":" + (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
            constructionTime.SetValueEntity(currenTimer);

            //       Debug.Log(munutes.ToString() + ":" + seconds.ToString());
        }

    }

    int rotator = -1;






    public virtual void UseSkill(byte _numSkill)
    {
        Skill skill = skills[_numSkill];
        if (skills[_numSkill].name == "AtakRotation")
        {
            rotator = _numSkill;
            //   Invoke("StopRotation", 2);
            Observable.Timer(System.TimeSpan.FromSeconds(2)).Subscribe(_ => { StopRotation(); }).AddTo(this.gameObject);
        }
      if(skill.passivSkill != true )  skill.Apply(this.gameObject);
    }





    void StopRotation()
    {
        rotator = -1;
    }
    private void FixedUpdate()
    {
        if (rotator >= 0) { skills[rotator].Apply(this.gameObject); }
    }

    public virtual void PassiveSkill()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].name == "AtakRotation")
            {
                rotator = i;
 Observable.Timer(System.TimeSpan.FromSeconds(2)).Subscribe(_ => {  StopRotation();}).AddTo(this.gameObject);  

              //  Invoke("StopRotation", 2);
            }
            else if (skills[i].name == "TowerFireSkill")
            {
                skills[i].StartInstanse(this.gameObject);
            }

        }
    }




    void OnDestroy()
    {
        Destroy(this.gameObject);
        unSelected();
    }



}