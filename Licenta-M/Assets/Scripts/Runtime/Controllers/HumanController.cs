using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    [RequireComponent(typeof(HumanModel))]
    public class HumanController : MonoBehaviour
    {
        private const float PASSED_TIME = 2f;
        private const float HUNGER_DROP = 0.5f;
        private const float MONEY_DROP = 0.1f;
        private const float HEALTH_DROP = 0.05f;
        private const float REST_DROP = 0.5f;

        private HumanModel humanModel;
        private float lastTime;

        private void Awake()
        {
            humanModel = GetComponent<HumanModel>();
        }

        private void Start()
        {
            lastTime = Time.time;
        }

        private void Update()
        {
            if(Time.time - lastTime > PASSED_TIME)
            {
                lastTime = Time.time;
                humanModel.Hunger -= HUNGER_DROP;
                humanModel.Health -= HEALTH_DROP;
                humanModel.Rest -= REST_DROP;
                humanModel.Money -= MONEY_DROP;
            }
        }
    }
}

