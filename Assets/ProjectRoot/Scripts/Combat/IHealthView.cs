namespace Combat
{
    public interface IHealthView
    {

        public void OnHealthChanged(int health);

        public void OnHealthEnded();

        public void OnShieldEnded();

        public void OnShieldRestored();
    }
}