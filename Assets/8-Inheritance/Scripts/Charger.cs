using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {

        [Header("Charger")]
        public float chargeSpeed = 5f;
        public float knockback = 10f;
    }
}
