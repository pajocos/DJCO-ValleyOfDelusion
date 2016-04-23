
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.Utils {


    public class Movement {


        private float value;
        private Vector3 axis;

        public Movement(float val, Vector3 axis) {
            this.value = val;
            this.axis = axis;
        }

        public Vector3 getAxis() {
            return axis;
        }

        public float getValue() {
            return value;
        }


    }

}