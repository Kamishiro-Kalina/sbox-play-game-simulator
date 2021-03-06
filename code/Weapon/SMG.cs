using Sandbox;
using System;

[Library( "pg_smg", Title = "SMG", Spawnable = true )]
[Hammer.EditorModel( "weapons/rust_smg/rust_smg.vmdl" )]
partial class SMG : Weapon
{ 
	public override string ViewModelPath => "weapons/rust_smg/v_rust_smg.vmdl";
	public override string WorldModelPath => "weapons/rust_smg/rust_smg.vmdl";
	public override BaseViewModel ViewModel => new InGamePlayerViewModel();

	public override int ClipSize => 30;
	public override float PrimaryRate => 15.0f;
	public override float SecondaryRate => 1.0f;
	public override float ReloadTime => 4.0f;
	public override int Bucket => 0;
	public override CType Crosshair => CType.SMG;
	public override string Icon => "ui/weapons/weapon_smg.png";
	public override string ShootSound => "rust_smg.shoot";
	public override float Spread => 0.1f;
	public override float Force => 1.5f;
	public override float Damage => 5.0f;
	public override float BulletSize => 3.0f;
	public override ScreenShake ScreenShake => new ScreenShake
	{
		Length = 0.5f,
		Speed = 4.0f,
		Size = 1.0f,
		Rotation = 0.5f
	};

	public override void AttackSecondary()
	{
		// Grenade lob
	}

	public override void SimulateAnimator( PawnAnimator anim )
	{
		anim.SetParam( "holdtype", 2 ); // TODO this is shit
		anim.SetParam( "aimat_weight", 1.0f );
	}
}
