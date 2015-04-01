using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterFarm.TestWPF.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<GameObject> Items { get; set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<GameObject>();

            Items.Add(new GameObject() { Top = 0, Left = 0, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 120, Left = 120, Type = "Fox" });
            Items.Add(new GameObject() { Top = 160, Left = 200, Type = "Lamb" });
            Items.Add(new GameObject() { Top = 400, Left = 280, Type = "Hen" });
            Items.Add(new GameObject() { Top = 80, Left = 320, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 120, Left = 40, Type = "Lamb" });
            Items.Add(new GameObject() { Top = 120, Left = 80, Type = "Lamb" });
            Items.Add(new GameObject() { Top = 320, Left = 320, Type = "Fox" });
            Items.Add(new GameObject() { Top = 40, Left = 80, Type = "Raspberry" });
            Items.Add(new GameObject() { Top = 200, Left = 120, Type = "Bluepberry" });
            Items.Add(new GameObject() { Top = 240, Left = 120, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 160, Left = 320, Type = "Raspberry" });
            Items.Add(new GameObject() { Top = 480, Left = 640, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 720, Left = 120, Type = "Fox" });
            Items.Add(new GameObject() { Top = 800, Left = 1240, Type = "Hen" });
            Items.Add(new GameObject() { Top = 600, Left = 800, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 840, Left = 400, Type = "Lamb" });
            Items.Add(new GameObject() { Top = 520, Left = 600, Type = "Hen" });
            Items.Add(new GameObject() { Top = 120, Left = 240, Type = "Lamb" });
            Items.Add(new GameObject() { Top = 320, Left = 720, Type = "Fox" });
            Items.Add(new GameObject() { Top = 400, Left = 640, Type = "Raspberry" });
            Items.Add(new GameObject() { Top = 600, Left = 320, Type = "Bluepberry" });
            Items.Add(new GameObject() { Top = 840, Left = 120, Type = "Wolf" });
            Items.Add(new GameObject() { Top = 760, Left = 720, Type = "Raspberry" });
        }
    }

    public class GameObject
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public string Type { get; set; }
    }
}
