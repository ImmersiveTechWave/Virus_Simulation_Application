using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    public class HumanModel: MonoBehaviour
    {
        public float MovementSpeed { get; private set; } = 4f;
        [Range(0f, 100f)]
        public float Hunger;
        [Range(0f, 100f)]
        public float Money;
        [Range(0f, 100f)]
        public float Health;
        [Range(0f, 100f)]
        public float Rest;
    }
}
