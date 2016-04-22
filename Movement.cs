using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class Movement{


        private float value;
        private bool rotation;
        private Vector3 axis;

        public Movement(float val,bool rot, Vector3 axis) {
            this.value = val;
            this.rotation = rot;
            this.axis = axis;
        }

        public Vector3 getAxis() {
            return axis;
        }

        public float getValue() {
            return value;
        }

        public bool isRotation() {
            return rotation;
        }
    }

