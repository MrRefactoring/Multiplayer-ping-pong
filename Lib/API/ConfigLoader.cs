using System;
using System.Collections.Generic;
using System.IO;

namespace Lib.API
{
    public class ConfigLoader
    {

        private string[] configuration;
        private double[] _speed = null;

        private List<double> speedRange;

        public ConfigLoader()
        {
            load();
            speedRange = new List<double>();
            foreach (string element in configuration[configuration.Length - 1].Split(','))
            { 
                speedRange.Add(double.Parse(element.Trim()));
            }
        }

        public int fps
        {
            get
            {
                return int.Parse(configuration[0]);
            }
        }

        public double playerSpeed
        {
            get
            {
                return double.Parse(configuration[1]);
            }
        }

        public double enemySpeed
        {
            get
            {
                return double.Parse(configuration[2]);
            }
        }

        public double[] speed
        {
            get
            {
                if (_speed != null)
                {
                    return _speed;
                }
                else
                {
                    _speed = new double[]
                    {
                        speedRange[new Random().Next(speedRange.Count)],
                        speedRange[new Random().Next(speedRange.Count)]
                    };
                    return _speed;
                }
            }
            set
            {
                _speed = value;
            }
        }

        public void invertHorisontalSpeed()
        {
            if (_speed != null)
            _speed[0] = -_speed[0];
        }

        public void invertVertcalSpeed()
        {
            if (_speed != null)
            _speed[1] = -_speed[1];
        }

        private void load()
        {
            if (File.Exists("./config.txt"))
            {
                configuration = File.ReadAllLines("./config.txt");
            } else
            {
                File.WriteAllLines("./config.txt", new string[] {
                    "90", "4", "2", "-5, -4, 4, 5" // Стандартный конфиг
                });
                load();
            }
        }

    }
}
