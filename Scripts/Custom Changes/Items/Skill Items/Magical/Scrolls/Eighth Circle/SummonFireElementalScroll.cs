using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SummonFireElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonFireElementalScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonFireElementalScroll( int amount ) : base( 62, 0x1F6B, amount )
		{
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				if ( this.Amount > 1 )
				{
					LabelTo( from, this.Amount + " summon fire elemental scrolls" );
				}
				else
				{
					LabelTo( from, "a summon fire elemental scroll" );
				}
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public SummonFireElementalScroll( Serial serial ) : base( serial )
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

		public override Item Dupe( int amount )
		{
			return base.Dupe( new SummonFireElementalScroll( amount ), amount );
		}
	}
}