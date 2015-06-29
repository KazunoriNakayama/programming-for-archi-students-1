using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino;
using Rhino.Geometry;

namespace _5.Classes
{
    class AstroObject
    {
        //properties
        public double radius;
        public Point3d rotation_origin;
        public double rotation_radius;
        public double rotation_days;

        private Sphere obj;

        // constructors
        public AstroObject(
            double _radius,
            Point3d _rotation_origin,
            double _rotation_radius,
            double _rotation_days
            ) {

            // set variables
                radius = _radius;
                rotation_origin = _rotation_origin;
                rotation_radius = _rotation_radius;
                rotation_days = _rotation_days;

            // make the Sphere object.
                Point3d initial_position = rotation_origin;
                initial_position.Y += rotation_radius;
                obj = new Sphere(initial_position,radius);
       
        }


        //methods
        public void Rotate() { 
            // unit angle in one draw execution(frame). respectively for one year
            double delta_angle = RhinoMath.ToRadians(365.4 / rotation_days);

            // rotate the sphere
            //obj.Rotate(delta_angle,Vector3d.ZAxis,rotation_origin); // seems it has little delay...
            //TODO: position the obj coordinates not using Rotate(); function

            RhinoApp.WriteLine(Loop.frame_no.ToString());


            // add it to the document
            //_doc.Objects.AddSphere(obj); // made function to handle this
        }

        public Point3d Center() {
            return obj.Center;
        }

        public void Display(RhinoDoc _doc) {
            RhinoApp.WriteLine(Loop.frame_no.ToString());
            _doc.Objects.AddSphere(obj);
        }

        public void UpdateCenter(Point3d _center) {
            rotation_origin = _center;
        }

    }
}
