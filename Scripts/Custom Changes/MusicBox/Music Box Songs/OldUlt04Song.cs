using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.ContextMenus;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Items.MusicBox
{
    public class OldUlt04Song : MusicBoxTrack
    {
        [Constructable]
        public OldUlt04Song()
            : base(1075132)
        {
            Song = MusicName.OldUlt04;
            //Name = "Good End Game";
        }

        public OldUlt04Song(Serial s)
            : base(s)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}


