using System;
using Server;

namespace Server.Items
{
	[Flipable( 0x104D, 0x104E )]
	public class ClockFrame : Item
	{
		[Constructable]
		public ClockFrame() : this( 1 )
		{
		}

		[Constructable]
		public ClockFrame( int amount ) : base( 0x104D )
		{
			Stackable = true;
			Amount = amount;
			Weight = 2.0;
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				if ( this.Amount > 1 )
				{
					LabelTo( from, this.Amount + " clock frames" );
				}
				else
				{
					LabelTo( from, "a clock frame" );
				}
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public ClockFrame( Serial serial ) : base( serial )
		{
		}

		public override Item Dupe( int amount )
		{
			return base.Dupe( new ClockFrame(), amount );
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