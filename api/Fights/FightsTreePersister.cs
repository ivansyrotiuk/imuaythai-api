using MuaythaiSportManagementSystemApi.Data;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightsTreePersister : IFightsTreePersister
    {
        private readonly ApplicationDbContext _context;

        public FightsTreePersister(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Save(FightsTree tree)
        {
            SaveNode(tree.Root);
            return _context.SaveChangesAsync();
        }

        private void SaveNode(FightNode node)
        {
            var fight = node.Fight;
            fight.NextFight = node.Parent?.Fight;
            _context.Fights.Add(fight);

            foreach(var child in node.Children)
            {
                SaveNode(child);
            }
        }
    }
}
