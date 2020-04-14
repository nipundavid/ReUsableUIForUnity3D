using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ReUsableUI
{
    public class UI_System : MonoBehaviour
    {
        #region variables
        [Header("Main Properties")]
        public UI_Screen m_StartScreen;

        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;

        public Component[] screens = new Component[0];
        private UI_Screen currentScreen;
        public UI_Screen CurrentScreen
        {
            get
            {
                return currentScreen;
            }
        }

        private UI_Screen previousScreen;
        public UI_Screen PreviousScreen
        {
            get
            {
                return previousScreen;
            }
        }
        #endregion


        #region main_methods
        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UI_Screen>(true);
            InitializeScreens();

            if(m_StartScreen)
            {
                SwitchScreens(m_StartScreen);
            }

            if(m_Fader)
            {
                m_Fader.gameObject.SetActive(true);
            }
            FadeIn();
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region helper_methods

        public void FadeIn()
        {
            if(m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
            }
        }

        public void FadeOut()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(1f, m_FadeOutDuration, false);
            }
        }

        public void SwitchScreens(UI_Screen aScreen)
        {
            if(aScreen)
            {
                if (currentScreen)
                {
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }
                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if (onSwitchedScreen!=null)
                {
                    onSwitchedScreen.Invoke();
                }
            }
        }

        public void GoToPreviousScreen ()
        {
            if(previousScreen)
            {
                SwitchScreens(previousScreen);
            }
        }

        private void InitializeScreens()
        {
            foreach (var screen in screens)
            {
                screen.gameObject.SetActive(true); 
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        #endregion

    }
}
