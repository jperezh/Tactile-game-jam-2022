using UnityEngine;

namespace Code.Tower
{
    public class LoseConditionChecker : MonoBehaviour
    {
        [SerializeField] private Water water;
        [SerializeField] private TowerArea warmTowerArea;
        [SerializeField] private TowerArea coldTowerArea;

        public bool HasWarmTeamLost { get; private set; }
        public bool HasColdTeamLost { get; private set; }
        
        private void Update()
        {
            if (!water.IsRising) return;

            float waterLevel = water.GetLevel();

            HasWarmTeamLost = HasLost(warmTowerArea, waterLevel);
            HasColdTeamLost = HasLost(coldTowerArea, waterLevel);
        }

        private bool HasLost(TowerArea towerArea, float waterLevel)
        {
            foreach (var block in towerArea.Blocks)
            {
                if (block.transform.position.y > waterLevel)
                {
                    return false;
                }
            }

            return true;
        }
    }
}