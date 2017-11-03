using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
{
    public class FightersTossupper: IFightersTossupper
    {
        private Func<ApplicationUser, ApplicationUser, bool> _differentGymPredicate = (redFighter, blueFighter) =>
        {
            return redFighter?.InstitutionId != blueFighter?.InstitutionId;
        };

        private Func<ApplicationUser, ApplicationUser, bool> _sameGymAllowedPredicate = (redFighter, blueFighter) =>
        {
            return redFighter?.Id != blueFighter?.Id;
        };

        public void Tossup(List<ApplicationUser> fighters, FightsTree tree)
        {
            for(int i = 0; i < 5; i++)
            {
                if (TryTossup(fighters.ToList(), tree, _differentGymPredicate))
                {
                    return;
                }

                ResetTree(tree.Root);
            }

            TryTossup(fighters.ToList(), tree, _sameGymAllowedPredicate);
        }

        

        private bool TryTossup(List<ApplicationUser> fighters, FightsTree tree, Func<ApplicationUser, ApplicationUser, bool> compatibilityPredicate)
        {
            bool result = true;
            foreach (var fighter in fighters.OrderBy(f => Guid.NewGuid()))
            {
                if(!TossupFighterToTree(fighter, tree.Root, compatibilityPredicate))
                {
                    result = false;
                }
            }

            return result;
        }

        private bool TossupFighterToTree(ApplicationUser fighter, FightNode node, Func<ApplicationUser, ApplicationUser, bool> compatibilityPredicate)
        {
            if (node.IsFilled)
            {
                return false;
            }

            if (node.Children.Count == 0)
            {
                if (string.IsNullOrEmpty(node.Fight.RedAthleteId))
                {
                    node.Fight.RedAthleteId = fighter.Id;
                    node.Fight.RedAthlete = fighter;
                    return true;
                }

                if (string.IsNullOrEmpty(node.Fight.BlueAthleteId) && compatibilityPredicate(node.Fight.RedAthlete, fighter))
                {
                    node.Fight.BlueAthleteId = fighter.Id;
                    node.Fight.BlueAthlete = fighter;
                    node.IsFilled = true;
                    return true;
                }

                return false;
            }

            if (node.Children.Count == 1 && node.Children[0].IsFilled)
            {
                if (string.IsNullOrEmpty(node.Fight.BlueAthleteId) && compatibilityPredicate(node.Fight.RedAthlete, fighter))
                {
                    node.Fight.BlueAthleteId = fighter.Id;
                    node.Fight.BlueAthlete = fighter;
                    node.IsFilled = true;
                    return true;
                }
                return false;
            }

            foreach (var child in node.Children)
            {
                if (TossupFighterToTree(fighter, child, compatibilityPredicate))
                {
                    return true;
                }
            }

            node.IsFilled = true;
            return false;
        }

        private void ResetTree(FightNode node)
        {
            node.IsFilled = false;
            node.Fight.RedAthleteId = null;
            node.Fight.BlueAthleteId = null;

            foreach (var child in node.Children)
            {
                ResetTree(child);
            }

        }
    }
}
