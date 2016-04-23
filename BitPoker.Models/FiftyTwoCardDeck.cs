﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitPoker.Models
{
    public class FiftyTwoCardDeck : IDeck
    {
        private const Int32 LENGTH = 52;

        public ICollection<Byte[]> Cards { get; private set; }

        public bool IsEncrypted
        {
            get; private set;
        }

        private IList<String> deck;

        public FiftyTwoCardDeck()
        {
            deck = new List<string>(LENGTH);
            Cards = new List<Byte[]>(LENGTH);
        }

        public void New()
        {
            List<String> suites = new List<String>(4);
            suites.Add("H");
            suites.Add("D");
            suites.Add("S");
            suites.Add("C");

            foreach (String suite in suites)
            {
                for (Int32 i = 0; i < 13; i++)
                {
                    String card = String.Format("{0}{1}", i, suite);
                    deck.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            deck = deck.OrderBy<String, int>((item) => rnd.Next()).ToList();
        }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Byte[] card in Cards)
            {
                sb.Append(Convert.ToBase64String(card));
            }
            return base.ToString();
        }


        ///// <summary>
        ///// Shuffle the specified list.
        ///// </summary>
        ///// <param name="list">List.</param>
        ///// <typeparam name="T">The 1st type parameter.</typeparam>
        //public static void Shuffle<T>(IList<T> list)
        //{
        //    using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
        //    {
        //        int n = list.Count;

        //        while (n > 1)
        //        {
        //            byte[] box = new byte[1];
        //            do
        //                provider.GetBytes(box);
        //            while (!(box[0] < n * (Byte.MaxValue / n)));
        //            int k = (box[0] % n);
        //            n--;

        //            T value = list[k];
        //            list[k] = list[n];
        //            list[n] = value;
        //        }
        //    }
        //}
    }
}
