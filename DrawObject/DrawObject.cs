using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;

namespace DrawObject
{
    public class DrawObject
    {
        [CommandMethod("DrawPLine")]
        public void DrawPline()
        {
            // Create the drawing document and database object
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // Create the transaction object inside the using block
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // Message
                    doc.Editor.WriteMessage("\nDrawing a polyline!");

                    // Get the BlockTable object
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    // Specify the Poluline's coordinates
                    Polyline pl = new Polyline();
                    pl.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(10, 10), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(20, 20), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(30, 30), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(40, 40), 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(50, 50), 0, 0, 0);

                    pl.SetDatabaseDefaults();
                    btr.AppendEntity(pl);
                    trans.AddNewlyCreatedDBObject(pl, true);
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error encountered : " + ex.Message);
                    trans.Abort();
                }
            }
        }
        [CommandMethod("DrawArc")]
        public void DrawArc()
        {
            // Create the drawing document and database object
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // Create the transaction object inside the using block
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // Message
                    doc.Editor.WriteMessage("\nDrawing an arc!");

                    // Get the BlockTable object
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    // Specify an arc parameters
                    Point3d centerPt = new Point3d(10, 10, 0);
                    double rad = 20;
                    double startAngle = 1.0;
                    double endAngle = 3.0;
                    Arc arc = new Arc(centerPt, rad, startAngle, endAngle);

                    // Set the default properties
                    arc.SetDatabaseDefaults();
                    btr.AppendEntity(arc);
                    trans.AddNewlyCreatedDBObject(arc, true);

                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    doc.Editor.WriteMessage("Error encounterec : " + ex.Message);
                    trans.Abort();
                }
            }
        }

        [CommandMethod("DrawCircle")]
        public void DrawCircle()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    edt.WriteMessage("\nDrawing a circle!");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    // Specify a circle parameters (e.g. centerPoint, radius)
                    Point3d centerPt = new Point3d(100, 100, 0);
                    double circleRad = 100;
                    using (Circle circle = new Circle())
                    {
                        circle.Radius = circleRad;
                        circle.Center = centerPt;

                        btr.AppendEntity(circle);
                        trans.AddNewlyCreatedDBObject(circle, true);
                    }
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    edt.WriteMessage("Error encountered : " + ex.Message);
                    trans.Abort();
                }
            }
        }

        [CommandMethod("DrawMText")]
        public void MText()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    edt.WriteMessage("\nDrawing a MText!");
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    // Specify MText parameters (e.g. textstring, insertionPoint)
                    String txt = "Hello AutoCAD from C#!";
                    Point3d insPt = new Point3d(200, 200, 0);

                    using (MText mtx = new MText())
                    {
                        mtx.Contents = txt;
                        mtx.Location = insPt;

                        btr.AppendEntity(mtx);
                        trans.AddNewlyCreatedDBObject(mtx, true);  
                    }
                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    edt.WriteMessage("Error encountered : " + ex.Message);
                    trans.Abort();
                }
            }
        }

        [CommandMethod("DrawLine")]
        public void DrawLine()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    // Send a message to the user
                    edt.WriteMessage("\nDrawing a Line object: ");

                    Point3d pt1 = new Point3d(0, 0, 0);
                    Point3d pt2 = new Point3d(100, 100, 0);
                    Line ln1 = new Line(pt1, pt2);
                    ln1.ColorIndex = 1; // Color is red
                    btr.AppendEntity(ln1);
                    trans.AddNewlyCreatedDBObject(ln1, true);
                    trans.Commit();
                }


                catch (System.Exception ex)
                {
                    edt.WriteMessage("Error encountered: " + ex.Message);
                    trans.Abort();
                }
            }
        }
    }
}
