using Sandbox;

public class RealityCamera : Camera
{
	public override void Activated()
	{
		var pawn = Local.Pawn;
		if ( pawn == null ) return;

		Position = pawn.EyePos;
		Rotation = pawn.EyeRot;
	}

	public override void Build( ref CameraSetup camSetup )
	{
		base.Build( ref camSetup );

		camSetup.FieldOfView = 120;
	}

	public override void Update()
	{
		var pawn = Local.Pawn;
		if ( pawn == null ) return;

		var player = pawn as RealPlayer;
		var entity = pawn as ModelEntity;

		if ( player.Ragdoll != null )
			entity = player.Ragdoll;

		var eyes = entity.GetAttachment( "eyes" );
		var forward_reference = entity.GetAttachment( "forward_reference" );

		if ( eyes == null || forward_reference == null ) return;
		
		Position = eyes.Value.Position + forward_reference.Value.Rotation.Backward * 6 + forward_reference.Value.Rotation.Up * 8;
		Rotation = forward_reference.Value.Rotation;
	}
}
