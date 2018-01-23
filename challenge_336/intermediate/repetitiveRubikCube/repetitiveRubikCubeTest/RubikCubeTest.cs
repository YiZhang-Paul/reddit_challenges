﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepetitiveRubikCubeClassLibrary;

namespace repetitiveRubikCubeTest {
    [TestClass]
    public class RubikCubeTest {

        RubikCube rubikCube;

        [TestInitialize]
        public void Setup() {

            rubikCube = new RubikCube();
        }

        [TestMethod]
        public void OnDefaultState() {

            Assert.IsTrue(rubikCube.OnDefault);
        }

        [TestMethod]
        public void CorrectFaces() {

            var faces = rubikCube.Faces.Select(pair => pair.Value);
            var colors = faces.Select(face => face.Color);

            Assert.AreEqual(6, faces.Count());
            Assert.AreEqual(6, new HashSet<char>(colors).Count);
        }

        [TestMethod]
        public void RotateLeftClockwise() {

            rubikCube.RotateLeftClockwise();

            char[] topColumn = rubikCube.Faces["top"].GetColumn(0);
            char[] frontColumn = rubikCube.Faces["front"].GetColumn(0);
            char[] bottomColumn = rubikCube.Faces["bottom"].GetColumn(0);
            char[] backColumn = rubikCube.Faces["back"].GetColumn(0);

            Assert.AreEqual("ggg", string.Join("", topColumn));
            Assert.AreEqual("bbb", string.Join("", frontColumn));
            Assert.AreEqual("rrr", string.Join("", bottomColumn));
            Assert.AreEqual("www", string.Join("", backColumn));
        }

        [TestMethod]
        public void RotateLeftCounterClockwise() {

            rubikCube.RotateLeftCounterClockwise();

            char[] topColumn = rubikCube.Faces["top"].GetColumn(0);
            char[] frontColumn = rubikCube.Faces["front"].GetColumn(0);
            char[] bottomColumn = rubikCube.Faces["bottom"].GetColumn(0);
            char[] backColumn = rubikCube.Faces["back"].GetColumn(0);

            Assert.AreEqual("rrr", string.Join("", topColumn));
            Assert.AreEqual("www", string.Join("", frontColumn));
            Assert.AreEqual("ggg", string.Join("", bottomColumn));
            Assert.AreEqual("bbb", string.Join("", backColumn));
        }

        [TestMethod]
        public void RotateRightClockwise() {

            rubikCube.RotateRightClockwise();

            char[] topColumn = rubikCube.Faces["top"].GetColumn(2);
            char[] frontColumn = rubikCube.Faces["front"].GetColumn(2);
            char[] bottomColumn = rubikCube.Faces["bottom"].GetColumn(2);
            char[] backColumn = rubikCube.Faces["back"].GetColumn(2);

            Assert.AreEqual("rrr", string.Join("", topColumn));
            Assert.AreEqual("www", string.Join("", frontColumn));
            Assert.AreEqual("ggg", string.Join("", bottomColumn));
            Assert.AreEqual("bbb", string.Join("", backColumn));
        }

        [TestMethod]
        public void RotateRightCounterClockwise() {

            rubikCube.RotateRightCounterClockwise();

            char[] topColumn = rubikCube.Faces["top"].GetColumn(2);
            char[] frontColumn = rubikCube.Faces["front"].GetColumn(2);
            char[] bottomColumn = rubikCube.Faces["bottom"].GetColumn(2);
            char[] backColumn = rubikCube.Faces["back"].GetColumn(2);

            Assert.AreEqual("ggg", string.Join("", topColumn));
            Assert.AreEqual("bbb", string.Join("", frontColumn));
            Assert.AreEqual("rrr", string.Join("", bottomColumn));
            Assert.AreEqual("www", string.Join("", backColumn));
        }

        [TestMethod]
        public void RotateFrontClockwise() {

            rubikCube.RotateFrontClockwise();

            char[] topRow = rubikCube.Faces["top"].GetRow(2);
            char[] rightColumn = rubikCube.Faces["right"].GetColumn(0);
            char[] bottomRow = rubikCube.Faces["bottom"].GetRow(0);
            char[] leftColumn = rubikCube.Faces["left"].GetColumn(2);

            Assert.AreEqual("ooo", string.Join("", topRow));
            Assert.AreEqual("bbb", string.Join("", rightColumn));
            Assert.AreEqual("yyy", string.Join("", bottomRow));
            Assert.AreEqual("www", string.Join("", leftColumn));
        }

        [TestMethod]
        public void RotateFrontCounterClockwise() {

            rubikCube.RotateFrontCounterClockwise();

            char[] topRow = rubikCube.Faces["top"].GetRow(2);
            char[] rightColumn = rubikCube.Faces["right"].GetColumn(0);
            char[] bottomRow = rubikCube.Faces["bottom"].GetRow(0);
            char[] leftColumn = rubikCube.Faces["left"].GetColumn(2);

            Assert.AreEqual("yyy", string.Join("", topRow));
            Assert.AreEqual("www", string.Join("", rightColumn));
            Assert.AreEqual("ooo", string.Join("", bottomRow));
            Assert.AreEqual("bbb", string.Join("", leftColumn));
        }
    }
}