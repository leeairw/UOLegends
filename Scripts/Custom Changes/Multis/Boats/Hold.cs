using System;
using Server;
using Server.Multis;

namespace Server.Items
{
	public class Hold : Container
	{
		private BaseBoat m_Boat;

		public override int DefaultGumpID{ get{ return 0x4C; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 46, 74, 150, 110 ); }
		}

		public Hold( BaseBoat boat ) : base( 0x3EAE )
		{
			m_Boat = boat;
			Movable = false;
		}

		public Hold( Serial serial ) : base( serial )
		{
		}

		public void SetFacing( Direction dir )
		{
			switch ( dir )
			{
				case Direction.East:  ItemID = 0x3E65; break;
				case Direction.West:  ItemID = 0x3E93; break;
				case Direction.North: ItemID = 0x3EAE; break;
				case Direction.South: ItemID = 0x3EB9; break;
			}
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( m_Boat == null || !m_Boat.Contains( from ) || m_Boat.IsMoving )
				return false;

			return base.OnDragDrop( from, item );
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			if ( m_Boat == null || !m_Boat.Contains( from ) || m_Boat.IsMoving )
				return false;

			return base.OnDragDropInto( from, item, p );
		}

		public override bool CheckItemUse( Mobile from, Item item )
		{
			if ( item != this && (m_Boat == null || !m_Boat.Contains( from ) || m_Boat.IsMoving) )
				return false;

			return base.CheckItemUse( from, item );
		}

		public override bool CheckLift( Mobile from, Item item )
		{
			if ( m_Boat == null || !m_Boat.Contains( from ) || m_Boat.IsMoving )
				return false;

			return base.CheckLift( from, item );
		}

		public override void OnAfterDelete()
		{
			if ( m_Boat != null )
				m_Boat.Delete();
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( this.Name == null )
			{
				LabelTo( from, "a hold");
			}
			else
			{
				LabelTo( from, this.Name );
			}
			LabelTo( from, "({0} items, {1} stones)", TotalItems, TotalWeight );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Boat == null || !m_Boat.Contains( from ) )
			{
				if ( m_Boat.TillerMan != null )
					m_Boat.TillerMan.Say( 502490 ); // You must be on the ship to open the hold.
			}
			else if ( m_Boat.IsMoving )
			{
				if ( m_Boat.TillerMan != null )
					m_Boat.TillerMan.Say( 502491 ); // I can not open the hold while the ship is moving.
			}
			else
			{
				base.OnDoubleClick( from );
			}
		}

		public override bool CanStore( Mobile m )
		{
			return true; 
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );

			writer.Write( m_Boat );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Boat = reader.ReadItem() as BaseBoat;

					if ( m_Boat == null || Parent != null )
						Delete();

					Movable = false;

					break;
				}
			}
		}
	}
}