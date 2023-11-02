namespace Assets.Scripts.Characters
{
    abstract class BaseStats
    {
        private string name;

        protected BaseStats()
        {
        }

        public BaseStats(string name)
        {
            this.name = name;
        }

        public abstract void Equip(PlayerStats playerStats);
        public abstract void Unequip(PlayerStats playerStats);


    }
}

