using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            { "Human Corpse", "ChebGonaz Undead Templar" },
            { "Bat Corpse", "ChebGonaz Undead Bat" },
            { "Pig Corpse", "ChebGonaz Undead Pig" },
            { "Boar Corpse", "ChebGonaz Undead Boar" },
            { "Cave Spider Corpse", "ChebGonaz Undead Cave Spider" },
            { "Ray Cat Corpse", "ChebGonaz Undead Ray Cat" },
            { "Croc Corpse", "ChebGonaz Undead Croc" },
            { "Dog Corpse", "ChebGonaz Undead Dog" },
            { "Electrofuge Corpse", "ChebGonaz Undead Electrofuge" },
            { "Giant Beetle Corpse", "ChebGonaz Undead Giant Beetle" },
            { "Giant Centipede Corpse", "ChebGonaz Undead Giant Centipede" },
            { "Giant Dragonfly Corpse", "ChebGonaz Undead GiantDragonfly" },
            { "Glowfish Corpse", "ChebGonaz Undead Glowfish" },
            { "Goat Corpse", "ChebGonaz Undead Goat" },
            { "Horned Chameleon Corpse", "ChebGonaz Undead Horned Chameleon" },
            { "Qudzu Stem", "ChebGonaz Undead Qudzu" },
            { "Salamander Corpse", "ChebGonaz Undead Salamander" },
            { "Scorpiock Corpse", "ChebGonaz Undead Scorpiock" },
            { "Snapjaw Corpse", "ChebGonaz Undead Snapjaw" },
            { "Chute Crab Corpse", "ChebGonaz Undead Chute Crab" },
            { "Eyeless Crab Corpse", "ChebGonaz Undead Eyeless Crab" },
            { "Lahbloom", "ChebGonaz Undead Feral Lah" },
            { "Girshling Corpse", "ChebGonaz Undead Girshling" },
            { "Glowmoth Corpse", "ChebGonaz Undead Glowmoth" },
            { "Knollworm Corpse", "ChebGonaz Undead Knollworm" },
            { "Leech Corpse", "ChebGonaz Undead Leech" },
            { "Salthopper Corpse", "ChebGonaz Undead Salthopper" },
            { "Seedsprout Worm Corpse", "ChebGonaz Undead Seedsprout Worm" },
            { "Earthworm Corpse", "ChebGonaz Undead Worm of the Earth" },
            { "Naphtaali Corpse", "ChebGonaz Undead Naphtaali" },
            { "Hindren Corpse", "ChebGonaz Undead BaseHindren" },
            { "Albino ape corpse", "ChebGonaz Undead Albino ape" },
            { "Barkbiter Corpse", "ChebGonaz Undead Barkbiter" },
            { "Chitinous Puma Corpse", "ChebGonaz Undead Chitinous Puma" },
            { "Dawnglider Corpse", "ChebGonaz Undead Dawnglider" },
            { "Equimax Corpse", "ChebGonaz Undead Equimax" },
            { "Fire ant corpse", "ChebGonaz Undead Fire ant" },
            { "Fire Snout Corpse", "ChebGonaz Undead Fire Snout" },
            { "Ghost Perch Corpse", "ChebGonaz Undead Ghost Perch" },
            { "Ice frog corpse", "ChebGonaz Undead Ice frog" },
            { "quillipede corpse", "ChebGonaz Undead Quillipede" },
            { "Rustacean Corpse", "ChebGonaz Undead Rustacean" },
            { "Spark Tick Corpse", "ChebGonaz Undead Spark Tick" },
            { "Voider Corpse", "ChebGonaz Undead Voider" },
            { "Goatfolk Corpse", "ChebGonaz Undead Goatfolk" },
            { "Electric Snail Corpse", "ChebGonaz Undead Electric Snail" },
            { "Eyeless King Crab Corpse", "ChebGonaz Undead Eyeless King Crab" },
            { "BaseBreatherCorpse", "ChebGonaz Undead BaseBreather" },
            { "FireBreatherCorpse", "ChebGonaz Undead FireBreather" },
            { "IceBreatherCorpse", "ChebGonaz Undead IceBreather" },
            { "CorrosiveBreatherCorpse", "ChebGonaz Undead CorrosiveBreather" },
            { "NormalityBreatherCorpse", "ChebGonaz Undead NormalityBreather" },
            { "PoisonBreatherCorpse", "ChebGonaz Undead PoisonBreather" },
            { "SleepBreatherCorpse", "ChebGonaz Undead SleepBreather" },
            { "StunBreatherCorpse", "ChebGonaz Undead StunBreather" },
            { "ConfusionBreatherCorpse", "ChebGonaz Undead ConfusionBreather" },
            { "Troll Corpse", "ChebGonaz Undead Troll" },
            { "Agolzvuv Corpse", "ChebGonaz Undead Agolzvuv" },
            { "Bloated Pearlfrog Corpse", "ChebGonaz Undead Bloated Pearlfrog" },
            { "Gibbon Corpse", "ChebGonaz Undead Cyclopean Gibbon" },
            { "Mimic Corpse", "ChebGonaz Undead Mimic" },
            { "Molting Basilisk Husk", "ChebGonaz Undead Molting Basilisk" },
            { "Quartz Baboon Corpse", "ChebGonaz Undead Quartz Baboon" },
            { "Snailmother Corpse", "ChebGonaz Undead Snailmother" },
            { "Urchin Belcher Corpse", "ChebGonaz Undead Urchin Belcher" },
            { "Bone Worm Corpse", "ChebGonaz Undead Bone Worm" },
            { "Amaranthine Ashes", "ChebGonaz Undead Goatfolk Qlippoth" },
            { "Greater Voider Corpse", "ChebGonaz Undead Greater Voider" },
            { "Madpole Corpse", "ChebGonaz Undead Madpole" },
            { "Ogre ape corpse", "ChebGonaz Undead Ogre Ape" },
            { "Rhinox Corpse", "ChebGonaz Undead Rhinox" },
            { "BaseElderBreatherCorpse", "ChebGonaz Undead BaseElderBreather" },
            { "ElderFireBreatherCorpse", "ChebGonaz Undead ElderFireBreather" },
            { "ElderIceBreatherCorpse", "ChebGonaz Undead ElderIceBreather" },
            { "ElderCorrosiveBreatherCorpse", "ChebGonaz Undead ElderCorrosiveBreather" },
            { "ElderNormalityBreatherCorpse", "ChebGonaz Undead ElderNormalityBreather" },
            { "ElderPoisonBreatherCorpse", "ChebGonaz Undead ElderPoisonBreather" },
            { "ElderSleepBreatherCorpse", "ChebGonaz Undead ElderSleepBreather" },
            { "ElderStunBreatherCorpse", "ChebGonaz Undead ElderStunBreather" },
            { "ElderConfusionBreatherCorpse", "ChebGonaz Undead ElderConfusionBreather" },
            { "Enigma Snail Corpse", "ChebGonaz Undead Enigma Snail" },
            { "Great Saltback Corpse", "ChebGonaz Undead Great Saltback" },
            { "Kaleidoslug Corpse", "ChebGonaz Undead Kaleidoslug" },
            { "Memory Eater Corpse", "ChebGonaz Undead Memory Eater" },
            { "Sultan Croc Corpse", "ChebGonaz Undead Sultan Croc" },
            { "Svardym Corpse", "ChebGonaz Undead Svardym" },
            { "Saltwurm Corpse", "ChebGonaz Undead Saltwurm" },
            { "Unimax Corpse", "ChebGonaz Undead Unimax" },
            { "Urshiib Corpse", "ChebGonaz Undead Urshiib" },
            { "Dromad Corpse", "ChebGonaz Undead Dromad" },
            { "SlogCorpse", "ChebGonaz Undead GolgothaSlog" },
            { "Biomech Corpse", "ChebGonaz Undead BaseBiomech" },
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
            if (go.pBrain != null)
            {
                go.DisplayName = $"Undead {go.DisplayName}";
                if (ParentObject.IsPlayer())
                    go.IsTrifling = true;
                go.pBrain.SetFeeling(ParentObject, 100);
                go.pBrain.PartyLeader = ParentObject;
                var GO = ParentObject;
                while (GO.pBrain != null && (GO = GO.pBrain.PartyLeader) != null && GO != ParentObject)
                    go.pBrain.SetFeeling(GO, 100);
                go.UpdateVisibleStatusColor();

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