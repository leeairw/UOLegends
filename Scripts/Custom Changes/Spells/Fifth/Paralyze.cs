using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Fifth
{
	public class ParalyzeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Paralyze", "An Ex Por",
				SpellCircle.Fifth,
				218,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public ParalyzeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendAsciiMessage( "Target can not be seen." );
			}
			else if ( Core.AOS && (m.Frozen || m.Paralyzed || (m.Spell != null && m.Spell.IsCasting)) )
			{
				Caster.SendAsciiMessage( "The target is already frozen." );
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				double duration;
				double damage;
				
				if ( Core.AOS )
				{
					int baseDamage = 1 + (int)(GetDamageSkill( Caster ) / 5);
					damage = Utility.RandomMinMax( baseDamage, baseDamage + 3 );
					damage += (int)(damage * GetInscribeSkill( Caster ) * 0.001);
					int secs = 2 + (GetDamageFixed( Caster ) / 100) - (GetResistFixed( m ) / 100);

					if ( !m.Player )
						secs *= 3;

					if ( secs < 0 )
						secs = 0;
				damage = Utility.Random( 1, 1 );

				damage *= GetDamageScalar( m );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );

				// Scale damage based on evalint and resist
				damage *= GetDamageScalar( m );

					duration = secs;
				}
				else
				{
					// Algorithm: ((20% of magery) + 7) seconds [- 50% if resisted]

					duration = 7.0 + (Caster.Skills[SkillName.Magery].Value * 0.2);

					damage = Utility.Random( 1, 3 );

					if ( CheckResisted( m ) )
						duration *= 0.75;
						damage *= 1.25;

				}
				damage *= GetDamageScalar( m );

				// Deal the damage
				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
				damage = Utility.Random( 1, 1 );
				m.Paralyze( TimeSpan.FromSeconds( duration ) );

				m.PlaySound( 0x204 );
				m.FixedEffect( 0x376A, 6, 1 );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private ParalyzeSpell m_Owner;

			public InternalTarget( ParalyzeSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

		public override TimeSpan GetCastDelay()
		{
			return base.GetCastDelay() + TimeSpan.FromSeconds( 2.5 );
		}
	}
}
