using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SummonCreatureScroll : SpellScroll
	{
		[Constructable]
		public SummonCreatureScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonCreatureScroll( int amount ) : base( 39, 0x1F54, amount )
		{
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				if ( this.Amount > 1 )
				{
					LabelTo( from, this.Amount + " summon creature scrolls" );
				}
				else
				{
					LabelTo( from, "a summon creature scroll" );
				}
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public SummonCreatureScroll( Serial serial ) : base( serial )
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
			return base.Dupe( new SummonCreatureScroll( amount ), amount );
		}
	}
}