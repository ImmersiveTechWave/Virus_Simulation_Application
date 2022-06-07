using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class CompareMaximum : Conditional
	{
		public SharedFloat ValueToCompare;
		public SharedFloat Value1;
		public SharedFloat Value2;
		public SharedFloat Value3;
		public SharedFloat Value4;
		public SharedFloat Value5;
		public SharedFloat Value6;
		public SharedFloat Value7;
		public SharedFloat Value8;
		public SharedFloat Value9;
		public bool CompareMin;

		public override void OnStart()
		{
			base.OnStart();
		}
		public override TaskStatus OnUpdate()
		{
			if (!CompareMin)
			{
				if (ValueToCompare.Value >= Value1?.Value && ValueToCompare.Value >= Value2?.Value
					&& ValueToCompare.Value >= Value3?.Value && ValueToCompare.Value >= Value4?.Value
					&& ValueToCompare.Value >= Value5?.Value && ValueToCompare.Value >= Value6?.Value
					&& ValueToCompare.Value >= Value7?.Value && ValueToCompare.Value >= Value8?.Value
					&& ValueToCompare.Value >=  Value9?.Value)
				{
					return TaskStatus.Success;
				}
			}
			else
			{
				if (ValueToCompare.Value < Value1?.Value && ValueToCompare.Value <= Value2?.Value
					&& ValueToCompare.Value <= Value3?.Value && ValueToCompare.Value <= Value4?.Value
					&& ValueToCompare.Value <= Value5?.Value && ValueToCompare.Value <= Value6?.Value
					&& ValueToCompare.Value <= Value7?.Value && ValueToCompare.Value <= Value8?.Value
					&& ValueToCompare.Value <= Value9?.Value)
				{
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
