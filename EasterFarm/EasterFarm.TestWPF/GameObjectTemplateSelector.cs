using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EasterFarm.TestWPF.ViewModels;

using EasterFarm.Common;
using EasterFarm.GameLogic;
using EasterFarm.Models;
using EasterFarm.Models.FarmObjects.Animals;
using EasterFarm.Models.FarmObjects.Byproducts;
using EasterFarm.Models.FarmObjects.Food;

namespace EasterFarm.TestWPF
{
    class GameObjectTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WolfTemplate { get; set; }
        public DataTemplate FoxTemplate { get; set; }
        public DataTemplate LambTemplate { get; set; }
        public DataTemplate HenTemplate { get; set; }
        public DataTemplate RaspberryTemplate { get; set; }
        public DataTemplate BlueberryTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            GameObject o = item as GameObject;
            switch (o.GetType().Name)
            {
                case "Wolf":
                    return WolfTemplate;
                case "Fox":
                    return FoxTemplate;
                case "Lamb":
                    return LambTemplate;
                case "Hen":
                    return HenTemplate;
                case "Raspberry":
                    return RaspberryTemplate;
                case "Blueberry":
                    return BlueberryTemplate;
                case "Egg":
                //    return EggTemplate;
                //case "TrophyEgg":
                //    return TrophyEggTemplate;
                //case "Milk":
                //    return MilkTemplate;
                //case "Rabbit":
                //    return MilkTemplate;
                default: return null;
            }
            //if (o.Type == 0) return Template1;
            //else if (o.Type == 1) return Template2;
            //else return Template3;
        }
    }
}
