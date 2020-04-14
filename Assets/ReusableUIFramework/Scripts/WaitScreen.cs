using ReUsableUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ReUsableUI
{
    public class WaitScreen : UI_Screen
    {

        #region variables
        [Header("Wait Screen Properties")]
        public float m_WaitTime = 2f;
        public UnityEvent OnTimeComplete = new UnityEvent();

        private float startTime;
        #endregion
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #region helper_methods

        public override void StartScreen()
        {
            base.StartScreen();


            startTime = Time.time;

            StartCoroutine("StartWaitScreen");
        }

        IEnumerator StartWaitScreen()
        {
            yield return new WaitForSeconds(m_WaitTime);

            if(OnTimeComplete!=null)
            {
                OnTimeComplete.Invoke();
            }

        }
        #endregion
    }
}