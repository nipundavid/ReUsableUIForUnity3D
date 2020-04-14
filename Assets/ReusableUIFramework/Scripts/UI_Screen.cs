using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ReUsableUI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UI_Screen : MonoBehaviour
    {
        #region variables
        private Animator animator;


        [Header("Main Properties")]
        public Selectable m_startSelectablel;


        [Header("Screen Events")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();
        #endregion


        #region main_methods
        // Start is called before the first frame update
        public virtual void Start()
        {
            animator = GetComponent<Animator>();
            if(m_startSelectablel)
            {
                EventSystem.current.SetSelectedGameObject(m_startSelectablel.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region helper_methods

        public virtual void StartScreen()
        {
            if(onScreenStart !=null)
            {
                onScreenStart.Invoke();
            }
            HandleAnimator("show");
        }

        public virtual void CloseScreen()
        {
            if (onScreenClose != null)
            {
                onScreenClose.Invoke();
            }
            HandleAnimator("hide");
        }


        private void HandleAnimator(string aTrigger)
        {
            if (animator)
            {
                animator.SetTrigger(aTrigger);
            }
        }
        #endregion
    }
}