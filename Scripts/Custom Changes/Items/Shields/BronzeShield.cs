using System;
using Server;

namespace Server.Items
{
	public class BronzeShield : BaseShield
	{
		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 1; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		public override int AosStrReq{ get{ return 35; } }

		public override int ArmorBase{ get{ return 10; } }

		[Constructable]
		public BronzeShield() : base( 0x1B72 )
		{
			Weight = 6.0;
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name  == null )
			{
				if ( this.Identified == true || ( this.Durability == ArmorDurabilityLevel.Regular && this.ProtectionLevel == ArmorProtectionLevel.Regular ) )
				{
					if ( this.Quality != ArmorQuality.Exceptional && this.LootType != LootType.Blessed )
					{
						LabelTo( from, "a bronze shield" );
					}
					else if ( this.Quality != ArmorQuality.Exceptional && this.LootType == LootType.Blessed )
					{
						LabelTo( from, "a blessed bronze shield" );
					}
					else if ( this.Quality == ArmorQuality.Exceptional )
					{
						if ( this.LootType != LootType.Blessed )
						{
							if ( this.Crafter == null )
							{
								LabelTo( from, "an exceptional bronze shield" );
							}
							else
							{
								LabelTo( from, "an exceptional bronze shield (crafted by:" + this.Crafter.Name + ")" );
							}
						}
						if ( this.LootType == LootType.Blessed )
						{
							if ( this.Crafter == null )
							{
								LabelTo( from, "a blessed, exceptional bronze shield" );
							}
							else
							{
								LabelTo( from, "a blessed, exceptional bronze shield (crafted by:" + this.Crafter.Name + ")" );
							}
						}
					}
				}
				else
				{
					LabelTo( from, "a magic bronze shield" );
				}
				base.OnSingleClick( from );
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public BronzeShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
