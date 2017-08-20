using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightersTossupper: IFightersTossupper
    {
        private Func<ApplicationUser, ApplicationUser, bool> _separateStrategy = (redFighter, blueFighter) =>
        {
            return true;
        };
        public void Tossup(List<ApplicationUser> fighters, FightsTree tree)
        {
            foreach(var fighter in fighters.OrderBy(f => Guid.NewGuid()))
            {
                bool result = TossupFighterToTree(fighter, tree.Root);
                Console.WriteLine(result);
            }
        }

        private bool TossupFighterToTree(ApplicationUser fighter, FightNode node)
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

                if (string.IsNullOrEmpty(node.Fight.BlueAthleteId) && node.Fight.RedAthlete.InstitutionId != fighter.InstitutionId)
                {
                    node.Fight.BlueAthleteId = fighter.Id;
                    node.Fight.BlueAthlete = fighter;
                    node.IsFilled = true;
                    return true;
                }

                return false;
            }

            foreach(var child in node.Children)
            {
                if (TossupFighterToTree(fighter, child))
                {
                    return true;
                }
            }

            node.IsFilled = true;
            return false;
        }
    }
}
