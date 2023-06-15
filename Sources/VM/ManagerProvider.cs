using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class ManagerProvider
    {
        private static ChampionManagerVM instance = null;
        public static ChampionManagerVM Instance
        {
            get
            {
                if (instance == null) { throw new Exception(message: "You have ton construct one ManagerProvider before acessing the instance..."); }
                return instance;
            }
        }


        public ManagerProvider(ChampionManagerVM manager) 
        {
            if(instance != null) { throw new Exception(message: "You cannot construct many instances of ManagerProvider..."); }
            instance = manager;
        }
    }
}
