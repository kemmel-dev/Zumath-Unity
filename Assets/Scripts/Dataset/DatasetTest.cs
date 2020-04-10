﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dataset
{
    class DatasetTest : MonoBehaviour
    {
        public List<string> listAll = new List<string>();


        private void Start()
        {


            using (var reader = new StreamReader(@"missions_plussommen_tot_100_export.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadToEnd();
              
                    var values = line.Split(';');
                    
                    foreach (string value in values)
                    {
                        listAll.Add(value);
                    }


                }
            }
            //Read(listQuestions);
            //Read(listAll);
        }

        private void Update()
        {
          //Read(listAll);
        }

        public void Read(List<string> list)
        {
            foreach (string value in list)
            {
                print(value);
            }
        }
    }
}