﻿using System;
using System.Text;
using Ude.Core;

namespace Ude
{
    public class DetectionResult
    {
        private readonly string _encodingShortName;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DetectionResult(string encodingShortName, float confidence, CharsetProber prober, TimeSpan? time)
        {
            _encodingShortName = encodingShortName;
            Confidence = confidence;

            try
            {
                Encoding = System.Text.Encoding.GetEncoding(encodingShortName);
            }
            catch (Exception)
            {
                
               //wrong name
            }
         
            Prober = prober;
            Time = time;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DetectionResult(CharsetProber prober, TimeSpan? time) 
            : this(prober.GetCharsetName(), prober.GetConfidence(), prober, time)
        {
        }

        [Obsolete("v1")]
        public string Charset
        {
            get { return _encodingShortName; }
        }

        public Encoding Encoding { get; set; }

        public float Confidence { get; set; }

        public CharsetProber Prober { get; set; }

        public TimeSpan? Time { get; set; }

    }
}
