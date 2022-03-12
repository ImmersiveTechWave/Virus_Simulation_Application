using BehaviorDesigner.Runtime;
using System;

namespace MF
{
    [Serializable]
    public struct UtilityScore
    {
        public float Score;
        public bool IsLocked;

        public UtilityScore(float score, bool isLocked)
        {
            Score = score;
            IsLocked = isLocked;
        }
    }

    public class SharedUtilityScore : SharedVariable<UtilityScore>
    {
        public static implicit operator SharedUtilityScore(UtilityScore value) { return new SharedUtilityScore { mValue = value }; }

        public override string ToString()
        {
            return "Score: " + Value.Score + " - " + Value.IsLocked;
        }
    }
}
