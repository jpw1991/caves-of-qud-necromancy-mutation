using System;
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

        private string GetBlueprintFromCorpse(string corpseBlueprint)
        {
            // there's no link between a corpse and what it was before, from what I can tell, so let's hardcode them
            // all
            string result = "";

            switch (corpseBlueprint)
            {
                case "Human Corpse":
                    result = "Templar";
                    break;
                case "Bat Corpse":
                    result = "Bat";
                    break;
                case "Pig Corpse":
                    result = "Pig";
                    break;
                case "Boar Corpse":
                    result = "Boar";
                    break;
                case "Cave Spider Corpse":
                    result = "Cave Spider";
                    break;
                case "Ray Cat Corpse":
                    result = "Ray Cat";
                    break;
                case "Croc Corpse":
                    result = "Croc";
                    break;
                case "Dog Corpse":
                    result = "Dog";
                    break;
                case "Electrofuge Corpse":
                    result = "Electrofuge";
                    break;
                case "Giant Beetle Corpse":
                    result = "Giant Beetle";
                    break;
                case "Giant Centipede Corpse":
                    result = "Giant Centipede";
                    break;
                case "Giant Dragonfly Corpse":
                    result = "GiantDragonfly";
                    break;
                case "Glowfish Corpse":
                    result = "Glowfish";
                    break;
                case "Goat Corpse":
                    result = "Goat";
                    break;
                case "Horned Chameleon Corpse":
                    result = "Horned Chameleon";
                    break;
                case "Qudzu Stem":
                    result = "Qudzu";
                    break;
                case "Salamander Corpse":
                    result = "Salamander";
                    break;
                case "Scorpiock Corpse":
                    result = "Scorpiock";
                    break;
                case "Snapjaw Corpse":
                    result = "Snapjaw";
                    break;
                case "Chute Crab Corpse":
                    result = "Chute Crab";
                    break;
                case "Eyeless Crab Corpse":
                    result = "Eyeless Crab";
                    break;
                case "Lahbloom":
                    result = "Feral Lah";
                    break;
                case "Girshling Corpse":
                    result = "Girshling";
                    break;
                case "Glowmoth Corpse":
                    result = "Glowmoth";
                    break;
                case "Knollworm Corpse":
                    result = "Knollworm";
                    break;
                case "Leech Corpse":
                    result = "Leech";
                    break;
                case "Salthopper Corpse":
                    result = "Salthopper";
                    break;
                case "Seedsprout Worm Corpse":
                    result = "Seedsprout Worm";
                    break;
                case "Earthworm Corpse":
                    result = "Worm of the Earth";
                    break;
                case "Naphtaali Corpse":
                    result = "Naphtaali";
                    break;
                case "Hindren Corpse":
                    result = "BaseHindren";
                    break;
                case "Albino ape corpse":
                    result = "Albino ape";
                    break;
                case "Barkbiter Corpse":
                    result = "Barkbiter";
                    break;
                case "Chitinous Puma Corpse":
                    result = "Chitinous Puma";
                    break;
                case "Dawnglider Corpse":
                    result = "Dawnglider";
                    break;
                case "Equimax Corpse":
                    result = "Equimax";
                    break;
                case "Fire ant corpse":
                    result = "Fire ant";
                    break;
                case "Fire Snout Corpse":
                    result = "Fire Snout";
                    break;
                case "Ghost Perch Corpse":
                    result = "Ghost Perch";
                    break;
                case "Ice frog corpse":
                    result = "Ice frog";
                    break;
                case "quillipede corpse":
                    result = "Quillipede";
                    break;
                case "Rustacean Corpse":
                    result = "Rustacean";
                    break;
                case "Spark Tick Corpse":
                    result = "Spark Tick";
                    break;
                case "Voider Corpse":
                    result = "Voider";
                    break;
                case "Goatfolk Corpse":
                    result = "Goatfolk";
                    break;
                case "Electric Snail Corpse":
                    result = "Electric Snail";
                    break;
                case "Eyeless King Crab Corpse":
                    result = "Eyeless King Crab";
                    break;
                case "BaseBreatherCorpse":
                    result = "BaseBreather";
                    break;
                case "FireBreatherCorpse":
                    result = "FireBreather";
                    break;
                case "IceBreatherCorpse":
                    result = "IceBreather";
                    break;
                case "CorrosiveBreatherCorpse":
                    result = "CorrosiveBreather";
                    break;
                case "NormalityBreatherCorpse":
                    result = "NormalityBreather";
                    break;
                case "PoisonBreatherCorpse":
                    result = "PoisonBreather";
                    break;
                case "SleepBreatherCorpse":
                    result = "SleepBreather";
                    break;
                case "StunBreatherCorpse":
                    result = "StunBreather";
                    break;
                case "ConfusionBreatherCorpse":
                    result = "ConfusionBreather";
                    break;
                case "Troll Corpse":
                    result = "Troll";
                    break;
                case "Agolzvuv Corpse":
                    result = "Agolzvuv";
                    break;
                case "Bloated Pearlfrog Corpse":
                    result = "Bloated Pearlfrog";
                    break;
                case "Gibbon Corpse":
                    result = "Cyclopean Gibbon";
                    break;
                case "Mimic Corpse":
                    result = "Mimic";
                    break;
                case "Molting Basilisk Husk":
                    result = "Molting Basilisk";
                    break;
                case "Quartz Baboon Corpse":
                    result = "Quartz Baboon";
                    break;
                case "Snailmother Corpse":
                    result = "Snailmother";
                    break;
                case "Urchin Belcher Corpse":
                    result = "Urchin Belcher";
                    break;
                case "Bone Worm Corpse":
                    result = "Bone Worm";
                    break;
                case "Amaranthine Ashes":
                    result = "Goatfolk Qlippoth";
                    break;
                case "Greater Voider Corpse":
                    result = "Greater Voider";
                    break;
                case "Madpole Corpse":
                    result = "Madpole";
                    break;
                case "Ogre ape corpse":
                    result = "Ogre Ape";
                    break;
                case "Rhinox Corpse":
                    result = "Rhinox";
                    break;
                case "BaseElderBreatherCorpse":
                    result = "BaseElderBreather";
                    break;
                case "ElderFireBreatherCorpse":
                    result = "ElderFireBreather";
                    break;
                case "ElderIceBreatherCorpse":
                    result = "ElderIceBreather";
                    break;
                case "ElderCorrosiveBreatherCorpse":
                    result = "ElderCorrosiveBreather";
                    break;
                case "ElderNormalityBreatherCorpse":
                    result = "ElderNormalityBreather";
                    break;
                case "ElderPoisonBreatherCorpse":
                    result = "ElderPoisonBreather";
                    break;
                case "ElderSleepBreatherCorpse":
                    result = "ElderSleepBreather";
                    break;
                case "ElderStunBreatherCorpse":
                    result = "ElderStunBreather";
                    break;
                case "ElderConfusionBreatherCorpse":
                    result = "ElderConfusionBreather";
                    break;
                case "Enigma Snail Corpse":
                    result = "Enigma Snail";
                    break;
                case "Great Saltback Corpse":
                    result = "Great Saltback";
                    break;
                case "Kaleidoslug Corpse":
                    result = "Kaleidoslug";
                    break;
                case "Memory Eater Corpse":
                    result = "Memory Eater";
                    break;
                case "Sultan Croc Corpse":
                    result = "Sultan Croc";
                    break;
                case "Svardym Corpse":
                    result = "Svardym";
                    break;
                case "Saltwurm Corpse":
                    result = "Saltwurm";
                    break;
                case "Unimax Corpse":
                    result = "Unimax";
                    break;
                case "Urshiib Corpse":
                    result = "Urshiib";
                    break;
                case "Dromad Corpse":
                    result = "Dromad";
                    break;
                case "SlogCorpse":
                    result = "GolgothaSlog";
                    break;
                case "Biomech Corpse":
                    result = "BaseBiomech";
                    break;
            }

            return result;
        }

        public bool CreateUndead()
        {
            var cell = PickDestinationCell(8, AllowVis.OnlyVisible);

            // check if corpse is at cell
            var corpse = "";
            foreach (var objectInCell in cell.GetObjects())
            {
                if (objectInCell.IsAlive) continue;
                var last = objectInCell.Blueprint.Split(' ').Last();
                if (last.EndsWith("corpse", ignoreCase: true, CultureInfo.CurrentCulture))
                {
                    // dead thing found
                    corpse = objectInCell.Blueprint;
                    break;
                }
            }

            if (corpse == "")
            {
                Popup.Show("There are no valid targets in that square.");
                return false;
            }

            var blueprint = GetBlueprintFromCorpse(corpse);
            if (blueprint == "")
            {
                Popup.Show($"Failed to determine creature from {corpse}.");
                return false;
            }

            CooldownMyActivatedAbility(ActivatedAbilityID, 5);

            var go = GameObject.create(blueprint); //GameObject.create("Qudzu");
            if (go.pBrain != null)
            {
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