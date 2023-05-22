﻿using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmToolkit;

namespace VM
{
    public class ChampionVM : BaseVM<Champion>
    {
        public ChampionVM()
            : base(new Champion("New Champion", ChampionClass.Fighter, "", "", ""))
        {}

        public ChampionVM(Champion model) : base(model) { }

        public string Name
        {
            get => Model?.Name;
        }

        public string Icon
        {
            get => Model?.Icon;
            set
            {
                if (Model == (null) || Model.Icon.Equals(value)) return;
                Model.Icon = value;
                OnPropertyChanged();
            }
        }

        public ChampionClass ChampionClassClass
        {
            get => Model.Class;
            set
            {
                if (Model == (null) || Model.Class.Equals(value)) return;
                Model.Class = value;
                OnPropertyChanged();
            }
        }

    }
}
