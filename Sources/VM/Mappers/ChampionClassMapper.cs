using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace VM.Mappers
{
    public class ChampionClassMapper
    {

        private static HashSet<Tuple<ChampionClass, ChampionClassVM>> mapper = new HashSet<Tuple<ChampionClass, ChampionClassVM>>
        {
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Unknown,ChampionClassVM.Unknown),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Assassin,ChampionClassVM.Assassin),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Fighter,ChampionClassVM.Fighter),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Mage,ChampionClassVM.Mage),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Marksman,ChampionClassVM.Marksman),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Support,ChampionClassVM.Support),
            new Tuple<ChampionClass, ChampionClassVM>(ChampionClass.Tank,ChampionClassVM.Tank),
        };


        public static ChampionClass getModel(ChampionClassVM vm)
        {
           return  mapper.FirstOrDefault(x => x.Item2.Equals(vm)).Item1;
        }

        public static ChampionClassVM getVM(ChampionClass model)
        {
            return mapper.FirstOrDefault(x => x.Item1.Equals(model)).Item2;
        }

    }
}
