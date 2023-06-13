using System;
using XRL.World;
using XRL.World.Parts.Mutation;

namespace NecromancyMutation
{
    [Serializable]
    public class Reanimate : BaseMutation
    {
        public const string Command = "CommandReanimate";
        public const string Class = "Mental Mutation";
        public const string EnergyType = "Mental Mutation Reanimate";
        
        public Reanimate()
        {
            DisplayName = nameof(Reanimate);
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
            CooldownMyActivatedAbility(ActivatedAbilityID, 5);
            
            var go = GameObject.create("Qudzu");
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

        public override bool Mutate(GameObject go, int level=1)
        {
            ActivatedAbilityID =
                AddMyActivatedAbility(nameof(Burgeoning), Command, Class, Icon: "\r");
            return base.Mutate(go, level);
        }

        public override bool Unmutate(GameObject go)
        {
            RemoveMyActivatedAbility(ref ActivatedAbilityID);
            return base.Unmutate(go);
        }
    }
}