using NUnit.Framework;
using Minesweeper;
using System;
namespace Minesweeper_.net_unit_testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test_Surround()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(0, 0), new Sizes(3, 3));
            Coords[] expectation = { new Coords(0,1) , new Coords(1,0) , new Coords(1, 1) };
            Assert.AreEqual(expectation,Output);
        }
        [Test]
        public void Test_Surround2()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(2, 2), new Sizes(3, 3));
            Coords[] expectation = { new Coords(1, 1), new Coords(1, 2), new Coords(2, 1) };
            Assert.AreEqual(expectation, Output);
        }
        [Test]
        public void Test_Surround3()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(7, 7), new Sizes(3, 3));
            Coords[] expectation = {};
            Assert.AreEqual(expectation, Output);
        }
        [Test]
        public void Test_Surround4()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(-10, 7), new Sizes(3, 3));
            Coords[] expectation = { };
            Assert.AreEqual(expectation, Output);
        }
        [Test]
        public void Test_Surround5()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(1, 1), new Sizes(3, 3));
            Coords[] expectation = { new Coords(0, 0), new Coords(0, 1), new Coords(0, 2), new Coords(1, 0), new Coords(1, 2), new Coords(2, 0), new Coords(2, 1), new Coords(2, 2) };
            Assert.AreEqual(expectation, Output);
        }
        [Test]
        public void Test_Verify()
        {
            Computing Test_unit1 = new Computing();
            Assert.IsTrue(Test_unit1.Verify_Coordinates(new Coords(0,0),new Sizes(3,3)));
        }
        [Test]
        public void Test_()
        {
            Computing Test_unit1 = new Computing();
            Coords[] Output = Test_unit1.Get_SurroundingCoord(new Coords(0, 0), new Sizes(3, 3));
            Coords[] expectation = { new Coords(0, 1), new Coords(1, 0), new Coords(1, 1) };
            Assert.AreEqual(expectation, Output);
        }
        [Test]
        public void Test_Bomb()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 0,1,0},{ 1,0,1},{ 0,1,0} };
            Test_unit1.SetBombGrid(bomb_grid,new Sizes(3,3));
            Assert.IsFalse(Test_unit1.Check_isBomb(new Coords(1, 1)));
        }
        [Test]
        public void Test_Count()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(3, 3));
            int expectataion = 8;
            Assert.AreEqual(expectataion, Test_unit1.Check_BombSurround(new Coords(1, 1)));
        }
        [Test]
        public void Test_Count2()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(3, 3));
            int expectataion = -1;
            Assert.AreEqual(expectataion, Test_unit1.Check_BombSurround(new Coords(1, 1)));
        }
        [Test]
        public void Test_Count3()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(3, 3));
            int expectataion = -1;
            Assert.AreEqual(expectataion, Test_unit1.Check_BombSurround(new Coords(-1, 1)));
        }
        [Test]
        public void Test_Count4()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(3, 3));
            int expectataion = -1;
            Assert.AreEqual(expectataion, Test_unit1.Check_BombSurround(new Coords(1, 5)));
        }
        [Test]
        public void Test_He()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(3, 3));
            int expectataion = -1;
            Assert.AreEqual(expectataion, Test_unit1.Check_BombSurround(new Coords(1, 5)));
        }
        [Test]
        public void Test_Open()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid = 
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 1, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 1},
                  { 0, 1, 0 , 0, 1, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_open_grid =
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 1 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_data_grid =  
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 1 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(6, 6));
            Test_unit1.Open_at(new Coords(3, 2), new Sizes(6, 6));
            Test_unit1.print_console();
            Assert.AreEqual(expected_open_grid, Test_unit1.Open_Array(new Sizes(6, 6)));
            Assert.AreEqual(expected_data_grid, Test_unit1.Data_Array(new Sizes(6, 6)));
        }
        [Test]
        public void Test_Open2()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid =
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 1, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 1},
                  { 0, 1, 0 , 0, 1, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_open_grid =
                { { 0, 0, 1 , 1, 1, 1},
                  { 0, 0, 1 , 1, 1, 1},
                  { 0, 0, 1 , 1, 1, 1},
                  { 0, 0, 1 , 1, 1, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_data_grid =
                { { 0, 0, 1 , 0, 0, 0},
                  { 0, 0, 1 , 0, 0, 0},
                  { 0, 0, 1 , 0, 1, 1},
                  { 0, 0, 1 , 1, 2, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(6, 6));
            Test_unit1.Open_at(new Coords(2, 3), new Sizes(6, 6));
            Test_unit1.print_console();
            Assert.AreEqual(expected_open_grid, Test_unit1.Open_Array(new Sizes(6, 6)));
            Assert.AreEqual(expected_data_grid, Test_unit1.Data_Array(new Sizes(6, 6)));
        }
        [Test]
        public void Test_Open3()
        {
            Computing Test_unit1 = new Computing();
            int[,] bomb_grid =
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 1, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 1},
                  { 0, 1, 0 , 0, 1, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_open_grid =
                { { 0, 2, 2 , 1, 1, 2},
                  { 0, 3, 1 , 1, 1, 1},
                  { 0, 0, 1 , 1, 1, 1},
                  { 0, 0, 1 , 1, 1, 0},
                  { 0, 0, 0 , 0, 2, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            int[,] expected_data_grid =
                { { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 1 , 0, 0, 0},
                  { 0, 0, 1 , 0, 1, 1},
                  { 0, 0, 1 , 1, 2, 0},
                  { 0, 0, 0 , 0, 0, 0},
                  { 0, 0, 0 , 0, 0, 0}};
            Test_unit1.SetBombGrid(bomb_grid, new Sizes(6, 6));
            Test_unit1.setflag(new Coords(0, 2));
            Test_unit1.setflag(new Coords(0, 5));
            Test_unit1.setflag(new Coords(0, 1));
            Test_unit1.setflag(new Coords(4, 4));
            Test_unit1.setquestion(new Coords(1, 1));
            Test_unit1.Print2d(Test_unit1.Open_Array(new Sizes(6, 6)));
            Test_unit1.Open_at(new Coords(2, 3), new Sizes(6, 6));
            Test_unit1.setflag(new Coords(0, 4));
            Test_unit1.Print2d(Test_unit1.Open_Array(new Sizes(6, 6)));
            Test_unit1.print_console();
            Assert.AreEqual(expected_open_grid, Test_unit1.Open_Array(new Sizes(6, 6)));
            Assert.AreEqual(expected_data_grid, Test_unit1.Data_Array(new Sizes(6, 6)));
        }
    }
}