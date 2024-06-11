using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using XRL.UI;

namespace XRL.World.Parts.Mutation
{
    [Serializable]
    public class ChebGonaz_Reanimate : BaseMutation
    {
        public const string Command = "CommandReanimate";
        public const string Class = "Mental Mutation";
        public const string EnergyType = "Mental Mutation Reanimate";

        private readonly Dictionary<string, string> CorpseDictionary = new Dictionary<string, string>()
        {
            { "Human Corpse", "Templar" },
            { "Bat Corpse", "Bat" },
            { "Pig Corpse", "Pig" },
            { "Boar Corpse", "Boar" },
            { "Cave Spider Corpse", "Cave Spider" },
            { "Ray Cat Corpse", "Ray Cat" },
            { "Croc Corpse", "Croc" },
            { "Dog Corpse", "Dog" },
            { "Electrofuge Corpse", "Electrofuge" },
            { "Giant Beetle Corpse", "Giant Beetle" },
            { "Giant Centipede Corpse", "Giant Centipede" },
            { "Giant Dragonfly Corpse", "GiantDragonfly" },
            { "Glowfish Corpse", "Glowfish" },
            { "Goat Corpse", "Goat" },
            { "Horned Chameleon Corpse", "Horned Chameleon" },
            { "Qudzu Stem", "Qudzu" },
            { "Salamander Corpse", "Salamander" },
            { "Scorpiock Corpse", "Scorpiock" },
            { "Snapjaw Corpse", "Snapjaw" },
            { "Chute Crab Corpse", "Chute Crab" },
            { "Eyeless Crab Corpse", "Eyeless Crab" },
            { "Lahbloom", "Feral Lah" },
            { "Girshling Corpse", "Girshling" },
            { "Glowmoth Corpse", "Glowmoth" },
            { "Knollworm Corpse", "Knollworm" },
            { "Leech Corpse", "Leech" },
            { "Salthopper Corpse", "Salthopper" },
            { "Seedsprout Worm Corpse", "Seedsprout Worm" },
            { "Earthworm Corpse", "Worm of the Earth" },
            { "Naphtaali Corpse", "Naphtaali" },
            { "Hindren Corpse", "BaseHindren" },
            { "Albino ape corpse", "Albino ape" },
            { "Barkbiter Corpse", "Barkbiter" },
            { "Chitinous Puma Corpse", "Chitinous Puma" },
            { "Dawnglider Corpse", "Dawnglider" },
            { "Equimax Corpse", "Equimax" },
            { "Fire ant corpse", "Fire ant" },
            { "Fire Snout Corpse", "Fire Snout" },
            { "Ghost Perch Corpse", "Ghost Perch" },
            { "Ice frog corpse", "Ice frog" },
            { "quillipede corpse", "Quillipede" },
            { "Rustacean Corpse", "Rustacean" },
            { "Spark Tick Corpse", "Spark Tick" },
            { "Voider Corpse", "Voider" },
            { "Goatfolk Corpse", "Goatfolk" },
            { "Electric Snail Corpse", "Electric Snail" },
            { "Eyeless King Crab Corpse", "Eyeless King Crab" },
            { "BaseBreatherCorpse", "BaseBreather" },
            { "FireBreatherCorpse", "FireBreather" },
            { "IceBreatherCorpse", "IceBreather" },
            { "CorrosiveBreatherCorpse", "CorrosiveBreather" },
            { "NormalityBreatherCorpse", "NormalityBreather" },
            { "PoisonBreatherCorpse", "PoisonBreather" },
            { "SleepBreatherCorpse", "SleepBreather" },
            { "StunBreatherCorpse", "StunBreather" },
            { "ConfusionBreatherCorpse", "ConfusionBreather" },
            { "Troll Corpse", "Troll" },
            { "Agolzvuv Corpse", "Agolzvuv" },
            { "Bloated Pearlfrog Corpse", "Bloated Pearlfrog" },
            { "Gibbon Corpse", "Cyclopean Gibbon" },
            { "Mimic Corpse", "Mimic" },
            { "Molting Basilisk Husk", "Molting Basilisk" },
            { "Quartz Baboon Corpse", "Quartz Baboon" },
            { "Snailmother Corpse", "Snailmother" },
            { "Urchin Belcher Corpse", "Urchin Belcher" },
            { "Bone Worm Corpse", "Bone Worm" },
            { "Amaranthine Ashes", "Goatfolk Qlippoth" },
            { "Greater Voider Corpse", "Greater Voider" },
            { "Madpole Corpse", "Madpole" },
            { "Ogre ape corpse", "Ogre Ape" },
            { "Rhinox Corpse", "Rhinox" },
            { "BaseElderBreatherCorpse", "BaseElderBreather" },
            { "ElderFireBreatherCorpse", "ElderFireBreather" },
            { "ElderIceBreatherCorpse", "ElderIceBreather" },
            { "ElderCorrosiveBreatherCorpse", "ElderCorrosiveBreather" },
            { "ElderNormalityBreatherCorpse", "ElderNormalityBreather" },
            { "ElderPoisonBreatherCorpse", "ElderPoisonBreather" },
            { "ElderSleepBreatherCorpse", "ElderSleepBreather" },
            { "ElderStunBreatherCorpse", "ElderStunBreather" },
            { "ElderConfusionBreatherCorpse", "ElderConfusionBreather" },
            { "Enigma Snail Corpse", "Enigma Snail" },
            { "Great Saltback Corpse", "Great Saltback" },
            { "Kaleidoslug Corpse", "Kaleidoslug" },
            { "Memory Eater Corpse", "Memory Eater" },
            { "Sultan Croc Corpse", "Sultan Croc" },
            { "Svardym Corpse", "Svardym" },
            { "Saltwurm Corpse", "Saltwurm" },
            { "Unimax Corpse", "Unimax" },
            { "Urshiib Corpse", "Urshiib" },
            { "Dromad Corpse", "Dromad" },
            { "SlogCorpse", "GolgothaSlog" },
            { "Biomech Corpse", "BaseBiomech" },
        };

        public ChebGonaz_Reanimate()
        {
            DisplayName = "Reanimate";
            Type = "Mental";
        }

        public override void Register(GameObject go)
        {
            go.RegisterPartEvent(this, "CommandReanimate");
            base.Register(go);
        }

        public override string GetDescription() =>
            "You cause the target corpse to get up again under your control.";

        public override string GetLevelText(int level)
        {
            return $"level text {level}";
        }

        public bool CreateUndead()
        {
            var cell = PickDestinationCell(8, AllowVis.OnlyVisible);

            // check if corpse is at cell
            GameObject corpse = null;
            foreach (var objectInCell in cell.GetObjects())
            {
                if (objectInCell.IsAlive) continue;
                var last = objectInCell.Blueprint.Split(' ').Last();
                if (last.EndsWith("corpse", ignoreCase: true, CultureInfo.CurrentCulture))
                {
                    // dead thing found
                    corpse = objectInCell;
                    break;
                }
            }

            if (corpse == null)
            {
                Popup.Show("There are no valid targets in that square.");
                return false;
            }

            CooldownMyActivatedAbility(ActivatedAbilityID, 5);

            var go = GameObject.create(CorpseDictionary[corpse.Blueprint]);
            if (go.Brain != null)
            {
                go.RemovePart<Corpse>();
                go.DisplayName = $"Undead {go.DisplayName}";
                if (ParentObject.IsPlayer())
                    go.IsTrifling = true;
                go.Brain.AdjustFeeling(ParentObject, 100);
                go.Brain.SetPartyLeader(ParentObject);
                var GO = ParentObject;
                while (GO.Brain != null && (GO = GO.Brain.PartyLeader) != null && GO != ParentObject)
                    go.Brain.AdjustFeeling(GO, 100);
                //go.UpdateVisibleStatusColor();

                go.MakeActive();
                if (go.HasStat("XPValue"))
                    go.GetStat("XPValue").BaseValue = 0;
            }

            cell.AddObject(go);

            UseEnergy(100, EnergyType);

            corpse.Destroy();
            
            return true;
        }

        public override bool FireEvent(Event e) =>
            (e.ID != Command || CreateUndead()) && base.FireEvent(e);

        public override bool Mutate(GameObject go, int level = 1)
        {
            ActivatedAbilityID =
                AddMyActivatedAbility(DisplayName, Command, Class, Icon: "\r");
            return base.Mutate(go, level);
        }

        public override bool Unmutate(GameObject go)
        {
            RemoveMyActivatedAbility(ref ActivatedAbilityID);
            return base.Unmutate(go);
        }
    }
}