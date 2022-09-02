﻿using FishingGame.Utilities;
using UnityEngine;

namespace FishingGame.Development
{
    public class CameraController : MonoSingleton<CameraController>
    {
        private Transform target;

        private const float LERP_SPEED = 8f;
        
        private void LateUpdate()
        {
            if (target != null)
                transform.position = Vector3.Lerp(transform.position, target.transform.position.SetZ(-10f), 
                    LERP_SPEED * Time.deltaTime);
        }

        public void SetTargetTransform(Transform target)
        {
            this.target = target;
        }
    }
}