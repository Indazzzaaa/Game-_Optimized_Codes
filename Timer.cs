using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEditor;

namespace com.triogames.Test
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _timeSpent;
        [SerializeField] private string _Time;
        [SerializeField] private TMP_Text _timer;

        void Start()
        {
            _Time = "00:00:00";
            _timer.SetText(_Time);
           
        }

        // Update is called once per frame
        void Update()
        {
            SetTime();
        }

        unsafe void SetTime()
        {
            _timeSpent += Time.deltaTime;
            int seconds = (int) _timeSpent % 60;
            int minustes = (int) (_timeSpent / 60)%60;
            int hour = (int) (_timeSpent/60)/60;

            fixed (char* c = _Time)
            {
                c[0] = GetAsscii(hour / 10);

                c[1] = GetAsscii(hour % 10);
                c[3] = GetAsscii(minustes / 10);
                c[4] = GetAsscii(minustes % 10);
                c[6] = GetAsscii(seconds / 10);
                c[7] = GetAsscii(seconds % 10);



                _timer.SetText(_Time);
            }
        }

        private char GetAsscii(int num)
        {
            switch (num)
            {
                case 0:
                    return '0';

                case 1:
                    return '1';

                case 2:
                    return '2';

                case 3:
                    return '3';

                case 4:
                    return '4';

                case 5:
                    return '5';

                case 6:
                    return '6';

                case 7:
                    return '7';

                case 8:
                    return '8';

                case 9:
                    return '9';
                default:
                    return '0';
            }
        }
    }
}