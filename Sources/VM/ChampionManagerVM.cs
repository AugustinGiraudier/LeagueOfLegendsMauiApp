﻿using Model;
using MvvmToolkit;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace VM
{
    public class ChampionManagerVM : BaseVmNoModel
    {

        public INavigation Navigation { get; set; }

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions =  new ObservableCollection<ChampionVM>();

        private IDataManager DataManager { get; set; }

        public ChampionManagerVM(IDataManager dataManager)
        {
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
            DataManager = dataManager;
            PropertyChanged += ToDoOnChange;
            updateMaxCount();

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
            
            RemoveChampion = new Command<ChampionVM>(
                execute: (ChampionVM chp) => {
                    DataManager.ChampionsMgr.DeleteItem(chp.Model);
                    updateMaxCount();
                    OnPropertyChanged(nameof(Index));
                });

            Index = 1;
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

        private int Count { get; set; } = 5;

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

        public int MaxCount { 
            get => maxCount; 
            private set { 
                maxCount = value;
                if (NextPage != null)       (NextPage as Command).ChangeCanExecute();
                if (PreviousPage != null)   (PreviousPage as Command).ChangeCanExecute();
                if(Index > MaxCount)
                    Index = MaxCount;
                OnPropertyChanged();
            } 
        }
        private int maxCount;

        private void updateMaxCount()
        {
            MaxCount = (int)Math.Ceiling((double)DataManager.ChampionsMgr.GetNbItems().Result / Count);
        }

        public ICommand NextPage { get; private set; }
        public ICommand PreviousPage { get; private set; }

        public ICommand RemoveChampion { get; private set; }
    }
}
