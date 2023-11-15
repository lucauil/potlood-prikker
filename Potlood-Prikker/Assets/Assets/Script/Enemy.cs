using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool Movingleft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleduration;
    private float idletimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator Animation;


    void Start()
    {

    }
    private void Awake()
    {
        initscale = enemy.localScale;
    }
    private void Update()
    {
        if (Movingleft) 
        {
            if(enemy.position.x >= LeftEdge.position.x) 
            {
                Movedirection(-1);
            }
            else
            {
                DirectionChange();
            }

        }
        else
        {
            if (enemy.position.x <= RightEdge.position.x)
            {
                Movedirection(1);
            }
            else
            {
                DirectionChange();
                
            }
        }
    }
  
    private void DirectionChange() 
    { 
   
        Animation.SetBool("Walking", false);
        idletimer += Time.deltaTime;

        if(idletimer > idleduration) 
        {
            Movingleft = !Movingleft;
        }
        
    }
    private void Movedirection(int _direction)
    {
        idletimer = 0;
        Animation.SetBool("Walking", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction,
            initscale.y, initscale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
        
    }
}
