using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B9, 0x13Ba )]
	public class VikingSword : BaseSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 28; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public VikingSword() : base( 0x13B9 )
		{
			Weight = 6.0;
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Identified == true || ( this.Slayer == SlayerName.None && this.DurabilityLevel == WeaponDurabilityLevel.Regular && this.DamageLevel == WeaponDamageLevel.Regular && this.AccuracyLevel == WeaponAccuracyLevel.Regular ) )
			{
				if ( this.Quality != WeaponQuality.Exceptional && this.LootType != LootType.Blessed )
				{
					if ( this.PoisonCharges < 1 )
					{
						from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a viking sword" ) );
					}
					else
					{
						from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a poisoned viking sword" ) );
						from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
					}
				}
				else if ( this.Quality != WeaponQuality.Exceptional && this.LootType == LootType.Blessed )
				{
						from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a blessed viking sword" ) );
					if ( this.PoisonCharges > 0 )
					{
						from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
					}
				}
				else if ( this.Quality == WeaponQuality.Exceptional )
				{
					if ( this.LootType != LootType.Blessed )
					{
						if ( this.Crafter == null )
						{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "an exceptional viking sword" ) );
								if ( this.PoisonCharges > 0 )
								{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
								}
						}
						else
						{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "an exceptional viking sword (crafted by:" + this.Crafter.Name + ")" ) );
								if ( this.PoisonCharges > 0 )
								{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
								}
						}
					}
					if ( this.LootType == LootType.Blessed )
					{
						if ( this.Crafter == null )
						{
							from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a blessed, exceptional viking sword" ) );
							if ( this.PoisonCharges > 0 )
							{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
							}
						}
						else
						{
							from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a blessed, exceptional viking sword (crafted by:" + this.Crafter.Name + ")" ) );
							if ( this.PoisonCharges > 0 )
							{
								from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
							}
						}
					}
				}
			}
			else
			{
				from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "a magic viking sword" ) );
				if ( this.PoisonCharges > 0 )
				{
					from.Send( new AsciiMessage( this.Serial, 0, MessageType.Label, 0x3B2, 3, null, "(poison charges:" + this.PoisonCharges + ")" ) );
				}
			}
			base.OnSingleClick( from );
		}

		public VikingSword( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
