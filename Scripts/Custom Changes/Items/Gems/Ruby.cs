using System;
using Server;

namespace Server.Items
{
	public class Ruby : Item
	{
		[Constructable]
		public Ruby() : this( 1 )
		{
		}

		[Constructable]
		public Ruby( int amount ) : base( 0xF13 )
		{
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
		}


		public override void OnSingleClick( Mobile from )
		{
			if ( this.Amount > 1 )
			{
				LabelTo( from, this.Amount + " rubies" );
			}
			else
			{
				LabelTo( from, "a ruby" );
			}
		}

		public Ruby( Serial serial ) : base( serial )
		{
		}

		public override Item Dupe( int amount )
		{
			return base.Dupe( new Ruby( amount ), amount );
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
