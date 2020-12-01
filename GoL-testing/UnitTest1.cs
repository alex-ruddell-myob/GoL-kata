using NUnit.Framework;
using GoL_kata;

namespace GoL_testing
{
    public class Tests
    {
        private Cell[,] cellArray;
        
        [SetUp]
        public void SetUp()
        {
            cellArray = new Cell[3, 3];
            // Initialise array...
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cellArray[i, j].alive = false;
                    cellArray[i, j].row = i;
                    cellArray[i, j].column = j;
                }
            }
        }
        [Test]
        public void CountLiveTest()
        {
            // Design oscillator...
            cellArray[1, 0].alive = true;
            cellArray[1, 1].alive = true;
            cellArray[1, 2].alive = true;

            int alive = Game.CountLiveNeighbours(cellArray[0, 1], cellArray, 3, 3);

            Assert.AreEqual(3, alive);
        }

        [Test]
        public void CountLiveEdgeTest()
        {
            // Design oscillator on edge
            cellArray[0, 0].alive = true;
            cellArray[0, 1].alive = true;
            cellArray[0, 2].alive = true;

            int alive = Game.CountLiveNeighbours(cellArray[2, 1], cellArray, 3, 3);
            
            Assert.AreEqual(3, alive);
        }

        [Test]
        public void CountLiveBigEdge()
        {
            // Design weird shape to confuse game...
            cellArray[0, 0].alive = true;
            cellArray[2, 0].alive = true;
            cellArray[0, 2].alive = true;
            
            int alive = Game.CountLiveNeighbours(cellArray[2, 2], cellArray, 3, 3);
            
            Assert.AreEqual(3, alive);
        }

        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void AliveCellTest(int aliveNeighbours, bool shouldBeAlive)
        {
            Cell cell = new Cell();
            cell.alive = true;

            cell = Game.UpdateCellStatus(cell, aliveNeighbours);
            
            Assert.AreEqual(shouldBeAlive, cell.alive);
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void DeadCellTest(int aliveNeighbours, bool shouldBeAlive)
        {
            Cell cell = new Cell();
            cell.alive = false;

            cell = Game.UpdateCellStatus(cell, aliveNeighbours);
            
            Assert.AreEqual(shouldBeAlive, cell.alive);
        }

        [Test]
        public void DuplicateCellTest()
        {
            Cell cell = new Cell();
            cell.alive = false;

            Cell newCell = Game.UpdateCellStatus(cell, 3);
            
            Assert.AreNotEqual(cell.alive, newCell.alive);
        }
    }
}