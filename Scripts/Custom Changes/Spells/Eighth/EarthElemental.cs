using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class EarthElementalSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Earth Elemental", "Kal Vas Xen Ylem",
				SpellCircle.Eighth,
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public EarthElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				TimeSpan duration = TimeSpan.FromSeconds( (2 * Caster.Skills.Magery.Fixed) / 5 );

				if ( Core.AOS )
					SpellHelper.Summon( new SummonedEarthElemental(), Caster, 0x217, duration, false, false );
				else
					SpellHelper.Summon( new EarthElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}

		public override TimeSpan GetCastDelay()
		{
			return base.GetCastDelay() + TimeSpan.FromSeconds( 10.0 );
		}
	}
}