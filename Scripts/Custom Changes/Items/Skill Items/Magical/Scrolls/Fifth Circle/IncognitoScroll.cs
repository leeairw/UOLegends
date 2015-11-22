using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class IncognitoScroll : SpellScroll
	{
		[Constructable]
		public IncognitoScroll() : this( 1 )
		{
		}

		[Constructable]
		public IncognitoScroll( int amount ) : base( 34, 0x1F4F, amount )
		{
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				if ( this.Amount > 1 )
				{
					LabelTo( from, this.Amount + " incognito scrolls" );
				}
				else
				{
					LabelTo( from, "an incognito scroll" );
				}
			}
			else
			{
				LabelTo( from, this.Name );
			}
		}

		public IncognitoScroll( Serial serial ) : base( serial )
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
			return base.Dupe( new IncognitoScroll( amount ), amount );
		}
	}
}