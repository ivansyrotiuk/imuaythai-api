using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api.Fights
{
    public class FightsTree
    {
        private readonly int _fightersCount;
        private readonly int _contestId;
        private readonly int _fightStructureId;
        private readonly int _contestCategoryId;

        

        private FightNode _root;
        public FightNode Root => _root;

        public FightsTree(int contestId, int contestCategoryId, int fightStructureId, int fighterCount)
        {
            if (fighterCount < 1)
            {
                throw new ArgumentException("Cannot be less than 1", nameof(fighterCount));
            }

            _fightersCount = fighterCount;
            _contestId = contestId;
            _fightStructureId = fightStructureId;
            _contestCategoryId = contestCategoryId;

            _root = new FightNode();
            BuildTree(_root, _fightersCount);
        }

        public FightsTree(List<Fight> fights)
        {
            _root = new FightNode();
            BuildTree(_root, fights, parent: null);
        }

        public List<Fight> ToList()
        {
            List<Fight> fightsList = new List<Fight>();
            NodeToList(_root, fightsList);

            return fightsList;
        }

        internal List<IndexedFight> CreateTreeIndex()
        {
            List<IndexedFight> index = new List<IndexedFight>();
            int deep = 1;
            NodeToIndex(_root, index, deep);

            return index;
        }

        private void BuildTree(FightNode root, int fightersCount)
        {
            if (fightersCount == 1)
            {
                return;
            }

            root.Fight = new Fight
            {
                ContestId = _contestId,
                StructureId = _fightStructureId,
                ContestCategoryId = _contestCategoryId
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

        private void BuildTree(FightNode node, List<Fight> fights, FightNode parent)
        {
            if (fights.Count == 0)
            {
                return;
            }

            var nodeFight = fights.FirstOrDefault(fight => fight.NextFightId == parent?.Fight.Id);
            fights.Remove(nodeFight);
            node.Fight = nodeFight;

            var childrenFights = fights.Where(fight => fight.NextFightId == nodeFight.Id).ToList();

            foreach(var fight in childrenFights)
            {
                FightNode childNode = new FightNode(fight, node);
                node.Children.Add(childNode);
                BuildTree(node:childNode, fights:fights, parent: node);
            }
        }

        private void NodeToList(FightNode node, List<Fight> destinationList)
        {
            var fight = node.Fight;
            fight.NextFight = node.Parent?.Fight;
            destinationList.Add(fight);

            foreach (var child in node.Children)
            {
                NodeToList(child, destinationList);
            }
        }

        private void NodeToIndex(FightNode node, List<IndexedFight> index, int deepLevel)
        {
            var fight = node.Fight;
            fight.NextFight = node.Parent?.Fight;
            var indexedFight = new IndexedFight(fight)
            {
                DrawDeepLevel = deepLevel
            };

            index.Add(indexedFight);

            deepLevel++;
            foreach (var child in node.Children)
            {
                NodeToIndex(child, index, deepLevel);
            }
        }

        public void Print()
        {
            PrintTree(_root);
        }

        private void PrintTree(FightNode root, int level = 0)
        {
            string offset = string.Empty;
            for (int i = 0; i <= level; i++)
            {
                offset += "         ";
            }

            Console.WriteLine(offset + "Fight: ");
            if (root.Children.Count == 1)
            {
                Console.WriteLine(offset + "       " + root.Children[0].Fight.BlueAthleteId);
            }
            if (root.Children.Count == 0)
            {
                Console.WriteLine(offset + "       " + root.Fight.RedAthleteId);
                Console.WriteLine(offset + "       " + root.Fight.BlueAthleteId );
            }
            foreach (var node in root.Children)
            {
                PrintTree(node, level + 1);
            }
        }
    }
}
