﻿using Model;
using MvvmToolkit;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace VM
{
    public class ChampionManagerVM : BaseVmNoModel
    {

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions =  new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
        {
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            DataManager = dataManager;
            PropertyChanged += ToDoOnChange;
            MaxCount = DataManager.ChampionsMgr.GetNbItems().Result / Count +1;

            ////// Commands :

            NextPage = new Command(
                execute:() => {
                    Index++;
                }, 
                canExecute: () => {
                    return Index < MaxCount;
                });

            PreviousPage = new Command(
                execute: () => {
                    Index--;
                },
                canExecute: () => {
                    return Index > 1;
                });

            Index = 2;
        }

        public int Index {
            get => index;
            set {
                if (index == value) return;
                index = value;
                (NextPage as Command).ChangeCanExecute();
                (PreviousPage as Command).ChangeCanExecute();
                OnPropertyChanged();
            }
        }
        private int index = -1;

        private int Count { get; set; } = 6;

        private async void ToDoOnChange(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals(nameof(Index)) || e.PropertyName.Equals(nameof(Count)))
            {
                await LoadChampions(Index, Count);
            }
        }

        private async Task LoadChampions(int index, int count)
        {
            var theChampions = await DataManager.ChampionsMgr.GetItems(index-1, count, "Name");
            champions.Clear();
            foreach (var champion in theChampions)
            {
                champions.Add(new ChampionVM(champion));
            }
        }

        public int MaxCount { get => maxCount; private set { maxCount = value; } }
        private int maxCount;

        public ICommand NextPage { get; private set; }
        public ICommand PreviousPage { get; private set; }
    }
}