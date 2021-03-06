using System;

namespace Server.Items
{
	public class Beeswax : Item
	{
		[Constructable]
		public Beeswax() : this( 1 )
		{
		}

		[Constructable]
		public Beeswax( int amount ) : base( 0x1422 )
		{
			Weight = 1.0;
			Stackable = true;
			Amount = amount;
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				LabelTo( from, "beeswax" );
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public Beeswax( Serial serial ) : base( serial )
		{
		}

		public override Item Dupe( int amount )
		{
			return base.Dupe( new Beeswax( amount ), amount );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}