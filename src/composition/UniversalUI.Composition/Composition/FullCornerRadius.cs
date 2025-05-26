namespace UniversalUI.Composition;

internal partial record struct FullCornerRadius
(
	NonUniformCornerRadius Outer,
	NonUniformCornerRadius Inner
)
{
	public static FullCornerRadius None { get; }

	public bool IsEmpty => Outer.IsEmpty && Inner.IsEmpty;
}
