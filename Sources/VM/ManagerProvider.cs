
namespace VM
{
    public class ManagerProvider
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        private static ChampionManagerVM instance = null;
        public static ChampionManagerVM Instance
        {
            get
            {
                if (instance == null) { throw new Exception(message: "You have ton construct one ManagerProvider before acessing the instance..."); }
                return instance;
            }
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ManagerProvider(ChampionManagerVM manager)
        {
            if (instance != null) { throw new Exception(message: "You cannot construct many instances of ManagerProvider..."); }
            instance = manager;
        }
    }
}
