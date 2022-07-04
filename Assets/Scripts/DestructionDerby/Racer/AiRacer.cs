using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoCultist.DestructionDerby
{
    public class AiRacer : Racer
    {
        public Transform target;
        float turnAngle;


        Quaternion GetTargetFacingAngle()
        {
            var CurrentRot = transform.rotation;
            transform.LookAt(target);
            var LookAtTargetRot = transform.rotation;
            transform.rotation = CurrentRot;
            return LookAtTargetRot;
        }

        public void SetInput()
        {
            float yAngleDelta = transform.rotation.y - GetTargetFacingAngle().y;
            float absYAngleDelta = Mathf.Abs(yAngleDelta);
            Debug.Log(yAngleDelta);
            int rotationDirection = absYAngleDelta > 0 ? 1 : -1; //-1 left, 1 right
            turnAngle = yAngleDelta;
        }

        private void Update()
        {
            if (target == null)
                return;
            SetInput();
            carController.SetInput(0.1f, turnAngle / 180);
        }
    }
}