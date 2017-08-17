using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightsTree
    {
        private readonly int _fightersCount;
        private readonly int _contestId;
        private readonly int _fightStructureId;

        private FightNode _root;
        public FightNode Root => _root;

        public FightsTree(int contestId, int fightStructureId, int fighterCount)
        {
            if (fighterCount < 1)
            {
                throw new ArgumentException("Cannot be less than 1", nameof(fighterCount));
            }

            _fightersCount = fighterCount;
            _contestId = contestId;
            _fightStructureId = fightStructureId;

            _root = new FightNode();
            BuildTree(_root, _fightersCount);
        }

        private void BuildTree(FightNode root , int fightersCount)
        {
            if (fightersCount == 1)
            {
                return;
            }

            root.Fight = new Models.Fight
            {
                ContestId = _contestId,
                StructureId = _fightStructureId
            };


            int power = (int)(Math.Log(fightersCount, 2));
            int twoPower = (int)Math.Pow(2, power);
            int twoPowerPrev = (int)Math.Pow(2, power - 1);

            int leftFightersCount = twoPower;
            int rightFightersCount = fightersCount - twoPower;
            if (rightFightersCount < twoPowerPrev)
            {
                rightFightersCount = twoPowerPrev;
                leftFightersCount = fightersCount - twoPowerPrev;
            }

            if (leftFightersCount > 1)
            {
                FightNode leftNode = new FightNode(root);
                root.Children.Add(leftNode);
                BuildTree(leftNode, leftFightersCount);
            }

            if (rightFightersCount > 1)
            {
                FightNode rightNode = new FightNode(root);
                root.Children.Add(rightNode);
                BuildTree(rightNode, rightFightersCount);
            }
        }

        public void Print()
        {
            PrintTree(_root);
        }

        private void PrintTree(FightNode root, int level = 0)
        {
            string offset = string.Empty;
            for(int i=0;i <= level; i++)
            {
                offset += "         ";
            }

            Console.WriteLine(offset + "Fight: ");
            if (root.Children.Count == 1)
            {
                Console.WriteLine(offset + "       Blue fighter");
            }
            if (root.Children.Count == 0)
            {
                Console.WriteLine(offset + "       Red fighter");
                Console.WriteLine(offset + "       Blue fighter");
            }
            foreach (var node in root.Children)
            {
                PrintTree(node, level + 1);
            }
        } 
    }
}
