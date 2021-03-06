﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgeterSuite
{
    public class PayDay
    {
        Envelope[] envelopes;
        int envCap = 16;
        int envCount = 0; // Sits at next empty element for envelopes and payOuts
        double[] payOuts;                

        // Constructor
        public PayDay()
        {
            envelopes = new Envelope[envCap];
            payOuts = new double[envCap];
        }

        // Setters
        public void SetEnvelope(Envelope env, int id)
        {
            envelopes[id] = env;
        }
        public void SetPayOut(double num, int id)
        {
            payOuts[id] = num;
        }

        // Getters
        public Envelope GetEnvelope(int id)
        {
            return envelopes[id];
        }
        public double GetPayOut(int id)
        {
            return payOuts[id];
        }
        public int GetEnvCap()
        {
            return envCap;
        }
        public int GetEnvCount()
        {
            return envCount;
        }

        // Checks whether there's space, then adds Envelope and payOut
        // at [envCount] and increases envCount by 1
        public bool AddEnvelope(Envelope env, double pay)
        {
            if (envCount >= envCap)
            {
                bool denied = true;
                //AddSpace(envCap);
                MessageBox.Show("Sorry, but I've only figured out \nhow to cram 16 envelopes into this space. \nPlease check back in the next version :)");
                return denied;
            }
            else
            {
                bool denied = false;
                envelopes[envCount] = env;
                payOuts[envCount] = pay;
                envCount++;
                return denied;
            }
        }

        // Pay out to envelopes
        public void PayEnvelopes()
        {
            for(int i = 0; i <= envCount; i++)
            {
                envelopes[i].NewTransaction(payOuts[i], "Payday");
            }
        }
        
        // Add envelopes[] and payouts[] space
        // Creates new arrays and copies the old elements into them
        // Doubles the size of envelopes[], payouts[], and envCap
        /* Disabling this for now, because UI space is currently limited.
        public void AddSpace(int cap)
        {
            int newCap = cap * 2;
            Envelope[] newEnvelopes = new Envelope[newCap];
            for (int i = 0; i < cap; i++)
            {
                newEnvelopes[i] = envelopes[i];
            }
            double[] newPayOuts = new double[newCap];
            for (int i = 0; i < cap; i++)
            {
                newPayOuts[i] = payOuts[i];
            }            
            envelopes = newEnvelopes;
            payOuts = newPayOuts;
            envCap = newCap;
        }
        */        
    }
}
