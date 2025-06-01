// This file is copied, with modifications, from the Uno project

using System.Numerics;

namespace UniversalUI.Media;

partial class NativeRenderTransformAdapter
{
	partial void Initialized()
	{
		// Apply the transform as soon as its been declared
		Update();
	}

	partial void Apply(bool isSizeChanged, bool isOriginChanged)
	{
		FlowDirectionTransform = Owner.GetFlowDirectionTransform();

		if (Transform is null)
		{
			Owner.Visual.TransformMatrix = new Matrix4x4(FlowDirectionTransform);
		}
		else
		{
			Owner.Visual.TransformMatrix = new Matrix4x4(Transform.ToMatrix(CurrentOrigin, CurrentSize) * FlowDirectionTransform);
		}
	}

	partial void Cleanup()
	{
		FlowDirectionTransform = Matrix3x2.Identity;
		Owner.Visual.TransformMatrix = Matrix4x4.Identity;
	}
}
