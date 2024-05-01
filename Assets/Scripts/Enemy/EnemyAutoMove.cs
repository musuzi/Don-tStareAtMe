using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class EnemyAutoMove : MonoBehaviour
{
    Transform player;
    [Header("寻路参数")]
    public UnityEvent OnAttack;
    public UnityEvent<Vector2> OnMovement;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;

    private Seeker seeker;
    private List<Vector3> pathPointList;
    private int currentIndex = 0;
    private float PathGEnerateInterval = 0.5f;
    private float pathGenerateTimer = 0f;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        player = FindObjectOfType<PlayerMove>().transform;
    }

    private void AutoPath()
    {
        pathGenerateTimer += Time.deltaTime;
        if (pathGenerateTimer >= PathGEnerateInterval)
        {
            GeneratePath(player.position);
            pathGenerateTimer = 0f;
        }
        if (pathPointList == null || pathPointList.Count == 0)
        {
            GeneratePath(player.position);
        }
        else if (Vector2.Distance(transform.position, pathPointList[currentIndex]) <= 0.1f)
        {
            currentIndex++;
            if (currentIndex >= pathPointList.Count)
            {
                GeneratePath(player.position);
            }
        }
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < chaseDistance)
        {
            AutoPath();
            if (pathPointList == null)
            {
                return;
            }
            if (distance <= attackDistance)
            {
                OnMovement?.Invoke(Vector2.zero);
                OnAttack?.Invoke();//攻击
            }
            else
            {
                /* Vector2 direction = player.position - transform.position;*/
                Vector2 direction = (pathPointList[currentIndex] - transform.position).normalized;
                OnMovement?.Invoke(direction);// 追击
            }
        }
    }
    private void GeneratePath(Vector3 target)
    {
        currentIndex = 0;
        //三个参数：起点，终点，回调函数
        seeker.StartPath(transform.position, target, Path =>
        {
            pathPointList = Path.vectorPath;
        });
    }

}
