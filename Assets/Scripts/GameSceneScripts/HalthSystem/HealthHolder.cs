namespace GameSceneScripts.HalthSystem
{
    public class HealthHolder
    {
        private float _currentHealthValue;
        public HealthHolder(float initHealthValue)
        {
            _currentHealthValue = initHealthValue;
        }

        public void UpdateHealth(float value)
        {
            _currentHealthValue += value;
        }

        public float GetHealthValue()
        {
            return _currentHealthValue;
        }
    }
}